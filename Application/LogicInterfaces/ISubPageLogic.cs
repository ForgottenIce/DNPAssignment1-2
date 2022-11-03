using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ISubPageLogic {
    Task<SubPage> CreateAsync(SubPageCreationDto subPageToCreate);
    Task<SubPage> GetByIdAsync(string id);
    Task<IEnumerable<SubPage>> GetAsync();
    Task<IEnumerable<Post>> GetPostsAsync(string subPageId);


}