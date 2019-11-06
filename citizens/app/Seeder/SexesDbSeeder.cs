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
  public class SexesDbSeeder
  {
    readonly ILogger _logger;

    public SexesDbSeeder(ILoggerFactory loggerFactory)
    {
      _logger = loggerFactory.CreateLogger("SexesDbSeederLogger");
    }

    public async Task SeedAsync(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var CitizensDb = serviceScope.ServiceProvider.GetService<CitizensDbContext>();
        if (!await CitizensDb.Sexes.AnyAsync())
        {
          await InsertSexesSampleData(CitizensDb);
        }
      }
    }

    public async Task InsertSexesSampleData(CitizensDbContext db)
    {
      var sexes = GetSexes();
      db.Sexes.AddRange(sexes);
      try
      {
        await db.SaveChangesAsync();
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(SexesDbSeeder)}: " + exp.Message);
        throw;
      }

    }
    private List<Sex> GetSexes()
    {
      Random random = new Random();
      var sexes = new List<Sex>
        {
          new Sex {
            Description = "Feminino"
          },
          new Sex {
            Description = "Masculino"
          },
          new Sex {
            Description = "Indefinido"
          },
        };

      return sexes;
    }
  }
}
