using System.Linq.Expressions;
using System.Text.Json;
using ToLearn.Forms;
using ToLearn.Models.Flashcards;
using ToLearn.Models.RequestMaker;

namespace ToLearn.Utils;

public class FlashcardsManager
{
    private readonly ICustomForm _form;

    public static List<Deck> Decks { get;  private set; }
    public static List<Unit> Units { get; private set; }
    public static List<Card> Cards { get; private set; }

    public FlashcardsManager(ICustomForm form)
    {
        _form = form;
    }

    public async Task<bool> FillDecks()
    {
        var result = await MakeRequest<int?>(200, "api/decks", "Get", null);
        if (result.Success)
        {
            Decks = JsonSerializer.Deserialize<List<Deck>>(result.Body);
            var options = new List<string>();
            foreach (var deck in Decks)
            {
                options.Add($"{deck.title} by {deck.creator}");
            }
            _form.SetComboBox("Decks", options);
            return true;
        }
        return false;
    }

    public async Task<bool> CreateDeck(string title, string description)
    {
        var newDeck = new Deck()
        {
            title = title,
            description = description
        };
        return MakeRequest<Deck>(201, "api/decks", "Post", newDeck, "Deck created successfully.").Result.Success;
    }

    public async Task<bool> EditDeck(int id, string title, string description)
    {
        var deck = new Deck()
        {
            id = id,
            title = title,
            description = description
        };
        return MakeRequest<Deck>(200, "api/decks", "Put", deck, "Changes saved successfully.").Result.Success;
    }

    public async Task<bool> DeleteDeck(Deck deck)
    {
        bool confirm = _form.ShowQuestion($"Are you sure to deleete {deck.title}?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        return MakeRequest<int?>(204, "api/decks", "Delete", null, "Deck deleted successfully.").Result.Success;
    }

    public async Task<bool> ShowUnits(Deck deck)
    {
        var result = await MakeRequest<int?>(200, $"api/units/deck{deck.id}", "Get", null);
        if (result.Success)
        {
            Units = JsonSerializer.Deserialize<List<Unit>>(result.Body);
            var options = new List<string>();
            foreach (Unit unit in Units)
            {
                options.Add(unit.name);
            }
            _form.SetComboBox("Units", options);
            return true;
        }
        return false;
    }

    public async Task<bool> CreateUnit(int id, string name, string description)
    {
        var newUnit = new Unit()
        {
            name = name,
            description = description,
            deckId = id
        };
        return MakeRequest<Unit>(201, "api/units", "Post", newUnit, "Unit created successfully.").Result.Success;
    }

    public async Task<bool> EditUnit(int id, string name, string description)
    {
        var unit = new Unit()
        {
            id = id,
            name = name,
            description = description
        };
        return MakeRequest<Unit>(204, "api/units", "Put", unit, "Changes saved successfully.").Result.Success;
    }

    public async Task<bool> DeleteUnit(Unit unit)
    {
        bool confirm = _form.ShowQuestion("Are you sure to delete this unit?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        return MakeRequest<int?>(204, "api/units", "Delete", null, "Unit deleted successfully.").Result.Success;
    }

    public async Task<bool> ShowCards(Unit unit)
    {
        var result = await MakeRequest<int?>(200, $"api/cards/unit{unit.id}", "Get", null);
        if (result.Success)
        {
            Cards = JsonSerializer.Deserialize<List<Card>>(result.Body);
            List<string> options = new();
            foreach (Card card in Cards)
            {
                options.Add($"{card.question}: {card.answer}");
            }
            _form.SetComboBox("Cards", options);
            return true;
        }
        return false;
    }

    private async Task<FlashcardsResponse> MakeRequest<T>(int successCode, string path, string method, T? obj, string? successMessage = null)
    {
        FlashcardsResponse result = new();
        var requestMaker = new RequestMaker(AccountManager.GetCurrentUser());
        try
        {
            Response response = null;
            switch(method)
            {
                case "Get":
                    response = await requestMaker.Get(path);
                    break;
                case "Post":
                    response = await requestMaker.Post(path, obj);
                    break;
                case "Put":
                    response = await requestMaker.Put(path, obj);
                    break;
                case "Delete":
                    response = await requestMaker.Delete(path);
                    break;
            }
            if (response.StatusCode != successCode)
            {
                result.Success = false;
                _form.ShowError(response);
            }
            else
            {
                result.Success = true;
                result.Body = response.Body;
                if (successMessage != null)
                {
                    _form.ShowMessage(successMessage, "Success");
                }
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            _form.ShowMessage(ex.Message, "An error occurred");
        }
        return result;
    }
}
