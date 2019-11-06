using System.Collections.Generic;
using System.Threading.Tasks;

using Citizens.Models;

namespace Citizens.Interface
{
  public interface IAdressesRepository
  {
    Task<List<Address>> GetAdressesAsync();
    Task<Address> GetAddressAsync(int id);
    Task<Address> InsertAddressAsync(Address address);
    Task<bool> UpdateAddressAsync(Address address);
    Task<bool> DeleteAddressAsync(int id);
  }
}
