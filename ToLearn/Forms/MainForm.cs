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

    private void accountButton_Click(object sender, EventArgs e)
    {
        var accountForm = new AccountForm_NotLoggedIn();
        this.Visible = false;
        accountForm.ShowDialog();
        this.Visible = true;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        AccountManager.LoadUser();
        if (_accountManager.UserIsLoggedIn())
        {
            ShowMessage("You are logged in.");
        }
        else
        {
            ShowMessage("You need to log in");
        }
    }
}
