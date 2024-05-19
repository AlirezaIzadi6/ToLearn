using ToLearn.Forms.Account;

namespace ToLearn.Forms;

public partial class AccountForm_NotLoggedIn : CustomForm
{
    public AccountForm_NotLoggedIn()
    {
        InitializeComponent();
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        var loginForm = new LoginForm();
        this.Visible = false;
        loginForm.ShowDialog();
        this.Visible = true;
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
