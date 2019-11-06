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
  public class CitizensDbSeeder
  {
    readonly ILogger _logger;

    public CitizensDbSeeder(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger("CitizensDbSeederLogger");
    }

    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var CitizensDb = serviceScope.ServiceProvider.GetService<CitizensDbContext>();
        if (!await CitizensDb.Persons.AnyAsync())
        {
          await InsertCitizensSampleData(CitizensDb);
        }
      }
    }

    public async Task InsertCitizensSampleData(CitizensDbContext db)
    {
      var citizens = GetCitizens();
      db.Persons.AddRange(citizens);
      try
      {
        await db.SaveChangesAsync();
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(CitizensDbSeeder)}: " + exp.Message);
        throw;
      }

    }
    private List<Person> GetCitizens()
    {
      Random random = new Random();
      var citizens = new List<Person>
        {
          new Person {
            Name = "Adriana Alves da Rocha",
            //yyyy-MM-dd
            BirthDate = "1969-04-22",
            RG = "402135914",
            CPF = "44334642363",
            Telephone = random.Next(10000000, 99999999).ToString(),
            Mobile = random.Next(10000000, 99999999).ToString(),
            SexId = 1,
            Address = new Address {
              CEP = random.Next(10000000, 99999999).ToString(),
              AddressDescription = "Rua das Alamedas",
              Number = random.Next(10, 9999).ToString(),
              Complement = "Bloco 1 Apto 101",
              Neighborhood = "Jardim Azul",
              CityId = 3
            }
          },
          new Person {
            Name = "Alfredo Cruz de Souza",
            //yyyy-MM-dd
            BirthDate = "1988-11-15",
            RG = "206184314",
            CPF = "21336482370",
            Telephone = random.Next(10000000, 99999999).ToString(),
            Mobile = random.Next(10000000, 99999999).ToString(),
            SexId = 2,
            Address = new Address {
              CEP = random.Next(10000000, 99999999).ToString(),
              AddressDescription = "Avenida Mexico",
              Number = random.Next(10, 9999).ToString(),
              Complement = "",
              Neighborhood = "Jardim Ozório",
              CityId = 4
            }
          },
          new Person {
            Name = "Roberto Guilherme Azevedo",
            //yyyy-MM-dd
            BirthDate = "2002-01-27",
            RG = "976475329",
            CPF = "2247423542",
            Telephone = random.Next(10000000, 99999999).ToString(),
            Mobile = random.Next(10000000, 99999999).ToString(),
            SexId = 2,
            Address = new Address {
              CEP = random.Next(10000000, 99999999).ToString(),
              AddressDescription = "Alameda 1",
              Number = random.Next(10, 9999).ToString(),
              Complement = "",
              Neighborhood = "Novo Horizonte",
              CityId = 26
            }
          }
        };

      return citizens;
    }
  }
}
