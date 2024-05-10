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
        if (await _accountManager.UserIsLoggedIn())
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
        await _accountManager.UserIsLoggedIn(new() { "Flashcards", "ConjugationTraining" });
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        AccountManager.LoadUser();
        await _accountManager.UserIsLoggedIn(new() { "Flashcards", "ConjugationTraining" });
    }
}
