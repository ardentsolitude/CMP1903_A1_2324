using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324 {
	internal class SevensOut : Game {
		public SevensOut() {
			/*
            Sevens Out
            2 x dice
            Rules:
	        Roll the two dice, noting the total rolled each time.
	        If it is a 7 - stop.
	        If it is any other number - add it to your total.
		    If it is a double - add double the total to your score (3,3 would add 12 to your total)
            */




		}

		public override void playGame(int playerCount) {
			Die die1 = new Die();
			Die die2 = new Die();
			bool singlePlayer = false;

			if (playerCount == 1) {
				singlePlayer = true;
			}

			int playerTurn = 1;
			int p1Score = 0;
			int p2Score = 0;
			bool gameEnded = false;
			bool p1Out = false;
			bool p2Out = false;
			while (!gameEnded) {
				playerTurn++;
				playerTurn = playerTurn % 2;
				//Console.WriteLine($"playerTurn = {playerTurn}");
				if (playerTurn == 0 && !p1Out) {

					//This was originally a separate function, but I merged it int0 this one to make it easier to work with
					int die1roll = die1.rollDie();
					Thread.Sleep(500); //Prevents duplicate numbers, also slows pace of game to for readability reasons
					int die2roll = die2.rollDie();

					Console.WriteLine($"\nPlayer {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
					Console.ReadLine();
					Console.WriteLine($"Player {playerTurn + 1} Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.\n");

					if (die1roll == die2roll) {
						Console.WriteLine("Rolled A Double! \nDouble Points!");
						p1Score = p1Score + (die1roll + die2roll) * 2;
					}
					else {
						p1Score = p1Score + die1roll + die2roll;
					}

					if (die1roll + die2roll == 7) {
						Console.WriteLine("You Got A 7! \nYou're Out!\n");
						p1Out = true;
					}

					Console.WriteLine($"Player 1's Score Is {p1Score}.\n");



				}
				else if (playerTurn == 1 && !p2Out) {                   //Player 2 (Human or Computer)

					int die1roll = die1.rollDie();
					Thread.Sleep(500); //Prevents duplicate numbers, also slows pace of game to for readability reasons
					int die2roll = die2.rollDie();
					if (singlePlayer && playerTurn == 1) { //Computer controlled turn
						Console.WriteLine("\nComputer's Turn!");
						Console.WriteLine($"Computer Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.\n");
					}

					else { //Player controlled turn
						Console.WriteLine($"\nPlayer {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
						Console.ReadLine();
						Console.WriteLine($"Player {playerTurn + 1} Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.\n");
					}
					if (die1roll == die2roll) {
						Console.WriteLine("Rolled A Double! \nDouble Points!");
						p2Score = p2Score + (die1roll + die2roll) * 2;
					}
					else {
						p2Score = p2Score + die1roll + die2roll;
					}

					if (die1roll + die2roll == 7) {
						Console.WriteLine("You Got A 7! \nYou're Out!\n");
						p2Out = true;
					}

					Console.WriteLine($"Player 2's Score Is {p2Score}.\n");
				}


				if (p1Out && p2Out) {
					gameEnded = true;
				}
			}

			//I am not proud of the above code


			Console.WriteLine("\nGame Over!\n");
			if (p1Score > p2Score) {
				Console.WriteLine($"Player 1 Wins With A Score Of {p1Score}!");
			}
			else if (p2Score > p1Score && singlePlayer == false) {
				Console.WriteLine($"Player 2 Wins With A Score Of {p2Score}!");
			}
			else if (p2Score > p1Score && singlePlayer == true) {
				Console.WriteLine($"The Computer Wins With A Score Of {p2Score}!");
			}
			else {
				Console.WriteLine($"Both Players Tie With A Score Of {p1Score}!");
			}

			//Statistics handling

			//Exit
			returnToMenu();
		}


	}
}
