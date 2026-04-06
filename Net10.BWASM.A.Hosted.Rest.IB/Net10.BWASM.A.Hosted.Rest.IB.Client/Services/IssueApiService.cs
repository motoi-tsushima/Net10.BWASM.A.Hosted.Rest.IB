using Shared.Rest.IB.Dtos;
using System.Net.Http.Json;

namespace Net10.BWASM.A.Hosted.Rest.IB.Client.Services;

public class IssueApiService(HttpClient http)
{
    public async Task<List<IssueDto>> GetAllAsync()
        => await http.GetFromJsonAsync<List<IssueDto>>("api/issues") ?? [];

    public async Task<IssueDto?> GetByIdAsync(int id)
        => await http.GetFromJsonAsync<IssueDto>($"api/issues/{id}");

    public async Task<IssueDto?> CreateAsync(IssueCreateDto dto)
    {
        var response = await http.PostAsJsonAsync("api/issues", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IssueDto>();
    }

    public async Task<IssueDto?> UpdateAsync(int id, IssueUpdateDto dto)
    {
        var response = await http.PutAsJsonAsync($"api/issues/{id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IssueDto>();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/issues/{id}");
        response.EnsureSuccessStatusCode();
    }
}
