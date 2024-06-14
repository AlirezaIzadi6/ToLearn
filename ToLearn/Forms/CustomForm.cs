using System.Text.Json;
using System.Text.RegularExpressions;
using ToLearn.Models.RequestMaker;
using ToLearn.Models.Errors;

namespace ToLearn.Forms;

public class CustomForm : Form, ICustomForm
{
    // Methods that don't manipulate any control except the form.

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

    public void ShowError(Response response)
    {
        switch (response.StatusCode)
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
            default:
                ShowMessage(response.Body, $"Error {response.StatusCode}");
                break;
        }
    }

    public void CloseForm()
    {
        this.Close();
    }

    // Methods that manipulate controls.

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
            comboBox.Items.Add(option);
        }
    }

    public void SetText(string tag, string text)
    {
        var control = FindByTag(tag);
        if (control == null)
        {
            return;
        }
        control.Text = text;
    }

    public void ChangeEnabled(List<string> tags, bool enabled)
    {
        foreach (string tag in tags)
        {
            var control = FindByTag(tag);
            control.Enabled = enabled;
        }
    }

    // Private methods.

    private Control? FindByTag(string tag)
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

    public List<string> GetControls()
    {
        var result = new List<string>();
        foreach (Control control in Controls)
        {
            result.Add((string)control.Tag);
        }
        return result;
    }

    public void SetFocus(string controlTag)
    {
        foreach (Control control in Controls)
        {
            if (control.Tag == controlTag)
            {
                control.Focus();
                return;
            }
        }
    }
}

public interface ICustomForm
{
    public void ShowMessage(string message, string caption = "");
    public bool ShowQuestion(string question, string title);
    public void ShowError(Response response);
    public void CloseForm();
    public void SetComboBox(string tag, List<string> options);
    public void SetText(string tag, string text);
    public void ChangeEnabled(List<string>  tags, bool enabled);
    public List<string> GetControls();
    public void SetFocus(string controlTag);
}
