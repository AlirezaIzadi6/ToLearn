using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class ReviewForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly int _dekId;
    private readonly List<Item> _items;
    private Item _currentItem;

    public ReviewForm(int deckId, List<Item> items)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _dekId = deckId;
        _items = items;
    }

    private void ReviewForm_Load(object sender, EventArgs e)
    {
        _currentItem = _items[0];
        questionTextBox.Text = _currentItem.question;
        UpdateControls(true);
    }

    private async void checkButton_Click(object sender, EventArgs e)
    {
        bool result = await _flashcardsManager.CheckAnswer(_dekId, _currentItem.id, answerTextBox.Text);
        if (!result)
        {
            ShowMessage("Your answer is wrong.");
        }
    }

    private void showAnswerButton_Click(object sender, EventArgs e)
    {

    }

    private void difficultCardButton_Click(object sender, EventArgs e)
    {

    }

    private void skipForNowButton_Click(object sender, EventArgs e)
    {

    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private void UpdateControls(bool questionMode)
    {
        var controlTags = new List<string>()
        {
            "Check", "ShowAnswer"
        };
        ChangeEnabled(controlTags, questionMode);
    }
}
