using System.Collections.Generic;
using System.Threading.Tasks;

using Citizens.Models;

namespace Citizens.Interface
{
  public interface ICitiesRepository
  {
    Task<List<City>> GetCitiesAsync(int StateId);
  }
}
