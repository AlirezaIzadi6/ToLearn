using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToLearn.Utils;
using ToLearn.Models.RequestMaker;
using ToLearn.Models.Errors;

namespace ToLearn.Forms;

public class CustomForm : Form, ICustomForm
{
    public void ShowMessage(string message, string caption = "")
    {
        MessageBox.Show(message, caption);
    }

    public bool ShowQuestion(string question, string title = "")
    {
        DialogResult result = MessageBox.Show(question, title, MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            return true;
        }
        return false;
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
                var error = JsonSerializer.Deserialize<CustomError>(response.Body);
                if (error.message != null)
                {
                    ShowMessage(error.message, error.title);
                }
                else
                {
                    string errors = GetErrors(response.Body);
                    ShowMessage(errors, error.title);
                }
                break;
            case 401:
                ShowMessage("You are not authorized.", "Not authorized");
                break;
            case 404:
                ShowMessage("This resource does not exist.", "Not  found");
                break;
        }
    }

    private string GetErrors(string body)
    {
        var errors = new List<string>();
        var matches = Regex.Matches(body, "(?<=\\[\")[^\\]\"]+(?=\"\\])");
        foreach (Match match in matches)
        {
            errors.Add(match.Value);
        }
        return string.Join('\n', errors);
    }
}

public interface ICustomForm
{
    public void ShowMessage(string message, string caption = "");
    public bool ShowQuestion(string question, string title);
    public void ShowError(Response response);
    public Control? FindByTag(string tag);
    public void SetComboBox(string tag, List<string> options);
    public void ChangeVisibility(List<string>  tag, bool visible);
    public void Close();
}
