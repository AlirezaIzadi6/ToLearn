using ToLearn.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class EditCardForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Card _card;

    public EditCardForm(Card card)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _card = card;
    }

    private void EditCardForm_Load(object sender, EventArgs e)
    {
        questionTextBox.Text = _card.question;
        answerTextBox.Text = _card.answer;
        descriptionTextBox.Text = _card.description;
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        string question = questionTextBox.Text;
        string answer = answerTextBox.Text;
        string description = descriptionTextBox.Text;
        if (await _flashcardsManager.EditCard(_card.id, question, answer, description))
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
