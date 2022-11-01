using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ISubPageLogic {
    Task<SubPage> CreateSubPageAsync(SubPageCreationDto subPageToCreate);
    Task<SubPage> GetSubPageByIdAsync(string id);
    Task<IEnumerable<SubPage>> GetAsync();
    Task<IEnumerable<Post>> GetPostsAsync();


}