using ToLearn.Forms.Account;
using ToLearn.Utils;

namespace ToLearn.Forms;

public partial class AccountForm_NotLoggedIn : CustomForm
{
    public AccountForm_NotLoggedIn()
    {
        InitializeComponent();
    }

    private async void loginButton_Click(object sender, EventArgs e)
    {
        var loginForm = new LoginForm();
        this.Visible = false;
        loginForm.ShowDialog();
        if (await new AccountManager(this).UserIsLoggedIn() != true)
        {
            Visible = true;
        }
        else
        {
            var accountForm = new AccountForm_LoggedIn();
            CloseForm();
            accountForm.ShowDialog();
        }
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        var registerForm = new RegisterForm();
        this.Visible = false;
        registerForm.ShowDialog();
        this.Visible = true;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
