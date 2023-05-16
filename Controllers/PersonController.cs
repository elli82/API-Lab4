using API_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using APIModels;

namespace API_Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_person.GetPeople());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetPerson(int id)
        {
            var result = _person.GetPersonById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Person with id {id} was not found");
        }
        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var searchresult = _person.GetPersonByName(name);
            if (searchresult.Any())
            {
                return Ok(searchresult);
            }
            return NotFound();
        }
    }
}
