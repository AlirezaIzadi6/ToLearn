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

namespace ToLearn.Forms.Account;

public partial class RegisterForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public RegisterForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private async void registerButton_Click(object sender, EventArgs e)
    {
        await _accountManager.Register(emailTextBox.Text, passwordTextBox.Text);
    }
}
