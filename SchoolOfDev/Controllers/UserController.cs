using Microsoft.AspNetCore.Mvc;
using SchoolOfDev.Authorization;
using SchoolOfDev.DTO.User;
using SchoolOfDev.Services;

namespace SchoolOfDev.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest user)
        {
            return Ok(await _service.Create(user));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest user)
        {
            return Ok(await _service.Authenticate(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UserRequestUpdate userIn, int id)
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