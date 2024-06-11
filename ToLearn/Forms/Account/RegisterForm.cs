using ToLearn.Utils;

namespace ToLearn.Forms.Account;

public partial class RegisterForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public RegisterForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private async void registerButton_Click(object sender, EventArgs e)
    {
        string email = emailTextBox.Text;
        string userName = userNameTextBox.Text;
        string password = passwordTextBox.Text;
        await _accountManager.Register(email, userName, password);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
