using System;

namespace Model
{
    public class Poker
    {
        private Card[] cards;

        public Poker()
        {
            cards = new Card[52];
            int index = 0;
            for (int value = 14; value >= 2; value--)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards[index] = new Card(suit, value);
                    index++;
                }
            }
        }

        public Card GetCard(int index)
        {
            if (index < 1 || index > 52)
            {
                throw new ArgumentException("Index must be between 1 and 52.");
            }
            return cards[index - 1];  // subtract 1 because array indices start at 0
        }
    }
}