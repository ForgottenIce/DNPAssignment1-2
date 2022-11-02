using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic {
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao) {
        this.postDao = postDao;
    }

    public Task<Post> CreateAsync(PostCreationDto postToCreate) {
        throw new NotImplementedException();
    }

    public Task<Post> GetByIdAsync(string id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetCommentsAsync(Post parentPost) {
        throw new NotImplementedException();
    }
}