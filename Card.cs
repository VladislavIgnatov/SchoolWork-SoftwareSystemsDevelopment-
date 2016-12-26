using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladislavIgnatovAssignment04
{
    class Card
    {
        // Feild to represent the Rank and Suit of the card.
        int suit;
        int rank;

        // Constructor
        public Card()
        {
            rank = 0;
            suit = 0;
        }

        // Constructor with x , y arguments
        public Card(int x , int y)
        {
            suit = x;
            rank = y;
        }

        // rank property
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        // suit property
        public int Suit
        {
            get { return suit; }
            set { suit = value; }
        }
    }
}
