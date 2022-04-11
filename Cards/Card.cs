using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Paper
    {
        public static string type = "white";

        public static void Print(List<Paper> papers)
        {
            foreach (Paper p in papers)
            {
                Console.WriteLine($"Paper: {type}");
            }
        }
    }

    public class Card : Paper, IComparable<Card>
    {
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }
        public string Name {
            get
            {
                return $"{Value} of {Suit}";
            }
            private set { } 
        }

        public Card (Value value, Suit suit)
        {
            Suit = suit;
            Value = value;
        }

        public int CompareTo(Card cardToCompare)
        {
            if (Value > cardToCompare.Value)
            {
                return 1;
            }
            else if (Value < cardToCompare.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class CardCompareBySuit : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Suit > y.Suit)
            {
                return -1;
            }
            if (x.Suit < y.Suit)
            {
                return 1;
            }
            if (x.Value > y.Value)
            {
                return -1;
            }
            if (x.Value < y.Value)
            {
                return 1;
            }
            return 0;
        }
    }
}
