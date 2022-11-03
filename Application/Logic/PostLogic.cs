using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic {
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;
    private readonly ISubPageDao subPageDao;

    public PostLogic(IPostDao postDao, IUserDao userDao, ISubPageDao subPageDao) {
        this.postDao = postDao;
        this.userDao = userDao;
        this.subPageDao = subPageDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postToCreate) {
        User? user = await userDao.GetByIdAsync(postToCreate.AuthorId);
        if (user == null) throw new UserNotFoundException($"User with id \"{postToCreate.AuthorId}\" was not found");

        SubPage? subPage = await subPageDao.GetByIdAsync(postToCreate.SubPageId);
        if (subPage == null) throw new SubPageNotFoundException($"SubPage with id \"{postToCreate.SubPageId}\" was not found");

        Post post = new Post {
            Title = postToCreate.Title,
            Body = postToCreate.Body,
            Author = user
        };
        Post created = await postDao.CreateAsync(post, subPage);
        return created;
    }

    public async Task<Post> CreateAsync(CommentCreationDto commentToCreate, string parentPostId) {
        User? user = await userDao.GetByIdAsync(commentToCreate.AuthorId);
        if (user == null) throw new UserNotFoundException($"User with id \"{commentToCreate.AuthorId}\" was not found");

        Post? parentPost = await postDao.GetByIdAsync(parentPostId);
        if (parentPost == null) throw new PostNotFoundException($"Parent post with id \"{parentPostId}\" was not found");

        Post post = new Post {
            Body = commentToCreate.Body,
            Author = user
        };
        Post created = await postDao.CreateAsync(post, parentPost);
        return created;
    }

    public async Task<Post> GetByIdAsync(string id) {
        Post? post = await postDao.GetByIdAsync(id);
        if (post != null) return post;

        throw new PostNotFoundException($"Post with id \"{id}\" was not found");
    }

    public async Task<IEnumerable<Post>> GetCommentsAsync(string parentPostId) {
        IEnumerable<Post>? comments = await postDao.GetCommentsAsync(parentPostId);
        //comments is only null if the parent post wasn't found. If the parent post exists and there are no comments, it will return an empty array
        if (comments == null) throw new PostNotFoundException($"Parent post with id \"{parentPostId}\" does not exist");
        return comments;
    }
}