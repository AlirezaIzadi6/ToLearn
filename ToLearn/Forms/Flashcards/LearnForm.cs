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

public partial class LearnForm : CustomForm
{
    private readonly FlashcardsManager _flashcardsManager;
    private readonly List<Item> _items;
    private readonly int _deckId;
    private int _index = 0;

    public LearnForm(int deckId, List<Item> items)
    {
        InitializeComponent();
        _flashcardsManager = new FlashcardsManager(this);
        _items = items;
        _deckId = deckId;
    }

    private void LearnForm_Load(object sender, EventArgs e)
    {
        ShowCard();
    }

    private void previousButton_Click(object sender, EventArgs e)
    {
        _index--;
        ShowCard();
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        _index++;
        ShowCard();
    }

    private async void finishButton_Click(object sender, EventArgs e)
    {
        var learnedItems = new List<int>();
        foreach (var item in _items)
        {
            learnedItems.Add(item.id);
        }
        if (await _flashcardsManager.SendLearnedItems(_deckId, learnedItems))
        {
            CloseForm();
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        CloseForm();
    }

    private void ShowCard()
    {
        var deactiveControlTags = new List<string>();
        var activeControlTags = new List<string>();

        if (_index == 0)
        {
            deactiveControlTags.Add("Previous");
        }
        else
        {
            activeControlTags.Add("Previous");
        }

        if (_index == _items.Count-1)
        {
            deactiveControlTags.Add("Next");
            activeControlTags.Add("Finish");
        }
        else
        {
            activeControlTags.Add("Next");
            deactiveControlTags.Add("Finish");
        }

        ChangeEnabled(activeControlTags, true);
        ChangeEnabled(deactiveControlTags, false);

        var currentItem = _items[_index];
        questionTextBox.Text = currentItem.question;
        questionTextBox.Focus();
        answerTextBox.Text = currentItem.answer;
        descriptionTextBox.Text = currentItem.description;
    }
}
