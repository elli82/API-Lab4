using API_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using APIModels;

namespace API_Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IRepository _repository;

        public APIController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("AllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var persons = await _repository.GetAll();
                return Ok(persons);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
            
        }

        [HttpGet("APersonsHobbies")]
        public async Task<IActionResult> GetAllHobbies(int id)
        {
            try {
                var hobbies = await _repository.GetPersonsHobbies(id);
                return Ok(hobbies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }

        [HttpGet("APersonsLinks")]
        public async Task<IActionResult> GetAllLinks(int id)
        {
            try
            {
                var links = _repository.GetPersonsLinks(id);
                return Ok(links);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }

        [HttpPost("AddnewHobby")]
        public async Task<IActionResult> AddnewHobby(int hHId, int PId)
        {
            try
            { 
                var result = await _repository.AddHobbytoPerson(hHId, PId);
                return Ok(result);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }

        [HttpPost("AddnewLink")]
        public async Task<IActionResult> AddnewLink(int PId, int HId, Link newLink)
        {
            try
            {
                var result = await _repository.AddHobbyandLink(PId, HId, newLink);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data from database");
            }
        }



        




















        //[HttpGet("{id:int}")]
        //public IActionResult GetPerson(int id)
        //{
        //    var result = _repository.GetById(id);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound($"Person with id {id} was not found");
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Person>> UpdatePerson(int id, Person pers)
        //{
        //    try
        //    {
        //        if (id != pers.PersonId)
        //        {
        //            return BadRequest("Unable to find a matching id");
        //        }
        //        var UpdatePerson = await _repository.GetById(id);

        //        if (UpdatePerson == null)
        //        {
        //            return NotFound($"Order with ID {id} not found");
        //        }
        //        return await _repository.Update(pers);

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error while trying to update");
        //    }
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Person>> DeletePerson(int id)
        //{
        //    try
        //    {
        //        var PersToDelete = await _repository.GetById(id);
        //        if (PersToDelete == null)
        //        {
        //            return NotFound($"Project with ID {id} was not found");
        //        }
        //        return await _repository.DeleteById(id);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Unable to delete data from database");
        //    }
        //}
        //[HttpPost]
        //public async Task<ActionResult<Person>> AddNewPerson(Person pers)
        //{
        //    try
        //    {
        //        if (pers == null)
        //        {
        //            return BadRequest();
        //        }
        //        var result = await _repository.Add(pers);

        //        return CreatedAtAction(nameof(GetPerson), new { id = result.PersonId}, result);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error while trying to add new project");
        //    }
        //}
    }
}
