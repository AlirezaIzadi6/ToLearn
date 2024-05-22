using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class CreateUnitForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Deck _deck;

    public CreateUnitForm(Deck deck)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _deck = deck;
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;
        string description = descriptionTextBox.Text;
        if (await _flashcardsManager.CreateUnit(_deck.id, name, description))
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
