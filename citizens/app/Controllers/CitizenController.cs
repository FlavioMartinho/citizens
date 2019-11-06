using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Citizens.Models;
using Citizens.Repository;
using Citizens.Interface;
using Microsoft.Extensions.Logging;

namespace Citizens.Controllers
{
  [Route("api/citizen")]
  public class CitizenController : Controller
  {
    IPersonsRepository _repo;
    private readonly ILogger _logger;

    public CitizenController(IPersonsRepository repo, ILoggerFactory loggerFactory)
    {
      _repo = repo;
      _logger = loggerFactory.CreateLogger("PersonsController");
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Person), 200)]
    [ProducesResponseType(typeof(Person), 404)]
    public async Task<ActionResult> PersonById(int id)
    {
      var person = await _repo.GetPersonAddressAsync(id);
      if (person == null)
      {
        return NotFound();
      }
      return Ok(Json(person));
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Person), 201)]
    [ProducesResponseType(typeof(string), 400)]
    public async Task<ActionResult> PostPerson([FromBody] Person person)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(this.ModelState);
      }

      var newPerson = await _repo.InsertPersonAsync(person);
      if (newPerson == null)
      {
        return BadRequest("Unable to insert person");
      }
      return Ok(newPerson);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(bool), 400)]
    public async Task<ActionResult> PutPerson(int id, [FromBody]Person person)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(this.ModelState);
      }

      var status = await _repo.UpdatePersonAsync(person);
      if (!status)
      {
        return BadRequest("Unable to update person");
      }
      return Ok(status);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(typeof(bool), 404)]
    public async Task<ActionResult> DeletePerson(int id)
    {
      var status = await _repo.DeletePersonAsync(id);
      if (!status)
      {
        return NotFound();
      }
      return Ok(status);
    }
  }
}
