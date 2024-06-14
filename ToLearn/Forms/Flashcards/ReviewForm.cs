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
    private readonly List<FlashcardQuestion> _items;
    private int _index;

    public ReviewForm(int deckId, List<FlashcardQuestion> items)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _dekId = deckId;
        _items = items;
    }

    private void ReviewForm_Load(object sender, EventArgs e)
    {
        _index = 0;
        UpdateControls(true);
    }

    private async void checkButton_Click(object sender, EventArgs e)
    {
        bool result = await _flashcardsManager.CheckAnswer(_dekId, _items[_index].itemId, answerTextBox.Text);
        if (result)
        {
            if (_index < _items.Count - 1)
            {
                _index++;
                UpdateControls(true);
            }
            else
            {
                ShowMessage("Review completed.", "Complete");
                CloseForm();
            }
        }
    }

    private async void showAnswerButton_Click(object sender, EventArgs e)
    {
        var card = await _flashcardsManager.GetAnswer(_items[_index].itemId);
        if (card != null)
        {
            answerTextBox.Text = card.answer;
            descriptionTextBox.Text = card.description;
            UpdateControls(false);
        }
    }

    private async void difficultCardButton_Click(object sender, EventArgs e)
    {
        await _flashcardsManager.SetAsDifficult(_items[_index].itemId);
    }

    private void skipForNowButton_Click(object sender, EventArgs e)
    {
        if (_index < _items.Count-1)
        {
            _index++;
            UpdateControls(true);
        }
        else
        {
            ShowMessage("Review completed.", "Complete");
            CloseForm();
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private void UpdateControls(bool questionMode)
    {
        var controlTags1 = new List<string>()
        {
            "Check", "ShowAnswer"
        };

        var controlTags2 = new List<string>()
        {
            "Description"
        };

        if (questionMode)
        {
            questionTextBox.Text = _items[_index].questionText;
            answerTextBox.Text = string.Empty;
            answerTextBox.ReadOnly = false;
            questionTextBox.Focus();
            skipForNowButton.Text = "Skip for now";
            ChangeEnabled(controlTags1, true);
            ChangeEnabled(controlTags2, false);
        }

        else
        {
            skipForNowButton.Text = "Next";
            answerTextBox.ReadOnly= true;
            answerTextBox.Focus();
            ChangeEnabled(controlTags1, false);
            ChangeEnabled(controlTags2, true);
            if (_index == _items.Count-1)
            {
                skipForNowButton.Text = "Finish";
            }
        }
    }
}
