using ToLearn.Models.Account;
using ToLearn.Utils;

namespace ToLearn.Forms;

public partial class MainForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public MainForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        AccountManager.LoadUser();
        User user = AccountManager.GetCurrentUser();
        if (user != null)
        {
            accountButton.Enabled = false;
            await _accountManager.Login(user.Email, user.Password);
            accountButton.Enabled = true;
        }
        await UpdateControls();
    }

    private void flashcardsButton_Click(object sender, EventArgs e)
    {
        var flashcardsForm = new FlashcardsForm();
        this.Visible = false;
        flashcardsForm.ShowDialog();
        this.Visible = true;
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
        if (await _accountManager.UserIsLoggedIn() == true)
        {
            var accountForm = new AccountForm_LoggedIn();
            this.Visible = false;
            accountForm.ShowDialog();
        }
        else
        {
            var accountForm = new AccountForm_NotLoggedIn();
            this.Visible = false;
            accountForm.ShowDialog();
        }
        this.Visible = true;
        await UpdateControls();
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private async Task UpdateControls()
    {
        List<string> controlTags = new() { "Flashcards", "ConjugationTraining" };
        var isLoggedIn = await _accountManager.UserIsLoggedIn();
        if (isLoggedIn == true)
        {
            ChangeEnabled(controlTags, true);
        }
        else
        {
            ChangeEnabled(controlTags, false);
        }
    }
}
