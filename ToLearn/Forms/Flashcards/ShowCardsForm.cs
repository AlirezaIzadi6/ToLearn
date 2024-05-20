using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class ShowCardsForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Unit _unit;

    public ShowCardsForm(Unit unit)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _unit = unit;
    }

    private async void ShowCardsForm_Load(object sender, EventArgs e)
    {
        await Refresh();
    }

    private void cardsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void editButton_Click(object sender, EventArgs e)
    {

    }

    private void deleteButton_Click(object sender, EventArgs e)
    {

    }

    private void createNewButton_Click(object sender, EventArgs e)
    {

    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private Card GetSelection()
    {
        if (cardsComboBox.SelectedIndex == -1)
        {
            return null;
        }
        int selectedIndex = cardsComboBox.SelectedIndex;
        List<Card> cards = FlashcardsManager.GetCards();
        return cards[selectedIndex];
    }

    private void UpdateControls()
    {
        var controlTags = new List<string>()
        {
            "Edit", "Delete"
        };
        if (GetSelection() != null)
        {
            ChangeEnabled(controlTags, true);
        }
        else
        {
            ChangeEnabled(controlTags, false);
        }
    }

    private async Task Refresh()
    {
        await _flashcardsManager.ShowCards(_unit);
        UpdateControls();
    }
}
