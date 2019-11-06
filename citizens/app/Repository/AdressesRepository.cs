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
  public class AdressesRepository : IAdressesRepository
  {

    private readonly CitizensDbContext _context;
    private readonly ILogger _logger;

    public AdressesRepository(CitizensDbContext context, ILoggerFactory loggerFactory)
    {
      _context = context;
      _logger = loggerFactory.CreateLogger("AdressesRepository");
    }

    public async Task<List<Address>> GetAdressesAsync()
    {
      return await _context.Adresses.OrderBy(c => c.AddressDescription).ToListAsync();
    }

    public async Task<Address> GetAddressAsync(int id)
    {
      return await _context.Adresses.SingleOrDefaultAsync(c => c.PersonAddressId == id);
    }

    public async Task<Address> InsertAddressAsync(Address address)
    {
      _context.Add(address);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(InsertAddressAsync)}: " + exp.Message);
      }

      return address;
    }

    public async Task<bool> UpdateAddressAsync(Address address)
    {
      _context.Adresses.Attach(address);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(UpdateAddressAsync)}: " + exp.Message);
      }
      return false;
    }

    public async Task<bool> DeleteAddressAsync(int id)
    {
      var address = await _context.Adresses.SingleOrDefaultAsync(c => c.PersonAddressId == id);
      _context.Remove(address);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(DeleteAddressAsync)}: " + exp.Message);
      }
      return false;
    }

  }
}
