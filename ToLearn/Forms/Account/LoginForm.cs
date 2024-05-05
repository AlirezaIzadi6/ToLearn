using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLearn.Models.Account;
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

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        string email = emailTextBox.Text;
        string password = passwordTextBox.Text;
        _accountManager.Login(email, password);
    }
}
