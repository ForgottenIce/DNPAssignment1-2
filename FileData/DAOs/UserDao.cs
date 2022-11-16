using Application.DaoInterfaces;
using Domain.Models;
using shortid;
using shortid.Configuration;

namespace FileData.DAOs {
    [Obsolete("class has been replaced with UserEfcDao",true)]
    public class UserDao : IUserDao {
        private readonly FileContext _context;

        public UserDao(FileContext context) {
            _context = context;
        }

        public Task<User> CreateAsync(User user) {
            string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

            user.Id = newId;
            user.SubscribedSubs = new List<SubPage>();
            user.LikedPosts = new List<Post>();
            user.DislikedPosts = new List<Post>();

            _context.Users.Add(user);
            _context.SaveChanges();

            return Task.FromResult(user);
        }

        public Task<User?> GetByIdAsync(string id) {
            User? existing = _context.Users.FirstOrDefault(u =>
                u.Id.Equals(id)
            );

            return Task.FromResult(existing);
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            User? existing = _context.Users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
            );

            return Task.FromResult(existing);
        }


    }
}
