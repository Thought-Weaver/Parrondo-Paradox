using System;
using System.Collections.Generic;

namespace ParrondoParadox
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			/* Set the initial variables */
			int position = 0, gamesWon = 0, gamesLost = 0, N = 1000000;
			double probability = 0;
			Random rand = new Random();
			
			/* Create a list of rules for the first game */
			List<int> orangeLeft = new List<int> { 2, 4, 12 }, 
				  orangeRight = new List<int> { 11 }, 
				  yellowLeft = new List<int> { 2, 3, 12 }, 
				  yellowRight = new List<int> { 7, 11 };
			
			/* Create a list of rules for the second game */
			List<int> secondOrangeLeft = new List<int> { 2, 3, 12 }, 
				  secondOrangeRight = new List<int> { 7, 11 }, 
				  secondYellowLeft = new List<int> { 2, 4, 12 }, 
				  secondYellowRight = new List<int> { 11 };

			/* While the player has not reached the end of the 1D board */
			while (position != -2 || position != 2)
			{
				/* Flip a coin for which rules to use */
				int coinToss = rand.Next(1, 3);
				/* Roll a die for what move to make */
				int diceRoll = rand.Next(1, 13);

				if (coinToss == 1)
				{
					if (position == 0)
					{
						if (orangeLeft.Contains(diceRoll))
							position--;
						else if (orangeRight.Contains(diceRoll))
							position++;
					}
					else if (position == -1 || position == 1)
					{
						if (yellowLeft.Contains(diceRoll))
							position--;
						else if (yellowRight.Contains(diceRoll))
							position++;
					}
				}
				else 
				{
					if (position == 0)
					{
						if (secondOrangeLeft.Contains(diceRoll))
							position--;
						else if (secondOrangeRight.Contains(diceRoll))
							position++;
					}
					else if (position == -1 || position == 1)
					{
						if (secondYellowLeft.Contains(diceRoll))
							position--;
						else if (secondYellowRight.Contains(diceRoll))
							position++;
					}
				}

				if (position == -2)
				{
					gamesLost++;
					position = 0;
					if (gamesLost != 0) probability = (double)gamesWon / gamesLost;
				}
				else if (position == 2)
				{
					gamesWon++;
					position = 0;
					if(gamesLost != 0) probability = (double)gamesWon / gamesLost;
				}

				if (gamesWon + gamesLost == N)
					break;
			}

			Console.WriteLine("Number of games played: " + (gamesWon + gamesLost) + 
					  "\nNumber of games lost: " + gamesLost + 
					  "\nNumber of games won: " + gamesWon + 
					  "\n\nApproximate probability of victory: " + probability);
			Console.Read();
		}
	}
}
