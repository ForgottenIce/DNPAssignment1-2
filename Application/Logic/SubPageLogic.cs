using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Logic;

public class SubPageLogic : ISubPageLogic {
    private readonly ISubPageDao subPageDao;
    private readonly IPostDao postDao;

    public SubPageLogic(ISubPageDao subPageDao, IPostDao postDao) {
        this.subPageDao = subPageDao;
        this.postDao = postDao;
    }

    public async Task<SubPage> CreateSubPageAsync(SubPageCreationDto subPageToCreate) {
        SubPage? existing = await subPageDao.GetByNameAsync(subPageToCreate.Name);

        if (existing != null)   throw new InvalidSubPageNameException("The sub page name is already taken");


        SubPage subPage = new SubPage {
            Name = subPageToCreate.Name,
            Description = subPageToCreate.Description,
            Owner = subPageToCreate.Owner
        };

        SubPage created = await subPageDao.CreateAsync(subPage);
        return created;
    }

    public async Task<IEnumerable<SubPage>> GetAsync() {
        return await subPageDao.GetAsync();
    }

    public async Task<IEnumerable<Post>> GetPostsAsync() {
        throw new NotImplementedException();
    }

    public async Task<SubPage> GetSubPageByIdAsync(string id) {
        SubPage? subPage = await subPageDao.GetByIdAsync(id);
        if (subPage != null) return subPage;

        throw new SubPageNotFoundException();
    }
}