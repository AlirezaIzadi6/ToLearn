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

namespace ToLearn.Forms.Flashcards;

public partial class EditDeckForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly Deck _deck;

    public EditDeckForm(Deck deck)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _deck = deck;
        titleTextBox.Text = deck.title;
        descriptionTextBox.Text = deck.description;
    }

    private async void saveButton_Click(object sender, EventArgs e)
    {
        string title = titleTextBox.Text;
        string description = descriptionTextBox.Text;
        await _flashcardsManager.EditDeck(_deck.id, title, description);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }
}