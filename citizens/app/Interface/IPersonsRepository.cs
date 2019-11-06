using System.Collections.Generic;
using System.Threading.Tasks;

using Citizens.Models;

namespace Citizens.Interface
{
  public interface IPersonsRepository
  {
    Task<List<Person>> GetPersonsAsync();
    Task<List<Person>> GetPersonsAdressesAsync();
    Task<Person> GetPersonAsync(int id);
    Task<Person> GetPersonAddressAsync(int id);
    Task<Person> InsertPersonAsync(Person person);
    Task<bool> UpdatePersonAsync(Person person);
    Task<bool> DeletePersonAsync(int id);
  }
}
