using ToLearn.Forms.Flashcards;
using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms;

public partial class FlashcardsForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;

    public FlashcardsForm()
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
    }

    private async void FlashcardsForm_Load(object sender, EventArgs e)
    {
        await Refresh();
    }

    private void decksComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = decksComboBox.SelectedIndex;
        var deck = FlashcardsManager.Decks[index];
        descriptionTextBox.Text = deck.description;
        UpdateControls();
    }

    private async void learnButton_Click(object sender, EventArgs e)
    {
        var items = await _flashcardsManager.GetItems(GetSelectedDeck());
        if (items != null)
        {
            if (items.Count == 0)
            {
                ShowMessage("No new card", "There is no new card to learn in this deck.");
                return;
            }
            var learnForm = new LearnForm(GetSelectedDeck().id, items);
            Visible = false;
            learnForm.ShowDialog();
            Visible = true;
        }
    }

    private void showUnitsButton_Click(object sender, EventArgs e)
    {
        var selectedDeck = GetSelectedDeck();
        bool editable = (selectedDeck.creator == AccountManager.GetCurrentUser().UserName);
        var showUnitsForm = new ShowUnitsForm(selectedDeck, editable);
        Visible = false;
        showUnitsForm.ShowDialog();
        Visible = true;
    }

    private async void editButton_Click(object sender, EventArgs e)
    {
        var selectedDeck = GetSelectedDeck();
        var editDeckForm = new EditDeckForm(selectedDeck);
        Visible = false;
        editDeckForm.ShowDialog();
        await Refresh();
        SetSelection(selectedDeck.id);
        Visible = true;
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        var selectedDeck = GetSelectedDeck();
        bool result = await _flashcardsManager.DeleteDeck(selectedDeck);
        if (result == true)
        {
            await Refresh();
            SetSelection(-1);
        }
    }

    private async void createNewButton_Click(object sender, EventArgs e)
    {
        var createDeckForm = new CreateDeckForm();
        Visible = false;
        createDeckForm.ShowDialog();
        await Refresh();
        SetSelection(-2);
        Visible = true;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private Deck GetSelectedDeck()
    {
        int selectedIndex = decksComboBox.SelectedIndex;
        if (selectedIndex == -1)
        {
            return null;
        }
        Deck selectedDeck = FlashcardsManager.Decks[selectedIndex];
        return selectedDeck;
    }

    private void UpdateControls()
    {
        var selectedTags = new List<string>()
        {
            "Learn", "Review", "ShowUnits", "Edit", "Delete"
        };
        var authorizedTags = new List<string>()
        {
            "Edit", "Delete"
        };

        var selectedDeck = GetSelectedDeck();
        if (selectedDeck == null)
        {
            ChangeEnabled(selectedTags, false);
        }
        else
        {
            ChangeEnabled(selectedTags, true);
            if (selectedDeck.creator != AccountManager.GetCurrentUser().UserName)
            {
                ChangeEnabled(authorizedTags, false);
            }
        }
    }

    private async new Task Refresh()
    {
        await _flashcardsManager.FillDecks();
        UpdateControls();
    }

    private void SetSelection(int option)
    {
        switch (option)
        {
            case -1:
                decksComboBox.SelectedIndex = -1;
                break;
            case -2:
                decksComboBox.SelectedIndex = decksComboBox.Items.Count - 1;
                break;
            default:
                int counter = 0;
                foreach (Deck deck in FlashcardsManager.Decks)
                {
                    if (deck.id == option)
                    {
                        break;
                    }
                    counter++;
                }
                decksComboBox.SelectedIndex = counter;
                break;
        }
    }
}
