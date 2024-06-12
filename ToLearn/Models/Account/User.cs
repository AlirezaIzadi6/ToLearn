namespace ToLearn.Models.Account;

public class User
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    public User(string email, string userName, string password, string token)
    {
        Email = email;
        UserName = userName;
        Password = password;
        Token = token;
    }
}
