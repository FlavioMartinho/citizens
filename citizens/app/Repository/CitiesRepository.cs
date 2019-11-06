using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Citizens.Models;
using Citizens.Context;
using Citizens.Interface;

namespace Citizens.Repository
{
  public class CitiesRepository : ICitiesRepository
  {

    private readonly CitizensDbContext _context;
    private readonly ILogger _logger;

    public CitiesRepository(CitizensDbContext context, ILoggerFactory loggerFactory)
    {
      _context = context;
      _logger = loggerFactory.CreateLogger("CitiesRepository");
    }

    public async Task<List<City>> GetCitiesAsync(int StateId)
    {
      return await _context.Cities.Where(c => c.StateId == StateId).OrderBy(c => c.Name).ToListAsync();
    }

  }
}
