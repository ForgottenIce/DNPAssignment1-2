using Application.DaoInterfaces;
using Domain.Models;
using shortid;
using shortid.Configuration;

namespace FileData.DAOs {
    public class PostDao : IPostDao{
        private readonly FileContext _context;

        public PostDao(FileContext context)
        {
            _context = context;
        }

        public Task<Post> CreateAsync(Post post, SubPage parentSubPage) {
            string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

            post.Id = newId;
            post.Comments = new List<Post>();

            _context.Posts.Add(post);
            _context.SubPages.First(t => t.Id == parentSubPage.Id).Posts.Add(post);
            _context.SaveChanges();

            return Task.FromResult(post);
        }

        public Task<Post> CreateAsync(Post post, Post parentPost) {
            string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

            post.Id = newId;
            post.Comments = new List<Post>();

            _context.Posts.Add(post);
            _context.Posts.First(t => t.Id == parentPost.Id).Comments.Add(post);
            _context.SaveChanges();

            return Task.FromResult(post);
        }

        public Task<Post?> GetByIdAsync(string id) {
            Post? post = _context.Posts.FirstOrDefault(post => post.Id == id);
            return Task.FromResult(post);
        }

        public Task<IEnumerable<Post>?> GetCommentsAsync(string parentPostId) {
            IEnumerable<Post>? comments = _context.Posts.FirstOrDefault(t => t.Id.Equals(parentPostId))?.Comments.AsEnumerable();
            return Task.FromResult(comments);
        }
    }
}
