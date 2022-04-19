using Microsoft.AspNetCore.Mvc;
using SchoolOfDev.Authorization;
using SchoolOfDev.DTO.Note;
using SchoolOfDev.Enuns;
using SchoolOfDev.Services;

namespace SchoolOfDev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {

        private readonly INoteService _service;

        public NoteController(INoteService service)
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

        [Authorize(TypeUser.Teacher, TypeUser.Both)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NoteRequest Note)
        {
            return Ok(await _service.Create(Note));
        }

        [Authorize(TypeUser.Teacher, TypeUser.Both)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] NoteRequest NoteIn, int id)
        {
            await _service.Update(NoteIn, id);
            return NoContent();
        }

        [Authorize(TypeUser.Teacher, TypeUser.Both)]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}