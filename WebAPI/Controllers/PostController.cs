using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic) {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto) {
        try {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/post/{post.Id}", post);
        }
        catch (UserNotFoundException e) {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
        catch (SubPageNotFoundException e) {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("{id}/comment")]
    public async Task<ActionResult<Post>> CreateCommentAsync(CommentCreationDto dto, [FromRoute] string id) {
        try {
            Post post = await postLogic.CreateAsync(dto, id);
            return Created($"/post/{post.Id}", post);
        }
        catch (UserNotFoundException e) {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
        catch (PostNotFoundException e) {
            Console.WriteLine(e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] string id) {
        try {
            Post post = await postLogic.GetByIdAsync(id);
            return Ok(post);
        }
        catch (PostNotFoundException e) {
            Console.WriteLine(e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}/comments")]
    public async Task<ActionResult<IEnumerable<Post>>> GetCommentsAsync([FromRoute] string id) {
        throw new NotImplementedException();
    }
}
