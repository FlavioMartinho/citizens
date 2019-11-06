using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Citizens.Models;
using Citizens.Interface;
using Citizens.Repository;
using Microsoft.AspNetCore.Http;

namespace Citizens.Controllers
{
  [Route("api/states")]
  public class StatesController : Controller
  {
    IStatesRepository _repo;

    public StatesController(IStatesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(List<State>), 200)]
    [ProducesResponseType(typeof(List<State>), 404)]
    public async Task<ActionResult> States()
    {
      var states = await _repo.GetStatesAsync();
      if (states == null)
      {
        return NotFound();
      }
      return Ok(states);
    }
  }
}
