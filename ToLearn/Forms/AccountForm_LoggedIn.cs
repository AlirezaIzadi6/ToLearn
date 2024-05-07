using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLearn.Utils;

namespace ToLearn.Forms;

public partial class AccountForm_LoggedIn : CustomForm
{
    private readonly AccountManager _accountManager;

    public AccountForm_LoggedIn()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {
        _accountManager.Logout();
        CloseForm();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private void AccountForm_LoggedIn_Load(object sender, EventArgs e)
    {
        var user = AccountManager.GetCurrentUser();
        statusTextBox.Text = $"You are logged in with {user.Email}";
    }
}
