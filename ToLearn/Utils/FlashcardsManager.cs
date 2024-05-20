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
    private static List<Unit> _units;
    private static List<Card> _cards;

    public FlashcardsManager(ICustomForm form)
    {
        _form = form;
    }

    public async Task<bool> FillDecks()
    {
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Get("api/Decks");
            if (response.StatusCode != 200)
            {
                _form.ShowError(response);
                return false;
            }
            List<Deck> decks = JsonSerializer.Deserialize<List<Deck>>(response.Body);
            SetDecks(decks);
            var options = new List<string>();
            foreach (var deck in decks)
            {
                options.Add($"{deck.title} by {deck.creator}");
            }
            _form.SetComboBox("Decks", options);
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> CreateDeck(string title, string description)
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
                return false;
            }
            Deck createdDeck = JsonSerializer.Deserialize<Deck>(response.Body);
            _form.ShowMessage("Deck created successfully.", "Success");
            _form.CloseForm();
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> EditDeck(int id, string title, string description)
    {
        var deck = new Deck()
        {
            id = id,
            title = title,
            description = description
        };
        var requestMaker = new RequestMaker( AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Put($"api/decks/{id}", deck);
            if (response.StatusCode != 204)
            {
                _form.ShowError(response);
                return false;
            }
            _form.ShowMessage("Your changes are saved successfully.", "Success");
            _form.CloseForm();
            return true;
        }
        catch(Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> DeleteDeck(Deck deck)
    {
        bool confirm = _form.ShowQuestion($"Are you sure to deleete {deck.title}?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Delete($"api/decks/{deck.id}");
            if (response.StatusCode != 204)
            {
                _form.ShowError(response);
                return false;
            }
            _form.ShowMessage("Deck deleted successfully.", "Success");
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> ShowUnits(Deck deck)
    {
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Get($"api/units/deck{deck.id}");
            if (response.StatusCode != 200)
            {
                _form.ShowError(response);
                return false;
            }
            List<Unit> units = JsonSerializer.Deserialize<List<Unit>>(response.Body);
            SetUnits(units);
            var options = new List<string>();
            foreach (Unit unit in units)
            {
                options.Add(unit.name);
            }
            _form.SetComboBox("Units", options);
            return true;
        }
        catch(Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> CreateUnit(int id, string name, string description)
    {
        var newUnit = new Unit()
        {
            name = name,
            description = description,
            deckId = id
        };
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Post("api/units", newUnit);
            if (response.StatusCode != 201)
            {
                _form.ShowError(response);
                return false;
            }
            _form.ShowMessage("Unit created successfully.", "Success");
            _form.CloseForm();
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> EditUnit(int id, string name, string description)
    {
        var unit = new Unit()
        {
            id = id,
            name = name,
            description = description
        };
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Put($"api/units/{id}", unit);
            if (response.StatusCode != 204)
            {
                _form.ShowError(response);
                return false;
            }
            _form.ShowMessage("Changes saved successfully.", "Success");
            _form.CloseForm();
            return true;
        }
        catch(Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
        }
    }

    public async Task<bool> DeleteUnit(Unit unit)
    {
        bool confirm = _form.ShowQuestion("Are you sure to delete this unit?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            var response = await requestMaker.Delete($"api/units/{unit.id}");
            if (response.StatusCode != 204)
            {
                _form.ShowError(response);
            }
            _form.ShowMessage("Unit deleted successfully.", "Success");
            return true;
        }
        catch (Exception ex)
        {
            _form.ShowMessage(ex.Message, "Error");
            return false;
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

    public static void SetUnits(List<Unit> units)
    {
        _units = units;
    }

    public static List<Unit> GetUnits()
    {
        return _units;
    }
}
