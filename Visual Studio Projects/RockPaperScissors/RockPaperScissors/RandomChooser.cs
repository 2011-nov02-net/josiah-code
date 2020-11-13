using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    class RandomChooser : IChooser
    {
        Hands IChooser.Choose(Hands playerHand)
        {
            Random rand = new Random();
            Hands choice = playerHand;
            switch (rand.Next(0, 3))
            {
                case 0:
                    choice = Hands.Rock;
                    break;
                case 1:
                    choice = Hands.Paper;
                    break;
                case 2:
                    choice = Hands.Scissors;
                    break;
            }
            return choice;
        }
    }
}
