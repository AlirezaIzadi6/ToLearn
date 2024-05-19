using ToLearn.Utils;

namespace ToLearn.Forms.Account;

public partial class LoginForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public LoginForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private async void loginButton_Click(object sender, EventArgs e)
    {
        string email = emailTextBox.Text;
        string password = passwordTextBox.Text;
        await _accountManager.Login(email, password);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
