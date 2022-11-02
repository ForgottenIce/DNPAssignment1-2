using Domain.Models;

namespace Application.DaoInterfaces {
    public interface ISubPageDao {
        Task<SubPage> CreateAsync(SubPage subPage);
        Task<IEnumerable<SubPage>> GetAsync();
        Task<SubPage?> GetByNameAsync(string name);
        Task<SubPage?> GetByIdAsync(string id);
        Task<IEnumerable<Post>?> GetPostsAsync(string subPageId);
    }
}
