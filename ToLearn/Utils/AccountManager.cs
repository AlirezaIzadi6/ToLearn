using System.Text.Json;
using ToLearn.Forms.Account;
using ToLearn.Models.Account;

namespace ToLearn.Utils;

public class AccountManager
{
    public static bool Login(string email, string password)
    {
        var request = new Request()
        {
            Email = email,
            Password = password
        };
        var requestMaker = new RequestMaker();
        var response = requestMaker.Post("login", request);
        try
        {
            LoginResponse loginResponse = JsonSerializer.Deserialize<LoginResponse>(response);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
