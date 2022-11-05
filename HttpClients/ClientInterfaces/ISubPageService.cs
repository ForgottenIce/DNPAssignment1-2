using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface ISubPageService {
    Task<SubPage> CreateAsync(SubPageCreationDto subPageToCreate);
    Task<SubPage> GetByIdAsync(string id);
}