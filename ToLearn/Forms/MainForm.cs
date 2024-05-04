using ToLearn.Forms;

namespace ToLearn;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
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
        var accountForm = new AccountForm();
        this.Visible = false;
        accountForm.ShowDialog();
        this.Visible = true;
    }
}
