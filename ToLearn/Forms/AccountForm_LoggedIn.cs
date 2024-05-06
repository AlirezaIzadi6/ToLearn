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
        _ = new AccountManager(this);
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {

    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
