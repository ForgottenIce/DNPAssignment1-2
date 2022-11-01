using Application.DaoInterfaces;
using Domain.Exceptions;
using Domain.Models;
using System.Xml.Linq;

namespace FileData.DAOs {
    public class SubPageDao : ISubPageDao {

        private readonly FileContext _context;

        public SubPageDao(FileContext context)
        {
            _context = context;
        }

        public Task<SubPage> CreateAsync(SubPage subPage) {
            if (_context.SubPages.FirstOrDefault(page => page.Name == subPage.Name) != null) {
                throw new InvalidSubPageNameException("The sub page name is already taken");
            }

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
            SubPage? subPage = _context.SubPages.FirstOrDefault(t => t.Name == name);
            return Task.FromResult(subPage);
        }
    }
}
