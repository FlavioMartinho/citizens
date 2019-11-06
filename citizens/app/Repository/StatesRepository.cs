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
  public class StatesRepository : IStatesRepository
  {

    private readonly CitizensDbContext _context;
    private readonly ILogger _logger;

    public StatesRepository(CitizensDbContext context, ILoggerFactory loggerFactory)
    {
      _context = context;
      _logger = loggerFactory.CreateLogger("StatesRepository");
    }

    public async Task<List<State>> GetStatesAsync()
    {
      return await _context.States.OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<State> GetStateAsync(int id)
    {
      return await _context.States.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<State> InsertStateAsync(State state)
    {
      _context.Add(state);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(InsertStateAsync)}: " + exp.Message);
      }

      return state;
    }

    public async Task<bool> UpdateStateAsync(State state)
    {
      _context.States.Attach(state);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(UpdateStateAsync)}: " + exp.Message);
      }
      return false;
    }

    public async Task<bool> DeleteStateAsync(int id)
    {
      var state = await _context.States.SingleOrDefaultAsync(c => c.Id == id);
      _context.Remove(state);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(DeleteStateAsync)}: " + exp.Message);
      }
      return false;
    }

  }
}
