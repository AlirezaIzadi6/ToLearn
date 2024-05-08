using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLearn.Models.Flashcards;

public class Card
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }
    public int UnitId { get; set; }
}
