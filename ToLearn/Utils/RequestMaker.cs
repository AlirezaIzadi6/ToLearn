using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ToLearn.Models.Account;

namespace ToLearn.Utils;

public class RequestMaker
{
    private readonly HttpClient _client;

    public RequestMaker(User? currentUser = null)
    {
        _client = new HttpClient()
        {
            BaseAddress = new Uri("Https://localhost:7190/")
        };
        if (currentUser != null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer "+currentUser.Token);
        }
    }

    public async Task<string> Get(string path)
    {
        return await _client.GetAsync(path).Result.Content
            .ReadAsStringAsync();
    }

    public async Task<string> Post(string path, Object obj)
    {
        var response = await _client.PostAsJsonAsync<Object>(path, obj);
        return response.Content.ReadAsStringAsync().Result;
    }
}
