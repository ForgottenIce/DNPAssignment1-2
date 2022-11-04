using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebAPI.AuthService;

public class AuthLogic : IAuthLogic{
    
    private readonly IUserDao userDao;

    public AuthLogic(IUserDao userDao) {
        this.userDao = userDao;
    }

    public async Task<User> ValidateUser(string username, string password) //TODO implement proper exceptions
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);

        if (existingUser == null) {
            throw new Exception("User not found");
        }

        if (!existingUser.HashedPassword.Equals(password)) {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public Task RegisterUser(User user) //TODO implement proper exceptions
    {

        if (string.IsNullOrEmpty(user.Username)) {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.HashedPassword)) {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here

        // save to persistence instead of list

        userDao.CreateAsync(user);

        return Task.CompletedTask;
    }
}
