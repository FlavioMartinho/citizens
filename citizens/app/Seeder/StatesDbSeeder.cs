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
  public class StatesDbSeeder
  {
    readonly ILogger _logger;

    public StatesDbSeeder(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger("StatesDbSeederLogger");
    }

    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var CitizensDb = serviceScope.ServiceProvider.GetService<CitizensDbContext>();
        if (!await CitizensDb.States.AnyAsync())
        {
          await InsertStatesSampleData(CitizensDb);
        }
      }
    }

    public async Task InsertStatesSampleData(CitizensDbContext db)
    {
      var states = GetStates();
      db.States.AddRange(states);
      try
      {
        await db.SaveChangesAsync();
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(StatesDbSeeder)}: " + exp.Message);
        throw;
      }

    }
    private List<State> GetStates()
    {
      Random random = new Random();
      var states = new List<State>
        {
          new State {
            Name = "Acre",
            UF = "AC"
          },
          new State {
            Name = "Alagoas",
            UF = "AL"
          },
          new State {
            Name = "Amapá",
            UF = "AP"
          },
          new State {
            Name = "Amazonas",
            UF = "AM"
          },
          new State {
            Name = "Bahia",
            UF = "BA"
          },
          new State {
            Name = "Ceará",
            UF = "CE"
          },
          new State {
            Name = "Distrito Federal",
            UF = "DF"
          },
          new State {
            Name = "Espírito Santo",
            UF = "ES"
          },
          new State {
            Name = "Goiás",
            UF = "GO"
          },
          new State {
            Name = "Maranhão",
            UF = "MA"
          },
          new State {
            Name = "Mato Grosso",
            UF = "MT"
          },
          new State {
            Name = "Mato Grosso do Sul",
            UF = "MS"
          },
          new State {
            Name = "Minas Gerais",
            UF = "MG"
          },
          new State {
            Name = "Pará",
            UF = "PA"
          },
          new State {
            Name = "Paraíba",
            UF = "PB"
          },
          new State {
            Name = "Paraná",
            UF = "PR"
          },
          new State {
            Name = "Pernambuco",
            UF = "PE"
          },
          new State {
            Name = "Piauí",
            UF = "PI"
          },
          new State {
            Name = "Rio de Janeiro",
            UF = "RJ"
          },
          new State {
            Name = "Rio Grande do Norte",
            UF = "RN"
          },
          new State {
            Name = "Rio Grande do Sul",
            UF = "RS"
          },
          new State {
            Name = "Rondônia",
            UF = "RO"
          },
          new State {
            Name = "Roraima",
            UF = "RR"
          },
          new State {
            Name = "Santa Catarina",
            UF = "SC"
          },
          new State {
            Name = "São Paulo",
            UF = "SP"
          },
          new State {
            Name = "Sergipe",
            UF = "SE"
          },
          new State {
            Name = "Tocantins",
            UF = "TO"
          }
        };

      return states;
    }
  }
}

