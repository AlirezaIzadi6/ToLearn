using ToLearn.Forms;
using ToLearn.Utils;

namespace ToLearn;

public partial class MainForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public MainForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private void flashcardsButton_Click(object sender, EventArgs e)
    {
        var flashcardsForm = new FlashcardsForm();
        this.Visible = false;
        flashcardsForm.ShowDialog();
        this.Visible = true;
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void conjugationTrainingButton_Click(object sender, EventArgs e)
    {
        var conjugationTrainingForm = new ConjugationTrainingForm();
        this.Visible = false;
        conjugationTrainingForm.ShowDialog();
        this.Visible = true;
    }

    private async void accountButton_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (await _accountManager.UserIsLoggedIn())
        {
            var accountForm = new AccountForm_LoggedIn();
            accountForm.ShowDialog();
        }
        else
        {
            var accountForm = new AccountForm_NotLoggedIn();
            accountForm.ShowDialog();
        }
        SetLayout();
        this.Visible = true;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        AccountManager.LoadUser();
        SetLayout();
    }

    private async void SetLayout()
    {
        bool isLoggedIn = await _accountManager.UserIsLoggedIn();
        if (!isLoggedIn)
        {
            flashcardsButton.Visible = false;
            conjugationTrainingButton.Visible = false;
        }
        else
        {
            flashcardsButton.Visible = true;
            conjugationTrainingButton.Visible = true;
        }
    }
}
