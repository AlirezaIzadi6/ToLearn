using System.Linq.Expressions;
using System.Text.Json;
using System.Web;
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
        var result = await MakeRequest<Deck>(201, "api/decks", "Post", newDeck, "Deck created successfully.");
        return result.Success;
    }

    public async Task<bool> EditDeck(int id, string title, string description)
    {
        var deck = new Deck()
        {
            id = id,
            title = title,
            description = description
        };
        var result = await MakeRequest<Deck>(204, $"api/decks/{id}", "Put", deck, "Changes saved successfully.");
        return result.Success;
    }

    public async Task<bool> DeleteDeck(Deck deck)
    {
        bool confirm = _form.ShowQuestion($"Are you sure to deleete {deck.title}?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        var result = await MakeRequest<int?>(204, "api/decks", "Delete", null, "Deck deleted successfully.");
        return result.Success;
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
        var result = await MakeRequest<Unit>(201, "api/units", "Post", newUnit, "Unit created successfully.");
        return result.Success;
    }

    public async Task<bool> EditUnit(int id, string name, string description)
    {
        var unit = new Unit()
        {
            id = id,
            name = name,
            description = description
        };
        var result = await MakeRequest<Unit>(204, $"api/units/{id}", "Put", unit, "Changes saved successfully.");
        return result.Success;
    }

    public async Task<bool> EditCards(int id, string text)
    {
        var cards = new List<Card>();
        var lines = text.Split("\r\n");
        foreach (string line in lines)
        {
            var splittedLine = line.Split('\t');
            if (splittedLine.Length != 4)
            {
                continue;
            }
            int extractedId;
            try
            {
                extractedId = int.Parse(splittedLine[0]);
            }
            catch
            {
                extractedId = 0;
            }
            var card = new Card()
            {
                id = extractedId,
                question = splittedLine[1],
                answer = splittedLine[2],
                description = splittedLine[3],
                unitId = id
            };
            cards.Add(card);
        }
        var result = await MakeRequest(200, $"api/units/{id}/editcards", "Put", cards);
        return result.Success;
    }

    public async Task<bool> DeleteUnit(Unit unit)
    {
        bool confirm = _form.ShowQuestion("Are you sure to delete this unit?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        var     result = await MakeRequest<int?>(204, "api/units", "Delete", null, "Unit deleted successfully.");
        return result.Success;
    }

    public async Task<bool> ShowCards(Unit unit, string mode)
    {
        var result = await MakeRequest<int?>(200, $"api/cards/unit{unit.id}", "Get", null);
        if (result.Success)
        {
            Cards = JsonSerializer.Deserialize<List<Card>>(result.Body);
            if (mode == "ComboBox")
            {
                List<string> options = new();
                foreach (Card card in Cards)
                {
                    options.Add($"{card.question}: {card.answer}");
                }
                _form.SetComboBox("Cards", options);
            }
            else if (mode == "TextBox")
            {
                var lines = new List<string>();
                foreach(Card card in Cards)
                {
                    lines.Add($"{card.id}\t{card.question}\t{card.answer}\t{card.description}");
                }
                string text = string.Join("\r\n", lines.ToArray());
                _form.SetText("Cards", text);
            }
            return true;
        }
        return false;
    }

    public async Task<bool> CreateCard(int unitId, string question, string answer,  string description)
    {
        var newCard = new Card()
        {
            question = question,
            answer = answer,
            description = description,
            unitId = unitId
        };
        var result = await MakeRequest<Card>(201, "api/cards", "Post", newCard);
        return result.Success;
    }

    public async Task<bool> EditCard(int id, string question, string answer, string description)
    {
        var card = new Card()
        {
            id = id,
            question = question,
            answer = answer,
            description = description
        };
        var result = await MakeRequest(200, $"api/cards/{id}", "Put", card);
        return result.Success;
    }

    public async Task<bool> DeleteCard(Card card)
    {
        bool confirm = _form.ShowQuestion("Are you sure to delete this card?", "Confirm");
        if (!confirm)
        {
            return false;
        }
        var result = await MakeRequest<int?>(204, $"api/cards/{card.id}", "Delete", null);
        return result.Success;
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
