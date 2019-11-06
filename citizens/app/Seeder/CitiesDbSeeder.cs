using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Citizens.Models;
using Citizens.Context;

namespace Citizens.Seeder
{
  public class CitiesDbSeeder
  {
    readonly ILogger _logger;

    public CitiesDbSeeder(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger("CitiesDbSeederLogger");
    }

    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var CitizensDb = serviceScope.ServiceProvider.GetService<CitizensDbContext>();
        if (!await CitizensDb.Cities.AnyAsync())
        {
          await InsertCitiesSampleData(CitizensDb);
        }
      }
    }

    public async Task InsertCitiesSampleData(CitizensDbContext db)
    {
      var cities = GetCities();
      db.Cities.AddRange(cities);
      try
      {
        await db.SaveChangesAsync();
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(CitiesDbSeeder)}: " + exp.Message);
        throw;
      }

    }
    private List<City> GetCities()
    {
      Random random = new Random();
      var cities = new List<City>
        {
          new City {
            Name = "Rio Branco",
            StateId = 1
          },
          new City {
            Name = "Maceió",
            StateId = 25
          },
          new City {
            Name = "Macapá",
            StateId = 24
          },
          new City {
            Name = "Manaus",
            StateId = 23
          },
          new City {
            Name = "Salvador",
            StateId = 22
          },
          new City {
            Name = "Fortaleza",
            StateId = 21
          },
          new City {
            Name = "Brasília",
            StateId = 20
          },
          new City {
            Name = "Vitória",
            StateId = 19
          },
          new City {
            Name = "Goiânia",
            StateId = 18
          },
          new City {
            Name = "São Luís",
            StateId = 17
          },
          new City {
            Name = "Cuiabá",
            StateId = 16
          },
          new City {
            Name = "Campo Grande",
            StateId = 15
          },
          new City {
            Name = "Belo Horizonte",
            StateId = 26
          },
          new City {
            Name = "Uberlândia",
            StateId = 26
          },
          new City {
            Name = "Belém",
            StateId = 14
          },
          new City {
            Name = "João Pessoa",
            StateId = 12
          },
          new City {
            Name = "Curitiba",
            StateId = 11
          },
          new City {
            Name = "Recife",
            StateId = 10
          },
          new City {
            Name = "Teresina",
            StateId = 9
          },
          new City {
            Name = "Rio de Janeiro",
            StateId = 8
          },
          new City {
            Name = "Realengo",
            StateId = 8
          },
          new City {
            Name = "Natal",
            StateId = 7
          },
          new City {
            Name = "Porto Alegre",
            StateId = 6
          },
          new City {
            Name = "Porto Velho",
            StateId = 5
          },
          new City {
            Name = "Boa Vista",
            StateId = 4
          },
          new City {
            Name = "Florianópolis",
            StateId = 3
          },
          new City {
            Name = "São Paulo",
            StateId = 2
          },
          new City {
            Name = "São José do Rio Preto",
            StateId = 2
          },
          new City {
            Name = "Campinas",
            StateId = 2
          },
          new City {
            Name = "Bady Bassit",
            StateId = 2
          },
          new City {
            Name = "Aracaju",
            StateId = 13
          },
          new City {
            Name = "Palmas",
            StateId = 27
          }
        };

      return cities;
    }
  }
}

