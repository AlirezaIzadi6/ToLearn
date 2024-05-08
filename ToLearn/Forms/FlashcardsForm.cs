﻿using System;
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
        _flashcardsManager.FillDecks();
    }

    private void decksComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = decksComboBox.SelectedIndex;
        List<Deck> decks = FlashcardsManager.GetDecks();
        descriptionTextBox.Text = decks[index].description;
    }
}
