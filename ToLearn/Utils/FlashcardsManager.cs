using System;
using System.Collections.Generic;
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

    public void FillDecks()
    {
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        var response = requestMaker.Get("api/Decks");
        List<Deck> decks = JsonSerializer.Deserialize<List<Deck>>(response);
        SetDecks(decks);
        var options = new List<string>();
        foreach (var deck in decks)
        {
            options.Add(deck.title);
        }
        _form.SetComboBox("Decks", options);
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
