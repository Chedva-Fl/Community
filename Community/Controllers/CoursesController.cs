using AutoMapper;
using Community.core.DTO;
using Community.core.Models;
using Community.core.Serivecs;
using Microsoft.AspNetCore.Mvc;


namespace Community.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;
        private readonly IMapper _mapper;
        public CoursesController(ICoursesService coursesService, IMapper mapper)
        {
            _coursesService = coursesService;
            _mapper = mapper;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var course = await _coursesService.GetCoursesAsync();
            return Ok(_mapper.Map<List<CoursesDTO>>(course));
        }
        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var c = await _coursesService.GetCourseByIdAsync(id);
            if (c != null)
            {
                var cu = _mapper.Map<CoursesDTO>(c);
                return Ok(cu);
            }
            return NotFound();
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Courses value)
        {
            var course = await _coursesService.GetCourseByIdAsync(value.coursId);
            if (course == null)
            {
                var corse = _mapper.Map<Courses>(value);
                var c = await _coursesService.AddCourseAsync(corse);
                return Ok(c);
            }
            return Conflict();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Courses value)
        {
            var course = await _coursesService.GetCourseByIdAsync(id);
            if (course == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return BadRequest();
            }
             await _coursesService.UpdateCourseAsync(id, course);
            return Ok();

        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var course = await _coursesService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return BadRequest();
            }

            await _coursesService.DeleteCourseAsync(id);
            return Ok();
        }
    }

}


