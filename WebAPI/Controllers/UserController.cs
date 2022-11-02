using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly IUserLogic userLogic;
        public UserController(IUserLogic userLogic) {
            this.userLogic = userLogic;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto) {
            try {
                User user = await userLogic.CreateAsync(dto);
                return Created($"/user/{user.Id}", user);
            }
            catch (InvalidUsernameException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync([FromRoute] string id) {
            try {
                User user = await userLogic.GetByIdAsync(id);
                return Ok(user);
            }
            catch (UserNotFoundException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetByUsernameAsync([FromQuery] string userName) { //TODO should be removed if not needed
            try {
                User user = await userLogic.GetByUserNameAsync(userName);
                return Ok(user);
            }
            catch (UserNotFoundException e) {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
