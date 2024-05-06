using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearn.Utils;

namespace ToLearn.Forms;

public class CustomForm : Form, ICustomForm
{
    private readonly AccountManager _accountManager;

    public void ShowMessage(string message, string caption = "")
    {
        MessageBox.Show(message, caption);
    }

    public void CloseForm()
    {
        this.Close();
    }
}

public interface ICustomForm
{
    public void ShowMessage(string message, string caption);
    public void Close();
}
