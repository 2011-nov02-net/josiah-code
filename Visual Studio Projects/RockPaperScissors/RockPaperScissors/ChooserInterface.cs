using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    interface IChooser
    {
        public Hands Choose(Hands playerHand);
    }
}
