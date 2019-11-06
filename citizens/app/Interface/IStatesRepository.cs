using System.Collections.Generic;
using System.Threading.Tasks;

using Citizens.Models;

namespace Citizens.Interface
{
  public interface IStatesRepository
  {
    Task<List<State>> GetStatesAsync();
    Task<State> GetStateAsync(int id);
    Task<State> InsertStateAsync(State state);
    Task<bool> UpdateStateAsync(State state);
    Task<bool> DeleteStateAsync(int id);
  }
}
