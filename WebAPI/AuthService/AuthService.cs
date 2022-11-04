using Domain.Models;
using FileData.DAOs;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.AuthService;

public class AuthService : IAuthService{
    
    private readonly UserDao userDao;

    public AuthService(UserDao dao) {
        this.userDao = dao;
    }

    public async Task<User> ValidateUser(string username, string password) //TODO implement proper exceptions
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);

        if (existingUser == null) {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password)) {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public Task RegisterUser(User user) //TODO implement proper exceptions
    {

        if (string.IsNullOrEmpty(user.Username)) {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password)) {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here

        // save to persistence instead of list

        userDao.CreateAsync(user);

        return Task.CompletedTask;
    }
}
