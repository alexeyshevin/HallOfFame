using HallOfFame.Interfaces;
using HallOfFame.Models;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class HallOfFameController : ControllerBase
    {
        private readonly IHallOfFameService _service;
        public HallOfFameController(IHallOfFameService service)
        {
            _service = service;
        }

        [Route("persons")]
        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetAllPersons()
        {
            try
            {
                return await _service.GetPersons();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [Route("persons/{id}")]
        [HttpGet]
        public async Task<PersonModel> GetPersonById(int id)
        {
            try
            {
                return await _service.GetPersonById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [Route("persons/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody]PersonModel person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdatePerson(person);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [Route("persons")]
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonModel newPerson)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await _service.CreatePerson(newPerson);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        [Route("persons/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.DeletePerson(id);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}