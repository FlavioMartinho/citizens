using System.Collections.Generic;
using System.Threading.Tasks;

using Citizens.Models;

namespace Citizens.Interface
{
  public interface ISexesRepository
  {
    Task<List<Sex>> GetSexesAsync();
    Task<Sex> GetSexAsync(int id);
    Task<Sex> InsertSexAsync(Sex sex);
    Task<bool> UpdateSexAsync(Sex sex);
    Task<bool> DeleteSexAsync(int id);
  }
}
