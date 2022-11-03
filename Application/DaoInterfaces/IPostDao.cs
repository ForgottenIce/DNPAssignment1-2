using Domain.Models;

namespace Application.DaoInterfaces {
    public interface IPostDao {
        Task<Post> CreateAsync(Post post, SubPage parentSubPage);
        Task<Post> CreateAsync(Post post, Post parentPost);
        Task<Post?> GetByIdAsync(string id);
        Task<IEnumerable<Post>?> GetCommentsAsync(string parentPostId);
    }
}
