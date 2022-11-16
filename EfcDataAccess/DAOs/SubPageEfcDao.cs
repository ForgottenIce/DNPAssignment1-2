using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using shortid;
using shortid.Configuration;

namespace EfcDataAccess.DAOs;
public class SubPageEfcDao : ISubPageDao {
    private readonly DataContext _context;

    public SubPageEfcDao(DataContext context) {
        _context = context;
    }

    public async Task<SubPage> CreateAsync(SubPage subPage) {
        string newId = ShortId.Generate(new GenerationOptions(true, true, 12));
        subPage.Id = newId;
        subPage.Posts = new List<Post>();

        EntityEntry<SubPage> newSubPage = await _context.SubPages.AddAsync(subPage);
        await _context.SaveChangesAsync();
        return newSubPage.Entity;

    }

    public async Task<IEnumerable<SubPage>> GetAsync() {
        IEnumerable<SubPage> result = await _context.SubPages.Include(s => s.Owner).Include(s => s.Posts)
            .ThenInclude(p => p.Author).ToListAsync();
        return result;
    }

    public async Task<SubPage?> GetByIdAsync(string id) {
        SubPage? result = await _context.SubPages.Include(s => s.Owner).Include(s => s.Posts)
            .FirstOrDefaultAsync(s => s.Id == id);
        return result;
    }

    public async Task<SubPage?> GetByNameAsync(string name) {
        SubPage? result = await _context.SubPages
            .FirstOrDefaultAsync(s => s.Name.ToLower().Equals(name.ToLower()));
        return result;
    }

    public async Task<IEnumerable<Post>?> GetPostsAsync(string subPageId) {
        SubPage? subpage = await _context.SubPages.Include(s => s.Posts)
            .FirstOrDefaultAsync(s => s.Id.Equals(subPageId));
        return subpage?.Posts.AsEnumerable();
    }
}
