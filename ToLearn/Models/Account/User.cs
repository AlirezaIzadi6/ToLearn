namespace ToLearn.Models.Account;

public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    public User(string email, string password, string token)
    {
        Email = email;
        Password = password;
        Token = token;
    }
}
