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
        string email = userNameTextBox.Text;
        string password = passwordTextBox.Text;
        bool result = await _accountManager.Login(email, password);
        if (result == true)
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
