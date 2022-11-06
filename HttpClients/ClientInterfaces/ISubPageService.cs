using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ISubPageService {
    Task<SubPage> CreateAsync(SubPageCreationDto subPageToCreate);
    Task<IEnumerable<SubPage>> GetAsync();
    Task<SubPage> GetByIdAsync(string id);
}