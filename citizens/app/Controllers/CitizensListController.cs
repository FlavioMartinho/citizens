using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Citizens.Models;
using Citizens.Repository;
using Citizens.Interface;

namespace Citizens.Controllers
{
  [Route("api/citizens")]
  public class CitizensListController : Controller
  {
    IPersonsRepository _repo;
    public CitizensListController(IPersonsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(List<Person>), 200)]
    [ProducesResponseType(typeof(List<Person>), 404)]
    public async Task<ActionResult> Persons()
    {
      var persons = await _repo.GetPersonsAdressesAsync();
      if (persons == null)
      {
        return NotFound();
      }
      return Ok(persons);
    }
  }
}
