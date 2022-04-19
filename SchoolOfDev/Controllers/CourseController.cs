using Microsoft.AspNetCore.Mvc;
using SchoolOfDev.Authorization;
using SchoolOfDev.DTO.Course;
using SchoolOfDev.Enuns;
using SchoolOfDev.Services;

namespace SchoolOfDev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _service;

        public CourseController(ICourseService service)
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
        public async Task<IActionResult> Create([FromBody] CourseRequest Course)
        {
            return Ok(await _service.Create(Course));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CourseRequest CourseIn, int id)
        {
            await _service.Update(CourseIn, id);
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