using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ISubPageLogic {
    Task<SubPage> CreateAsync(SubPageCreationDto subPageToCreate); //Todo rename method
    Task<SubPage> GetByIdAsync(string id);
    Task<IEnumerable<SubPage>> GetAsync();
    Task<IEnumerable<Post>> GetPostsAsync(string subPageId);


}