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
            Config.SaveConfig<User>(newUser);
            _form.ShowMessage($"Login successful. Welcome {_user.Email}", "Success");
            _form.Close();
            return true;
        }
        else
        {
            _form.ShowMessage($"An error occurred.", "Failed");
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
        if (response == string.Empty)
        {
            _form.ShowMessage("Your account successfully created.", "Success");
            return true;
        }
        else
        {
            _form.ShowMessage("registration was unsuccessful", "Failed");
            return false;
        }
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
