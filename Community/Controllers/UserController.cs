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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            var user = await _userService.GetUserAsync();
            return Ok(_mapper.Map<List<UserDTO>>(user));
        }
        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            var u = await _userService.GetUserByIdAsync(id);
            if (u != null)
            {
                var us = _mapper.Map<UserDTO>(u);
                return Ok(us);
            }
            return NotFound();
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] User value)
        {
            var user = await _userService.GetUserByIdAsync(value.userId);
            if (user == null)
            {
                var users =_mapper.Map<User>(value);
                var u = await _userService.PostAsync(users);
                return Ok(u);
            }
            return Conflict();
        }
        [HttpPut("{id}")]
        public async Task< ActionResult> Put(int id, [FromBody] User value)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return BadRequest();
            }
            await _userService.UpdateUserAsync(id, user);
            return Ok();
        }

        // DELETE api/<DeliveryPersonController>/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return BadRequest();
            }

           await _userService.DeleteUserAsync(id);
            return Ok();
        }




    }
}
