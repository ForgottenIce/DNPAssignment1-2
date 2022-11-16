using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using shortid;
using shortid.Configuration;

namespace EfcDataAccess.DAOs;
public class UserEfcDao : IUserDao {
    private readonly DataContext _context;

    public UserEfcDao(DataContext context) {
        _context = context;
    }

    public async Task<User> CreateAsync(User user) {
        string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

        user.Id = newId;
        user.SubscribedSubs = new List<SubPage>();
        user.LikedPosts = new List<Post>();
        user.DislikedPosts = new List<Post>();

        EntityEntry<User> newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByIdAsync(string id) {
        User? existing = await _context.Users.FindAsync(id);
        return existing;
    }

    public async Task<User?> GetByUsernameAsync(string userName) {
        User? existing = await _context.Users.FirstOrDefaultAsync(u =>
                u.Username.ToLower().Equals(userName.ToLower())
        );

        return existing;
    }
}
