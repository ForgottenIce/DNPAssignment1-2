using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace HttpClients.ClientImplementations;

public class UserService : IUserService {
    private readonly HttpClient client;

    public UserService(HttpClient client) {
        this.client = client;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate) {
        HttpResponseMessage response = await client.PostAsJsonAsync("/user", userToCreate);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
}