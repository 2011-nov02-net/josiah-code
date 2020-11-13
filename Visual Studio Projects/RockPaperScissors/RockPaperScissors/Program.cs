using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            int ties = 0, playerWins = 0, computerWins = 0;
            string playerInput = "", input = "";

            Dictionary<string, Hands> hands = new Dictionary<string, Hands>
            {
                { "r", Hands.Rock },
                { "p", Hands.Paper },
                { "s", Hands.Scissors }
            };

            IChooser ComputerPlayer;

            while (!(input == "1" || input == "2"))
            {
                Console.WriteLine("Choose the AI to play against:\n(1) Random\n(2) Weighted");
                input = Console.ReadLine();
                Console.Clear();
            }
            
            if (input == "1") ComputerPlayer = new RandomChooser();
            else ComputerPlayer = new WeightedChooser();

            while (true)
            {
                Console.WriteLine($"Score\nPlayer wins: {playerWins}\nComputer wins: {computerWins}\nTies: {ties}");
                Console.WriteLine("Choose hand (r=Rock, p=Paper, s=Scissors, q=Quit):");
                playerInput = Console.ReadLine();
                Console.Clear();

                if (playerInput == "q") break;

                if (!hands.ContainsKey(playerInput))
                {
                    Console.Clear();
                    continue;
                }
                Hands playerHand = hands[playerInput];
                Hands computerHand = ComputerPlayer.Choose(playerHand);
                switch (compareHands(playerHand, computerHand))
                {
                    case 0:
                        Console.WriteLine("You won!");
                        playerWins += 1;
                        break;
                    case 1:
                        Console.WriteLine("You lost!");
                        computerWins += 1;
                        break;
                    case 2:
                        Console.WriteLine("It's a tie");
                        ties += 1;
                        break;
                }
            }
            Console.WriteLine($"Final score\nPlayer wins: {playerWins}\nComputer wins: {computerWins}\nTies: {ties}");
        }
        // 0 = left hand won, 1 = right hand won, 2 = tie
        static int compareHands(Hands left, Hands right)
        {
            if (left == right) return 2;

            if (left == Hands.Rock)
            {
                if (right == Hands.Scissors) return 0;
                else return 1;
            }
            if (left == Hands.Paper)
            {
                if (right == Hands.Rock) return 0;
                else return 1;
            }
            if (left == Hands.Scissors)
            {
                if (right == Hands.Paper) return 0;
                else return 1;
            }
            throw new Exception("Impossible combination of hands");
        }
    }
}
