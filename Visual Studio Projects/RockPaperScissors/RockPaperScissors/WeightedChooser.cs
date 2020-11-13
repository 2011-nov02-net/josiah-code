using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RockPaperScissors
{
    class WeightedChooser : IChooser
    {
        Dictionary<Hands, int> playerChoices = new Dictionary<Hands, int>();

        public WeightedChooser()
        {
            playerChoices.Add(Hands.Rock, 0);
            playerChoices.Add(Hands.Paper, 0);
            playerChoices.Add(Hands.Scissors, 0);
        }

        Hands IChooser.Choose(Hands playerHand)
        {
            Hands hand = playerChoices.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Hands choice = hand;

            switch (hand)
            {
                case Hands.Paper:
                    choice = Hands.Scissors;
                    break;
                case Hands.Rock:
                    choice = Hands.Paper;
                    break;
                case Hands.Scissors:
                    choice = Hands.Rock;
                    break;
            }

            playerChoices[playerHand] += 1;

            return choice;
        }
    }
}
