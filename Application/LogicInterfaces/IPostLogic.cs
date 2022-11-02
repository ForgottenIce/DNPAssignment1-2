using Domain.Models;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic {
    Task<Post> CreateAsync(PostCreationDto postToCreate);
    Task<Post> GetByIdAsync(string id);
    Task<IEnumerable<Post>> GetCommentsAsync(Post parentPost);
}