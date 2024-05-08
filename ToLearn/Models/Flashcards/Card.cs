using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLearn.Models.Flashcards;

public class Card
{
    public int id { get; set; }
    public string question { get; set; }
    public string answer { get; set; }
    public string description { get; set; }
    public int unitId { get; set; }
}
