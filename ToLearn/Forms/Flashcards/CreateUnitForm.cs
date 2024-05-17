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

public partial class CreateUnitForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Deck _deck;

    public CreateUnitForm(Deck deck)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _deck = deck;
    }

    private async void createButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;
        string description = descriptionTextBox.Text;
        await _flashcardsManager.CreateUnit(_deck.id, name, description);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm()
    }
}
