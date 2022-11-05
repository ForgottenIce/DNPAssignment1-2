using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using HttpClients.ClientInterfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace HttpClients.ClientImplementations;

public class PostService : IPostService {
    private readonly HttpClient client;

    public PostService(HttpClient client) {
        this.client = client;
    }

    public async Task<Post> CreateAsync(PostCreationDto postToCreate) {
        HttpResponseMessage response = await client.PostAsJsonAsync("/post", postToCreate);
        string content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode) {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task CreateCommentAsync(CommentCreationDto commentToCreate, string parentPostId) {
        HttpResponseMessage response = await client.PostAsJsonAsync($"/post/{parentPostId}/comment", commentToCreate);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }
    }

    public async Task<Post> GetByIdAsync(string postId) {
        HttpResponseMessage response = await client.GetAsync($"/post/{postId}");
        string content = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
            throw new PostNotFoundException();
        }
        else if (!response.IsSuccessStatusCode) {
            throw new Exception(content);
        }

        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}