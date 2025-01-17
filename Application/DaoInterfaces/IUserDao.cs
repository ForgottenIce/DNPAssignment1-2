﻿using Domain.Models;

namespace Application.DaoInterfaces {
    public interface IUserDao {
        Task<User> CreateAsync(User user);
        Task<User?> GetByIdAsync(string id);
        Task<User?> GetByUsernameAsync(string userName);
    }
}
