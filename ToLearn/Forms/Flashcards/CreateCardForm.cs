using ToLearn.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class CreateCardForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Unit _unit;

    public CreateCardForm(Unit unit)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _unit = unit;
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        string question = questionTextBox.Text;
        string answer = answerTextBox.Text;
        string description = descriptionTextBox.Text;
        if (await _flashcardsManager.CreateCard(_unit.id, question, answer, description))
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
