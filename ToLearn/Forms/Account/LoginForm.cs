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

namespace ToLearn.Forms.Account;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        var request = new Request()
        {
            Email = emailTextBox.Text,
            Password = passwordTextBox.Text
        };
        var client = new HttpClient();
        var result = client.PostAsJsonAsync<Request>("https://localhost:7190/login?useCookies=false&useSessionCookies=false", request);
        MessageBox.Show(result.Result.Content.ReadAsStringAsync().Result);
    }
}
