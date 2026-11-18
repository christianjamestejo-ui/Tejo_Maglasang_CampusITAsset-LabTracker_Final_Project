
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace MT_Campus_IT_Asset___Lab_TrackerConsole.API;

public class AssetApiClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public AssetApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CampusAsset>> GetAllAssets()
    {
        return await _httpClient.GetFromJsonAsync<List<CampusAsset>>(
            "api/assets", _options) ?? new();
    }

    public async Task<CampusAsset?> GetAsset(string id)
    {
        var response = await _httpClient.GetAsync(
            $"api/assets/{Uri.EscapeDataString(id)}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CampusAsset>(
            _options);
    }


    public async Task<bool> RegisterAsset(CampusAsset asset)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/assets",
            asset,
            _options
        );

        string responseBody =
            await response.Content.ReadAsStringAsync();

        Console.WriteLine("\n========== REGISTRATION RESPONSE ==========");
        Console.WriteLine($"Status Code: {(int)response.StatusCode}");
        Console.WriteLine($"Response: {responseBody}");
        Console.WriteLine("============================================");

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return true;
    }


    public async Task<bool> DeleteAsset(string id)
    {
        var response = await _httpClient.DeleteAsync(
            $"api/assets/{Uri.EscapeDataString(id)}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return false;

        response.EnsureSuccessStatusCode();

        return true;
    }
}