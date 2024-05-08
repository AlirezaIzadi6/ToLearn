namespace ToLearn.Models.Flashcards;

public class Unit
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public int deckId { get; set; }
}
