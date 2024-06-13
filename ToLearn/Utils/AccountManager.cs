using System.Security.Policy;
using System.Text.Json;
using ToLearn.Forms;
using ToLearn.Forms.Account;
using ToLearn.Models.Account;
using ToLearn.Models.RequestMaker;

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

    public async Task<bool> Login(string userName, string password)
    {
        var request = new Request()
        {
            Email = userName,
            Password = password
        };
        var result = await MakeRequest<Request>(200, "login", "Post", request);
        if (result.Success)
        {
            LoginResponse? loginResponse = JsonSerializer.Deserialize<LoginResponse>(result.Body);
            var newUser = new User("", userName, password, loginResponse.accessToken);
            SetCurrentUser(newUser);
            Config.SaveConfig<User>(newUser);
            _userIsLoggedIn = true;
            return true;
        }
        return false;
    }

    public async Task<bool> Register(string email, string userName, string password)
    {
        var request = new Request()
        {
            Email = email,
            userName = userName,
            Password = password
        };
        var result = await MakeRequest<Request>(200, "register", "Post", request, "Your account created successfully.");
        return result.Success;
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

    public async Task<bool?> UserIsLoggedIn()
    {
        if (_userIsLoggedIn != null)
        {
            return _userIsLoggedIn;
        }
        User? user = GetCurrentUser();
        if (user == null)
        {
            _userIsLoggedIn = false;
            return false;
        }

        try
        {
            var result = await MakeRequest<int?>(200, "manage/info", "Get", null);
            if (!result.Success)
            {
                _userIsLoggedIn = false;
                return false;
            }
            UserInfo? userInfo = JsonSerializer.Deserialize<UserInfo>(result.Body);
            _userIsLoggedIn = (userInfo.email != null);
            return _userIsLoggedIn;
        }
        catch
        {
            return false;
        }
    }

    private async Task<FlashcardsResponse> MakeRequest<T>(int successCode, string path, string method, T? obj, string? successMessage = null)
    {
        FlashcardsResponse result = new();
        var requestMaker = new RequestMaker(GetCurrentUser());
        var controls = _form.GetControls();
        _form.ChangeEnabled(controls, false);
        try
        {
            Response response = null;
            switch (method)
            {
                case "Get":
                    response = await requestMaker.Get(path);
                    break;
                case "Post":
                    response = await requestMaker.Post(path, obj);
                    break;
                case "Put":
                    response = await requestMaker.Put(path, obj);
                    break;
                case "Delete":
                    response = await requestMaker.Delete(path);
                    break;
            }
            if (response.StatusCode != successCode)
            {
                result.Success = false;
                _form.ShowError(response);
            }
            else
            {
                result.Success = true;
                result.Body = response.Body;
                if (successMessage != null)
                {
                    _form.ShowMessage(successMessage, "Success");
                }
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            _form.ShowMessage(ex.Message, "An error occurred");
        }
        _form.ChangeEnabled(controls, true);
        return result;
    }
}
