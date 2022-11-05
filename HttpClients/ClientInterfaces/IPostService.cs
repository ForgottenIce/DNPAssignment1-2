using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService {
    Task<Post> CreateAsync(PostCreationDto postToCreate);
    Task CreateCommentAsync(CommentCreationDto commentToCreate, string parentPostId);
    Task<Post> GetByIdAsync(string postId);
}