using Domain.Models;

namespace WebAPI.AuthService;

public interface IAuthService {
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}
