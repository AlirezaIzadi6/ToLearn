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

    private void FlashcardsForm_Load(object sender, EventArgs e)
    {
        UpdateControls();
        _flashcardsManager.FillDecks();
    }

    private void decksComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = decksComboBox.SelectedIndex;
        List<Deck> decks = FlashcardsManager.GetDecks();
        descriptionTextBox.Text = decks[index].description;
        UpdateControls();
    }

    private void showUnitsButton_Click(object sender, EventArgs e)
    {
        var showUnitsForm = new ShowUnitsForm(GetSelectedDeck());
        Visible = false;
        showUnitsForm.ShowDialog();
        Visible = true;
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        var selectedDeck = GetSelectedDeck();
        var editDeckForm = new EditDeckForm(selectedDeck);
        Visible = false;
        editDeckForm.ShowDialog();
        Visible = true;
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        var selectedDeck = GetSelectedDeck();
        await _flashcardsManager.DeleteDeck(selectedDeck);
    }

    private void createNewButton_Click(object sender, EventArgs e)
    {
        var createDeckForm = new CreateDeckForm();
        Visible = false;
        createDeckForm.ShowDialog();
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
        Deck selectedDeck = FlashcardsManager.GetDecks()[selectedIndex];
        return selectedDeck;
    }

    private void UpdateControls()
    {
        var controlTags = new List<string>()
        {
            "Learn", "Review", "ShowUnits", "Edit", "Delete"
        };
        if (GetSelectedDeck()  == null)
        {
            ChangeEnabled(controlTags, false);
        }
        else
        {
            ChangeEnabled(controlTags, true);
        }
    }
}
