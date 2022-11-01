using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic {
    Task<IEnumerable<Post>> GetCommentsAsync(Post parentPost);
}