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
  [Route("api/cities")]
  public class CitiesController : Controller
  {
    ICitiesRepository _repo;

    public CitiesController(ICitiesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(List<City>), 200)]
    [ProducesResponseType(typeof(List<City>), 404)]
    public async Task<ActionResult> Cities(int id)
    {
      var cities = await _repo.GetCitiesAsync(id);
      if (cities == null)
      {
        return NotFound();
      }
      return Ok(cities);
    }
  }
}
