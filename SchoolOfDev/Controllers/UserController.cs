using Microsoft.AspNetCore.Mvc;
using SchoolOfDev.Entities;
using SchoolOfDev.Services;

namespace SchoolOfDev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            return Ok(await _service.Create(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] User userIn, int id)
        {
            await _service.Update(userIn, id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}