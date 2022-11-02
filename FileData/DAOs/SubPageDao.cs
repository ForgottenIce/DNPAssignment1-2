using Application.DaoInterfaces;
using Domain.Exceptions;
using Domain.Models;
using shortid.Configuration;
using shortid;
using System.Xml.Linq;

namespace FileData.DAOs {
    public class SubPageDao : ISubPageDao {

        private readonly FileContext _context;

        public SubPageDao(FileContext context)
        {
            _context = context;
        }

        public Task<SubPage> CreateAsync(SubPage subPage) {
            string newId = ShortId.Generate(new GenerationOptions(true, true, 12));
            subPage.Id = newId;
            subPage.Posts = new List<Post>();

            _context.SubPages.Add(subPage);
            _context.SaveChanges();

            return Task.FromResult(subPage);
        }

        public Task<IEnumerable<SubPage>> GetAsync() {
            IEnumerable<SubPage>  result = _context.SubPages.AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<SubPage?> GetByIdAsync(string id) {
            SubPage? subPage = _context.SubPages.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(subPage);
        }

        public Task<SubPage?> GetByNameAsync(string name) {
            SubPage? subPage = _context.SubPages.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(subPage);
        }

        public Task<IEnumerable<Post>?> GetPostsAsync(string subPageId) {
            IEnumerable<Post>? posts = _context.SubPages.FirstOrDefault(t => t.Id.Equals(subPageId))?.Posts.AsEnumerable();
            return Task.FromResult(posts);
        }
    }
}
