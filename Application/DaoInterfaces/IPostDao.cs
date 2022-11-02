using Domain.Models;

namespace Application.DaoInterfaces {
    public interface IPostDao {
        Task<Post> CreateAsync(Post post);
        Task<Post?> GetByIdAsync(string id);
        Task<IEnumerable<Post>?> GetCommentsAsync(string postId);
    }
}
