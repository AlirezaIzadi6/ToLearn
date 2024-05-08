using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLearn.Models.Flashcards;

public class Card
{
    public int id { get; set; }
    public string question { get; set; } = string.Empty;
    public string answer { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public int unitId { get; set; }
}
