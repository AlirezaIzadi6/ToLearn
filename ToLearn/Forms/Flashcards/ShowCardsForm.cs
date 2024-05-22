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
        UpdateControls();
    }

    private async void editButton_Click(object sender, EventArgs e)
    {
        var selectedCard = GetSelection();
        var editCardForm = new EditCardForm(selectedCard);
        Visible = false;
        editCardForm.ShowDialog();
        await Refresh();
        SetSelection(selectedCard.id);
        Visible = true;
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        bool result = await _flashcardsManager.DeleteCard(GetSelection());
        if (result == true)
        {
            await Refresh();
            SetSelection(-1);
        }
    }

    private async void createNewButton_Click(object sender, EventArgs e)
    {
        var createCardForm = new CreateCardForm(_unit);
        Visible = false;
        createCardForm.ShowDialog();
        await Refresh();
        SetSelection(-2);
        Visible = true;
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
        Card card = FlashcardsManager.Cards[selectedIndex];
        return card;
    }

    private void SetSelection(int option)
    {
        switch (option)
        {
            case -1:
                cardsComboBox.SelectedIndex = -1;
                break;
            case -2:
                cardsComboBox.SelectedIndex = cardsComboBox.Items.Count - 1;
                break;
            default:
                int counter = 0;
                foreach (Card card in FlashcardsManager.Cards)
                {
                    if (card.id == option)
                    {
                        break;
                    }
                    counter++;
                }
                cardsComboBox.SelectedIndex = counter;
                break;
        }
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

    private async new Task Refresh()
    {
        await _flashcardsManager.ShowCards(_unit);
        UpdateControls();
    }
}
