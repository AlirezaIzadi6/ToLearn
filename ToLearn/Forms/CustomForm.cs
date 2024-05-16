using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToLearn.Utils;
using ToLearn.Models.RequestMaker;

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

    public void ChangeVisibility(List<string> tags, bool visible)
    {
        foreach (string tag in tags)
        {
            var control = FindByTag(tag);
            control.Visible = visible;
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

    public void ShowError(Response response)
    {
        switch(response.StatusCode)
        {
            case 400:
                var error = JsonSerializer.Deserialize<Error>(response.Body);
                ShowMessage(error.message, error.title);
                break;
            case 401:
                ShowMessage("You are not allowed to access this.", "Not authorized");
                break;
            case 404:
                ShowMessage("This resource does not exist.", "Not  found");
                break;
        }
    }
}

public interface ICustomForm
{
    public void ShowMessage(string message, string caption = "");
    public void ShowError(Response response);
    public Control? FindByTag(string tag);
    public void SetComboBox(string tag, List<string> options);
    public void ChangeVisibility(List<string>  tag, bool visible);
    public void Close();
}
