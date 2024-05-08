using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearn.Utils;

namespace ToLearn.Forms;

public class CustomForm : Form, ICustomForm
{
    public void ShowMessage(string message, string caption = "")
    {
        MessageBox.Show(message, caption);
    }

    public void CloseForm()
    {
        this.Close();
    }

    public void SetComboBox(string tag, List<string> options)
    {
        ComboBox? comboBox = (ComboBox?)FindByTag(tag);
        if (comboBox == null)
        {
            return;
        }
        comboBox.Items.Clear();
        foreach (string option in options)
        {
            if (option == null)
            {
                continue;
            }
            comboBox.Items.Add(option);
        }
    }

    public Control? FindByTag(string tag)
    {
        var controls = this.Controls;
        foreach (Control control in controls)
        {
            if (control.Tag != null && control.Tag.ToString() == tag)
            {
                return control;
            }
        }
        return null;
    }
}

public interface ICustomForm
{
    public void ShowMessage(string message, string caption = "");
    public Control? FindByTag(string tag);
    public void SetComboBox(string tag, List<string> options);
    public void Close();
}
