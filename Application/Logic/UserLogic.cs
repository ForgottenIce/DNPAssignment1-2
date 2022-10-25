using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using System.Text.RegularExpressions;

namespace Application.Logic {
    public class UserLogic : IUserLogic {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao) {
            this.userDao = userDao;
        }

        public async Task<User> CreateAsync(UserCreationDto userToCreate) {
            User? existing = await userDao.GetByUsernameAsync(userToCreate.Username);
            if (existing != null) throw new Exception("Username is already taken"); //TODO: Make custom Exception

            ValidateData(userToCreate);
            User toCreate = new User {
                Username = userToCreate.Username,
                Password = userToCreate.Password,
            };

            User created = await userDao.CreateAsync(toCreate);
            return created;

        }

        public async Task<IEnumerable<User>> GetAsync() {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id) {
            User? user = await userDao.GetByIdAsync(id);
            if (user != null) return user;

            throw new Exception(); //TODO: Make ustom Exception
        }

        private static void ValidateData(UserCreationDto userCreationDto) {
            string username = userCreationDto.Username;
            if(Regex.Matches(username, "@\"[^A-Za-z_-]\"").Any()) {
                throw new Exception("Username contains invalid characters. Only letters, numbers, dashes and underscores are allowed"); //TODO: Make custom Exception
            }

            if (username.Length < 4) {
                throw new Exception("Username is too short. The minimum length is 4 characters"); //TODO: Make custom Exception
            }

            if (username.Length > 20) {
                throw new Exception("Username is too long. The maximum length is 20 characters"); //TODO: Make custom Exception
            }
        }
    }
}
