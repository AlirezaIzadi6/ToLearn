using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToLearn.Forms;
using ToLearn.Models.Flashcards;

namespace ToLearn.Utils;

public class FlashcardsManager
{
    private readonly ICustomForm _form;
    private static List<Deck> _decks;

    public FlashcardsManager(ICustomForm form)
    {
        _form = form;
    }

    public async void FillDecks()
    {
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        var response = await requestMaker.Get("api/Decks");
        List<Deck> decks = JsonSerializer.Deserialize<List<Deck>>(response);
        SetDecks(decks);
        var options = new List<string>();
        foreach (var deck in decks)
        {
            options.Add($"{deck.title} by {deck.creator}");
        }
        _form.SetComboBox("Decks", options);
    }

    public async Task CreateDeck(string title, string description)
    {
        var newDeck = new Deck()
        {
            title = title,
            description = description
        };
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        var response = await requestMaker.Post("api/decks", newDeck);
        try
        {
            if (response == "")
            {
                _form.ShowMessage("An error occurred");
                return;
            }
            Deck createdDeck = JsonSerializer.Deserialize<Deck>(response);
            if (createdDeck.creator != null)
            {
                _form.ShowMessage("Deck created successfully.", createdDeck.creator);
                _form.Close();
            }
            else
            {
                _form.ShowMessage("Deck not created.");
            }
        }
        catch (Exception ex)
        {
            _form.ShowMessage(response);
        }
    }

    public static List<Deck> GetDecks()
    {
        return _decks;
    }

    public static void SetDecks(List<Deck> decks)
    {
        _decks = decks;
    }
}
