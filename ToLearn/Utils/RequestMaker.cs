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
            _client.DefaultRequestHeaders.Add("bearer", currentUser.Token);
        }
    }

    public string Get(string path)
    {
        return _client.GetAsync(path).Result.Content
            .ReadAsStringAsync().Result;
    }

    public string Post(string path, Object obj)
    {
        var response = _client.PostAsJsonAsync<Object>(path, obj);
        return response.Result.Content.ReadAsStringAsync().Result;
    }
}
