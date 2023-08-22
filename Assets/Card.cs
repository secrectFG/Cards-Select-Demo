using System;

namespace Model
{
    public enum Suit
    {
        梅花 = 1, // 梅花
        黑桃 = 2, // 黑桃
        红心 = 3, // 红心
        方块 = 4 // 方块
    }
    public class Card
    {
        public Suit Suit { get; private set; }
        public int Value { get; private set; }

        public Card(Suit suit, int value)
        {
            if (value < 2 || value > 14)
            {
                throw new ArgumentException("Card value must be between 2 and 14.");
            }
            Suit = suit;
            Value = value;
        }

        public string GetResourceName()
        {
            return $"{GetIndex()}.png";
        }

        public override string ToString()
        {
            string valueString;
            switch (Value)
            {
                case 11:
                    valueString = "J";
                    break;
                case 12:
                    valueString = "Q";
                    break;
                case 13:
                    valueString = "K";
                    break;
                case 14:
                    valueString = "A";
                    break;
                default:
                    valueString = Value.ToString();
                    break;
            }
            return $"{valueString} of {Suit.ToString()}";
        }

        private int GetIndex()
        {
            return (Value - 2) * 4 + (int)Suit;
        }
    }
}