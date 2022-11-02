using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase {

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto) {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] string id) {
        throw new NotImplementedException();
    }

    [HttpGet("{id}/comments")]
    public async Task<ActionResult<IEnumerable<Post>>> GetCommentsAsync([FromRoute] string id) {
        throw new NotImplementedException();
    }
}
