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
        await Refresh();
    }

    private void unitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateControls();
    }

    private async void editButton_Click(object sender, EventArgs e)
    {
        Unit selectedUnit = GetSelectedUnit();
        var editUnitForm = new EditUnitForm(selectedUnit);
        Visible = false;
        editUnitForm.ShowDialog();
        await Refresh();
        SetSelection(selectedUnit.id);
        Visible = true;
    }

    private async void deleteButton_Click(object sender, EventArgs e)
    {
        var selectedUnit = GetSelectedUnit();
        bool result = await _flashcardsManager.DeleteUnit(selectedUnit);
        if (result == true)
        {
            await Refresh();
            SetSelection(-1);
        }
    }

    private async void createNewUnitButton_Click(object sender, EventArgs e)
    {
        var createUnitForm = new CreateUnitForm(_deck);
        Visible = false;
        createUnitForm.ShowDialog();
        await Refresh();
        SetSelection(-2);
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
        var unit = FlashcardsManager.Units[selectedIndex];
        return unit;
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

    private async new Task Refresh()
    {
        await _flashcardsManager.ShowUnits(_deck);
        UpdateControls();
    }

    private void SetSelection(int option)
    {
        switch (option)
        {
            case -1:
                unitsComboBox.SelectedIndex = -1;
                break;
            case -2:
                unitsComboBox.SelectedIndex = unitsComboBox.Items.Count - 1;
                break;
            default:
                int counter = 0;
                foreach (Unit unit in FlashcardsManager.Units)
                {
                    if (unit.id == option)
                    {
                        break;
                    }
                    counter++;
                }
                unitsComboBox.SelectedIndex = counter;
                break;
        }
    }

    private void showCardsButton_Click(object sender, EventArgs e)
    {
        var showCardsForm = new ShowCardsForm(GetSelectedUnit());
        Visible = false;
        showCardsForm.ShowDialog();
        Visible = true;
    }
}
