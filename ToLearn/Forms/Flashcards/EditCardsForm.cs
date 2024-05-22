using ToLearn.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class EditCardsForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Unit _unit;

    public EditCardsForm(Unit unit)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _unit = unit;
    }

    private void EditCardsForm_Load(object sender, EventArgs e)
    {

    }

    private void saveButton_Click(object sender, EventArgs e)
    {

    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}
