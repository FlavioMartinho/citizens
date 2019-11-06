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
  public class PersonsRepository : IPersonsRepository
  {

    private readonly CitizensDbContext _context;
    private readonly ILogger _logger;

    public PersonsRepository(CitizensDbContext context, ILoggerFactory loggerFactory)
    {
      _context = context;
      _logger = loggerFactory.CreateLogger("PersonsRepository");
    }

    public async Task<List<Person>> GetPersonsAsync()
    {
      return await _context.Persons.OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<List<Person>> GetPersonsAdressesAsync()
    {
      return await _context.Persons
        .Include(p => p.Address)
          .ThenInclude(p => p.City)
            .ThenInclude(p => p.State)
        .OrderBy(c => c.Name)
        .ToListAsync();
    }

    public async Task<Person> GetPersonAddressAsync(int id)
    {
      return await _context.Persons
        .Include(p => p.Address)
        .ThenInclude(p => p.City)
              .ThenInclude(p => p.State)
        .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Person> GetPersonAsync(int id)
    {
      return await _context.Persons.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Person> InsertPersonAsync(Person person)
    {
      
      _context.Persons.Add(person);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(InsertPersonAsync)}: " + exp.Message);
      }

      return person;
    }

    public async Task<bool> UpdatePersonAsync(Person person)
    {
      _context.Persons.Update(person);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (Exception exp)
      {
        _logger.LogError($"Error in {nameof(UpdatePersonAsync)}: " + exp.Message);
      }
      return false;
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
      var person = await _context.Persons.SingleOrDefaultAsync(c => c.Id == id);
      _context.Remove(person);
      try
      {
        return (await _context.SaveChangesAsync() > 0 ? true : false);
      }
      catch (System.Exception exp)
      {
        _logger.LogError($"Error in {nameof(DeletePersonAsync)}: " + exp.Message);
      }
      return false;
    }

  }
}
