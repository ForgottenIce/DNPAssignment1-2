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

        public Task<Post> CreateAsync(Post post) {
            string newId = ShortId.Generate(new GenerationOptions(true, true, 12));

            post.Id = newId;
            post.Comments = new List<Post>();

            _context.Posts.Add(post);
            _context.SaveChanges();

            return Task.FromResult(post);
        }

        public Task<Post?> GetByIdAsync(string id) {
            Post? post = _context.Posts.SingleOrDefault(post => post.Id == id);
            return Task.FromResult(post);
        }

        public Task<IEnumerable<Post>?> GetCommentsAsync(string postId) {
            throw new NotImplementedException();
        }
    }
}
