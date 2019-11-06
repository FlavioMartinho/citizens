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
  [Route("api/sexes")]
  public class SexesController : Controller
  {
    ISexesRepository _repo;

    public SexesController(ISexesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(List<Sex>), 200)]
    [ProducesResponseType(typeof(List<Sex>), 404)]
    public async Task<ActionResult> Sexes()
    {
      var sexes = await _repo.GetSexesAsync();
      if (sexes == null)
      {
        return NotFound();
      }
      return Ok(sexes);
    }
  }
}
