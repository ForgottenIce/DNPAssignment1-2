using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs {
    public class SubPageDao : ISubPageDao {

        private readonly FileContext _context;

        public SubPageDao(FileContext context)
        {
            _context = context;
        }

        public Task<SubPage> CreateAsync(SubPage subPage) {
            if (_context.SubPages.FirstOrDefault(page => page.Name == subPage.Name) != null) {
                throw new Exception();
            }

            _context.SubPages.Add(subPage);
            _context.SaveChanges();

            return Task.FromResult(subPage);
        }

        public Task<IEnumerable<SubPage>> GetAsync() {
            IEnumerable<SubPage>  result = _context.SubPages.AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<SubPage> GetByNameAsync(string name) {
            SubPage subPage = _context.SubPages.FirstOrDefault(t => t.Name == name);
            return Task.FromResult(subPage);
        }
    }
}
