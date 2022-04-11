using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class CardDeck
    {
        static Random random = new Random();

        private readonly List<Card> cards = new List<Card>()
        {
            new Card(Value.Ace, Suit.spades),
            new Card((Value)random.Next(1, 14), (Suit)random.Next(4)),
            new Card((Value)random.Next(1, 14), (Suit)random.Next(4)),
            new Card((Value)random.Next(1, 14), (Suit)random.Next(4)),
        };

        public void PrintDeck()
        {
            if (cards.Count > 0)
            {
                Console.WriteLine("Deck: ");
                int i = 0;
                foreach (var card in cards)
                {
                    Console.WriteLine($"Card nr {++i}: {card}");
                }
            }
            else
            {
                Console.WriteLine("Deck is empty.");
            }

            IEnumerable<Paper> paperCards = cards;
            Paper.Print(paperCards.ToList());
        }

        public void AddCard()
        {
            Console.WriteLine("dd a card: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Press {i} to add {(Suit)i}.");
            }
            Console.WriteLine("Pick a colour: ");

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int suit))
            {
                for (int i = 1; i < 14; i++)
                {
                    Console.WriteLine($"Write {i} to add {(Value)i}.");
                }
                Console.WriteLine("Pick a value: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    Card card = new Card((Value)value, (Suit)suit);
                    cards.Add(card);
                }
            }
            cards.Sort();
        }

        public void RemoveCard()
        {
            Console.WriteLine("elete a card (pick number): ");
            if (int.TryParse(Console.ReadLine(), out int cardNumber) && cardNumber >= 1 && cardNumber <= cards.Count)
            {
                Console.WriteLine($"Deleteing: {cards[cardNumber - 1].Name}");
                cards.RemoveAt(cardNumber - 1);
            }

            IComparer<Card> suitComparer = new CardCompareBySuit();
            cards.Sort(suitComparer);
        }
    }
}
