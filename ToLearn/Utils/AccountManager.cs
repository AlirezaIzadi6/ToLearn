﻿using System.Security.Policy;
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
            if (response.StatusCode != 200)
            {
                _form.ShowError(response);
                return false;
            }
            LoginResponse? loginResponse = JsonSerializer.Deserialize<LoginResponse>(response.Body);
            var newUser = new User(request.Email, request.Password, loginResponse.accessToken);
            SetCurrentUser(newUser);
            Config.SaveConfig<User>(newUser);
            _userIsLoggedIn = true;
            _form.ShowMessage($"Login successful. Welcome {_user.Email}", "Success");
            _form.Close();
            return true;
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
        try
        {
            if (response.StatusCode != 200)
            {
                _form.ShowError(response);
                return false;
            }
            _form.ShowMessage("Your account successfully created.", "Success");
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
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
            _form.ChangeEnabled(controlTags, (bool)_userIsLoggedIn);
            return (bool)_userIsLoggedIn;
        }
        User? user = GetCurrentUser();
        if (user == null)
        {
            _userIsLoggedIn = false;
            _form.ChangeEnabled(controlTags, false);
            return false;
        }

        var requestMaker = new RequestMaker(user);
        try
        {
            var response = await requestMaker.Get("manage/info");
            if (response.StatusCode != 200)
            {
                _userIsLoggedIn = false;
                _form.ChangeEnabled(controlTags, false);
                _form.ShowError(response);
                return false;
            }
            UserInfo? userInfo = JsonSerializer.Deserialize<UserInfo>(response.Body);
            _userIsLoggedIn = userInfo.email == null ? false : true;
            _form.ChangeEnabled(controlTags, (bool)_userIsLoggedIn);
            return (bool)_userIsLoggedIn;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error checking login");
            _form.ChangeEnabled(controlTags, false);
            return false;
        }
    }
}
