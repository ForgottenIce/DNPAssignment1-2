using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using HttpClients.ClientInterfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace HttpClients.ClientImplementations;

public class SubPageService : ISubPageService {
    private readonly HttpClient client;

    public SubPageService(HttpClient client) {
        this.client = client;
    }

    public async Task<SubPage> CreateAsync(SubPageCreationDto subPageToCreate) {
        HttpResponseMessage response = await client.PostAsJsonAsync("/subpage", subPageToCreate);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

        SubPage subPage = JsonSerializer.Deserialize<SubPage>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return subPage;
    }

    public async Task<IEnumerable<SubPage>> GetAsync() {
        HttpResponseMessage response = await client.GetAsync("/subPage");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) {
            throw new Exception(content);
        }
        IEnumerable<SubPage> subPages = JsonSerializer.Deserialize<IEnumerable<SubPage>>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return subPages;
    }

    public async Task<SubPage> GetByIdAsync(string id) {
        HttpResponseMessage response = await client.GetAsync($"/subPage/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
            throw new SubPageNotFoundException();
        }
        else if (!response.IsSuccessStatusCode) {
            throw new Exception(content);
        }

        SubPage subPage = JsonSerializer.Deserialize<SubPage>(content, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        })!;
        return subPage;
    }
}