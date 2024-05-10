using System.Security.Policy;
using System.Text.Json;
using ToLearn.Forms;
using ToLearn.Forms.Account;
using ToLearn.Models.Account;

namespace ToLearn.Utils;

public class AccountManager
{
    private readonly ICustomForm _form;
    private static User? _user;
    private static bool? _userIsLoggedIn;

    public AccountManager(ICustomForm form)
    {
        _form = form;
    }

    public async Task<bool> Login(string email, string password)
    {
        var request = new Request()
        {
            Email = email,
            Password = password
        };
        var requestMaker = new RequestMaker();
        try
        {
            var response = await requestMaker.Post("login", request);
            LoginResponse? loginResponse = JsonSerializer.Deserialize<LoginResponse>(response);
            if (loginResponse?.accessToken != null)
            {
                var newUser = new User(request.Email, request.Password, loginResponse.accessToken);
                SetCurrentUser(newUser);
                Config.SaveConfig<User>(newUser);
                _userIsLoggedIn = true;
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
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> Register(string email, string password)
    {
        var request = new Request()
        {
            Email = email,
            Password = password
        };
        var requestMaker = new RequestMaker();
        var response = await requestMaker.Post("register", request);
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

    public void Logout()
    {
        SetCurrentUser(null);
        _userIsLoggedIn = false;
        Config.DeleteConfig<User>();
    }

    public static User? GetCurrentUser()
    {
        return _user;
    }

    private static void SetCurrentUser(User? newUser)
    {
        _user = newUser;
    }

    public static void LoadUser()
    {
        try
        {
            var user = Config.GetConfig<User>();
            if (user != null)
            {
                SetCurrentUser(user);
            }
        }
        catch { }
    }

    public async Task<bool> UserIsLoggedIn(List<string> controlTags = null)
    {
        if (controlTags == null)
        {
            controlTags = new List<string>();
        }

        if (_userIsLoggedIn != null)
        {
            _form.ChangeVisibility(controlTags, (bool)_userIsLoggedIn);
            return (bool)_userIsLoggedIn;
        }
        User? user = GetCurrentUser();
        if (user == null)
        {
            _userIsLoggedIn = false;
            _form.ChangeVisibility(controlTags, false);
            return false;
        }

        var requestMaker = new RequestMaker(user);
        try
        {
            var response = await requestMaker.Get("manage/info");
            UserInfo? userInfo = JsonSerializer.Deserialize<UserInfo>(response);
            _userIsLoggedIn = userInfo.email == null ? false : true;
            _form.ChangeVisibility(controlTags, (bool)_userIsLoggedIn);
            return (bool)_userIsLoggedIn;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error checking login");
            _form.ChangeVisibility(controlTags, false);
            return false;
        }
    }
}
