using Domain.Models;

namespace Application.DaoInterfaces {
    public interface ISubPageDao {
        Task<SubPage> CreateAsync(SubPage subPage);
        Task<IEnumerable<SubPage>> GetAsync();
        Task<SubPage> GetByNameAsync(string name);

    }
}
