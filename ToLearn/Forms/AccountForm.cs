using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLearn.Forms.Account;

namespace ToLearn.Forms;

public partial class AccountForm : Form
{
    public AccountForm()
    {
        InitializeComponent();
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
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
}
