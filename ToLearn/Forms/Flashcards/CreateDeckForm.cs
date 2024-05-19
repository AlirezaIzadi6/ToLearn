using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class CreateDeckForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;

    public CreateDeckForm()
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        string title = titleTextBox.Text;
        string description = descriptionTextBox.Text;
        await _flashcardsManager.CreateDeck(title, description);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
