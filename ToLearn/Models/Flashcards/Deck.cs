namespace ToLearn.Models.Flashcards;

public class Deck
{
    public int id { get; set; }
    public string creator { get; set; } = string.Empty;
    public string title { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
}
