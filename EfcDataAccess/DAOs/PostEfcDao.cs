using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using shortid;
using shortid.Configuration;

namespace EfcDataAccess.DAOs;
public class PostEfcDao : IPostDao {
    private readonly DataContext _context;

    public PostEfcDao(DataContext context) {
        _context = context;
    }

    public async Task<Post> CreateAsync(Post post, SubPage parentSubPage) {
        string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

        post.Id = newId;
        post.Comments = new List<Post>();

        SubPage parent = await _context.SubPages.Include(s => s.Posts).FirstAsync(p => p.Id == parentSubPage.Id);
        parent.Posts.Add(post);
        
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> CreateAsync(Post post, Post parentPost) {
        string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

        post.Id = newId;
        post.Comments = new List<Post>();

        Post parent = await _context.Posts.Include(p => p.Comments).FirstAsync(p => p.Id == parentPost.Id);
        parent.Comments.Add(post);
        
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> GetByIdAsync(string id) {
        Post? result = await _context.Posts.Include(p => p.Author)
            .Include(p => p.Comments).ThenInclude(c => c.Author)
            .FirstOrDefaultAsync(p => p.Id == id);
        return result;
    }

    public async Task<IEnumerable<Post>?> GetCommentsAsync(string parentPostId) {
        Post? post = await _context.Posts
            .Include(p => p.Comments).ThenInclude(c => c.Author)
            .FirstOrDefaultAsync(s => s.Id.Equals(parentPostId));
        return post?.Comments.AsEnumerable();
    }
}
