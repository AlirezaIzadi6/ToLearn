using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class EditUnitForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Unit _unit;

    public EditUnitForm(Unit unit)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _unit = unit;
    }

    private void EditUnitForm_Load(object sender, EventArgs e)
    {
        nameTextBox.Text = _unit.name;
        descriptionTextBox.Text = _unit.description;
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;
        string description = descriptionTextBox.Text;
        if (await _flashcardsManager.EditUnit(_unit.id, name, description))
        {
            CloseForm();
        }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
