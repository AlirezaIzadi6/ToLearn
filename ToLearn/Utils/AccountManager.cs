using System.Text.Json;
using ToLearn.Forms;
using ToLearn.Forms.Account;
using ToLearn.Models.Account;

namespace ToLearn.Utils;

public class AccountManager
{
    private readonly ICustomForm _form;
    private static User _user;

    public AccountManager(ICustomForm form)
    {
        _form = form;
    }

    public bool Login(string email, string password)
    {
        var request = new Request()
        {
            Email = email,
            Password = password
        };
        var requestMaker = new RequestMaker();
        var response = requestMaker.Post("login", request);
        LoginResponse? loginResponse = JsonSerializer.Deserialize<LoginResponse>(response);
        if (loginResponse?.accessToken != null)
        {
            var newUser = new User()
            {
                Email = request.Email,
                Password = request.Password,
                Token = loginResponse.accessToken
            };
            SetCurrentUser(newUser);
            _form.ShowMessage($"Login successful. Welcome {_user.Email}");
            _form.Close();
            return true;
        }
        else
        {
            _form.ShowMessage($"An error occurred.");
            return false;
        }
    }

    public bool Register(string email, string password)
    {
        var request = new Request()
        {
            Email = email,
            Password = password
        };
        var requestMaker = new RequestMaker();
        var response = requestMaker.Post("register", request);
        RegisterResponse registerResponse = JsonSerializer.Deserialize<RegisterResponse>(response);
        _form.ShowMessage(response);
        return true;
    }

    public static User GetCurrentUser()
    {
        return _user;
    }

    private static void SetCurrentUser(User newUser)
    {
        _user = newUser;
    }
}
