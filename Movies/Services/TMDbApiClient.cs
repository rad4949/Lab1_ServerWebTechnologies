using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Movies.Models;

public class TMDbApiClient
{
    private readonly HttpClient _httpClient;
    private readonly TMDbApiSettings _apiSettings;

    public TMDbApiClient(HttpClient httpClient, IOptions<TMDbApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings.Value;
        _httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
    }

    public async Task<List<Movie>> GetPopularMovies()
    {
        var response = await _httpClient.GetAsync($"movie/popular?api_key={_apiSettings.ApiKey}&language={_apiSettings.Language}");

        if (response.IsSuccessStatusCode)
        {            
            var result = await response.Content.ReadFromJsonAsync<MovieResult>();
            return result?.Results;
        }

        throw new Exception($"Failed to retrieve popular movies: {response.ReasonPhrase}");
    }
}

public class TMDbApiSettings
{
    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
    public string Language { get; set; }
}

public class MovieResult
{
    public List<Movie> Results { get; set; }
}
