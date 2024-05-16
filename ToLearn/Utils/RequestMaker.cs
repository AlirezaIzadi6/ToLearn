using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ToLearn.Models.Account;
using ToLearn.Models.RequestMaker;

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

    public async Task<Response> Get(string path)
    {
        var result = await _client.GetAsync(path);
        var response = new Response()
        {
            StatusCode = (int)result.StatusCode,
            Body = result.Content.ReadAsStringAsync().Result
        };
        return response;
    }

    public async Task<Response> Post(string path, Object obj)
    {
        var result = await _client.PostAsJsonAsync<Object>(path, obj);
        var response = new Response()
        {
            StatusCode = (int)result.StatusCode,
            Body = result.Content.ReadAsStringAsync().Result
        };
        return response;
    }

    public async Task<Response> Put(string path, Object obj)
    {
        var result = await _client.PutAsJsonAsync<Object>(path, obj);
        var response = new Response()
        {
            StatusCode = (int)result.StatusCode,
            Body = result.Content.ReadAsStringAsync().Result
        };
        return response;
    }
}
