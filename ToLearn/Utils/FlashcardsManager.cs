using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToLearn.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Models.RequestMaker;

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
        try
        {
            var response = await requestMaker.Get("api/Decks");
            if (response.StatusCode != 200)
            {
                _form.ShowError(response);
            }
            List<Deck> decks = JsonSerializer.Deserialize<List<Deck>>(response.Body);
            SetDecks(decks);
            var options = new List<string>();
            foreach (var deck in decks)
            {
                options.Add($"{deck.title} by {deck.creator}");
            }
            _form.SetComboBox("Decks", options);
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
        }
    }

    public async Task CreateDeck(string title, string description)
    {
        var newDeck = new Deck()
        {
            title = title,
            description = description
        };
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Post("api/decks", newDeck);
            if (response.StatusCode != 201)
            {
                _form.ShowError(response);
                return;
            }
            Deck createdDeck = JsonSerializer.Deserialize<Deck>(response.Body);
            _form.ShowMessage("Deck created successfully.", "Success");
            _form.Close();
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
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
