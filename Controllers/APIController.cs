using API_Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using APIModels;
using API_Lab4.DTO;

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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }            
        }

        [HttpGet("APersonsHobbies")]
        public async Task<IActionResult> GetAllHobbies(int id)
        {
            try {
                var hobbies = await _repository.GetPersonsHobbies(id);
                return Ok(hobbies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("APersonsLinks")]
        public async Task<IActionResult> GetAllLinks(int id)
        {
            try
            {
                var links = await _repository.GetPersonsLinks(id);
                return Ok(links);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("AddnewHobby")]
        public async Task<IActionResult> AddnewHobby( PersonHobbyDTO entity)
        {
            try
            {
                var result = new PersonHobbyLink();
                result.PersonID = entity.PersonId;
                result.HobbyId = entity.HobbyId;
                
                     
                await _repository.AddHobbytoPerson(result);
                return Ok("Hobby was added to person");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("AddnewLink")]
        public async Task<IActionResult> AddnewLink(int PId, int HId, string url)
        {
            try
            {
                var result = await _repository.AddLink(PId, HId, url);
                return Ok("A new link was added and connected to person");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
