using System;
using Cards;

CardDeck cardDeck = new CardDeck();

while(true)
{
    cardDeck.PrintDeck();
    Console.WriteLine("Press 'a' to add or 'd' to delete a card");
    char key = Console.ReadKey().KeyChar;

    switch(key)
    {
        case 'a':
        case 'A':
            cardDeck.AddCard();
            break;
        case 'd':
        case 'D':
            cardDeck.RemoveCard();
            break;
        default:
            return;
    }
}