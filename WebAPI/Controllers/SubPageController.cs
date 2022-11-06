using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SubPageController : ControllerBase {
        private readonly ISubPageLogic subPageLogic;

        public SubPageController(ISubPageLogic subPageLogic) {
            this.subPageLogic = subPageLogic;
        }

        [HttpPost]
        public async Task<ActionResult<SubPage>> CreateAsync(SubPageCreationDto dto) {
            try {
                SubPage subPage = await subPageLogic.CreateAsync(dto);
                return Created($"/subpage/{subPage.Id}", subPage);
            }
            catch (InvalidSubPageNameException e) {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e) {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubPage>>> GetAsync() {
            try {
                IEnumerable<SubPage> subPages = await subPageLogic.GetAsync();
                return Ok(subPages);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubPage>> GetByIdAsync([FromRoute] string id) {
            try {
                SubPage subPage = await subPageLogic.GetByIdAsync(id);
                return Ok(subPage);
            }
            catch (SubPageNotFoundException e) {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsAsync([FromRoute] string id) {
            try {
                IEnumerable<Post> posts = await subPageLogic.GetPostsAsync(id);
                return Ok(posts);
            }
            catch (SubPageNotFoundException e) {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
