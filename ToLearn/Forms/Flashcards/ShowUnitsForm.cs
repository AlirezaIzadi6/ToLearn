using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class ShowUnitsForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Deck _deck;

    public ShowUnitsForm(Deck deck)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _deck = deck;
    }

    private async void ShowUnitsForm_Load(object sender, EventArgs e)
    {
        UpdateControls();
        await _flashcardsManager.ShowUnits(_deck);
    }

    private void unitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateControls();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        var editUnitForm = new EditUnitForm(GetSelectedUnit());
        Visible = false;
        editUnitForm.ShowDialog();
        Visible = true;
    }

    private void createNewUnitButton_Click(object sender, EventArgs e)
    {
        var createUnitForm = new CreateUnitForm(_deck);
        Visible = false;
        createUnitForm.ShowDialog();
        Visible = true;
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private Unit GetSelectedUnit()
    {
        int selectedIndex = unitsComboBox.SelectedIndex;
        if (selectedIndex == -1)
        {
            return null;
        }
        var units = FlashcardsManager.GetUnits();
        return units[selectedIndex];
    }

    private void UpdateControls()
    {
        var controlTags = new List<string>()
        {
            "ShowCards", "Edit", "Delete"
        };
        if (GetSelectedUnit() != null)
        {
            ChangeEnabled(controlTags, true);
        }
        else
        {
            ChangeEnabled(controlTags, false);
        }
    }
}
