using System.Text.Json;
using ToLearn.Forms.Account;
using ToLearn.Models.Account;

namespace ToLearn.Utils;

public class AccountManager
{
    private readonly LoginForm _form;
    private User _user;

    public AccountManager(LoginForm form)
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

    public User GetCurrentUser()
    {
        return _user;
    }

    private void SetCurrentUser(User newUser)
    {
        _user = newUser;
    }
}
