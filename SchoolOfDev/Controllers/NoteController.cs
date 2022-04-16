using Microsoft.AspNetCore.Mvc;
using SchoolOfDev.Entities;
using SchoolOfDev.Services;

namespace SchoolOfDev.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Note Note)
        {
            return Ok(await _service.Create(Note));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Note NoteIn, int id)
        {
            await _service.Update(NoteIn, id);
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