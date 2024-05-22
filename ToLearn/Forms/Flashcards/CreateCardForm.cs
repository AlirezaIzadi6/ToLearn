using ToLearn.Forms;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class CreateCardForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;

    public CreateCardForm()
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        string question = questionTextBox.Text;
        string answer = answerTextBox.Text;
        string description = descriptionTextBox.Text;
        if (await _flashcardsManager.CreateCard(question, answer, description))
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
