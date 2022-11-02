using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Logic;

public class SubPageLogic : ISubPageLogic {
    private readonly ISubPageDao subPageDao;
    private readonly IUserDao userDao;

    public SubPageLogic(ISubPageDao subPageDao, IUserDao userDao) {
        this.subPageDao = subPageDao;
        this.userDao = userDao;
    }

    public async Task<SubPage> CreateSubPageAsync(SubPageCreationDto subPageToCreate) {
        SubPage? existing = await subPageDao.GetByNameAsync(subPageToCreate.Name);
        if (existing != null)  throw new InvalidSubPageNameException("The sub page name is already taken");

        User? user = await userDao.GetByIdAsync(subPageToCreate.OwnerId);
        if (user == null) throw new UserNotFoundException($"No user with id \"{subPageToCreate.OwnerId}\" was found");

        SubPage subPage = new SubPage {
            Name = subPageToCreate.Name,
            Description = subPageToCreate.Description,
            Owner = user
        };

        //TODO The created subpage will return the owner with their password currently, which is not ideal. This needs to be fixed
        SubPage created = await subPageDao.CreateAsync(subPage);
        return created;
    }

    public async Task<IEnumerable<SubPage>> GetAsync() {
        return await subPageDao.GetAsync();
    }

    public async Task<IEnumerable<Post>> GetPostsAsync(string subPageId) {
        IEnumerable<Post>? posts = await subPageDao.GetPostsAsync(subPageId);
        //posts is only null if the subPage wasn't found. If the subPage exists and there are no posts, it will return an empty array
        if (posts == null) throw new SubPageNotFoundException($"SubPage with id \"{subPageId}\" does not exist");
        return posts;
    }

    public async Task<SubPage> GetSubPageByIdAsync(string id) {
        SubPage? subPage = await subPageDao.GetByIdAsync(id);
        if (subPage != null) return subPage;

        throw new SubPageNotFoundException();
    }
}