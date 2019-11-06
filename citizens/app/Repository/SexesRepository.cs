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
  public class SexesRepository : ISexesRepository
  {

    private readonly CitizensDbContext _context;
    private readonly ILogger _logger;

    public SexesRepository(CitizensDbContext context, ILoggerFactory loggerFactory)
    {
      _context = context;
      _logger = loggerFactory.CreateLogger("SexesRepository");
    }

    public async Task<List<Sex>> GetSexesAsync()
    {
      return await _context.Sexes.OrderBy(c => c.Description).ToListAsync();
    }

    public async Task<Sex> GetSexAsync(int id)
    {
      return await _context.Sexes.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Sex> InsertSexAsync(Sex sex)
    {
      _context.Add(sex);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(InsertSexAsync)}: " + exp.Message);
      }

      return sex;
    }

    public async Task<bool> UpdateSexAsync(Sex sex)
    {
      _context.Sexes.Attach(sex);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(UpdateSexAsync)}: " + exp.Message);
      }
      return false;
    }

    public async Task<bool> DeleteSexAsync(int id)
    {
      var sex = await _context.Sexes.SingleOrDefaultAsync(c => c.Id == id);
      _context.Remove(sex);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(DeleteSexAsync)}: " + exp.Message);
      }
      return false;
    }

  }
}
