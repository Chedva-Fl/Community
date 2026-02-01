using AutoMapper;
using Community.core.DTO;
using Community.core.Models;
using Community.core.Serivecs;
using Community.Service;
using Microsoft.AspNetCore.Mvc;


namespace Community.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            var teacher =await _teacherService.GetTeachersAsync();

            return Ok(_mapper.Map<List<TeacherDTO>>(teacher));
        }
        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            var t = await _teacherService.GetTeacherByIdAsync(id);
            if (t != null)
            {
                var te = _mapper.Map<TeacherDTO>(t);
                return Ok(te);
            }
            return NotFound();
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task< ActionResult >Post([FromBody] Teacher value)
        {
            var teacher =await _teacherService.GetTeacherByIdAsync(value.teacherId);
            if (teacher == null)
            {
                var student = _mapper.Map<Teacher>(value);
                var t = await _teacherService.AddTeacherAsync(teacher);
                return Ok(t);
            }

            return Conflict();


        }
        [HttpPut("{id}")]
        public async Task< ActionResult> Put(int id, [FromBody] Teacher value)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return BadRequest();
            }
           await _teacherService.UpdateTeacherAsync(id, teacher);
            return Ok();

        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return BadRequest();
            }

           await _teacherService.DeleteTeacherAsync(id);
            return Ok();
        }
    }


}