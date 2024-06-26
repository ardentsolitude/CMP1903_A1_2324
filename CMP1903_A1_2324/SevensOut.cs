﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

		/// <summary>
		/// Play a game of sevens out
		/// </summary>
		/// <param name="playerCount"></param>
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
						if (die1roll + die1roll != 7) {
							p1Score = p1Score + die1roll + die2roll;
						}
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
					if (die1roll == die2roll) { //if double
						Console.WriteLine("Rolled A Double! \nDouble Points!");
						p2Score = p2Score + (die1roll + die2roll) * 2; //add double the points
					}
					else {
						if (die1roll + die1roll != 7) { //if not double
							p2Score = p2Score + die1roll + die2roll; //add sum
						}
					}

					if (die1roll + die2roll == 7) { //I'm assuming that you score 0 points on a 7
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
			int winner = 0;
			int winningScore = 0;
			if (p1Score > p2Score) {
				Console.WriteLine($"Player 1 Wins With A Score Of {p1Score}!");
				winner = 1;
				winningScore = p1Score;
			}
			else if (p2Score > p1Score && singlePlayer == false) {
				Console.WriteLine($"Player 2 Wins With A Score Of {p2Score}!");
				winner = 2;
				winningScore = p2Score;
			}
			else if (p2Score > p1Score && singlePlayer == true) {
				Console.WriteLine($"The Computer Wins With A Score Of {p2Score}!");
				winner = 2;
				winningScore = p2Score;
			}
			else {
				Console.WriteLine($"Both Players Tie With A Score Of {p1Score}!");
				winningScore = p1Score;
			}

			if (winner == 1) {
				Console.WriteLine($"Player 2 Loses With A Score Of {p2Score}.");
			}
			else if (winner == 2) {
				Console.WriteLine($"Player 1 Loses With A Score Of {p1Score}.");

			}

			//Statistics handling

			//Exit
			Stats.updateStats(winningScore, "Sevens", winner);
			returnToMenu();
		}
		/// <summary>
		/// Write a log of when a 7 is rolled to a text file
		/// </summary>
		/// <param name="die1"></param>
		/// <param name="die2"></param>
		/// <param name="logWriter"></param>
		/// <param name="playerTurn"></param>
		public void writeLog(int die1, int die2, TextWriter logWriter, int playerTurn) { //Write info to log
			logWriter.WriteLine($"\nDate: {DateTime.Today.ToString("d")}\nTime: {DateTime.Now.ToString("HH:mm:ss")}\nPlayer {playerTurn + 1} Rolled 7 ({die1}, {die2})\n"); //Write to log file
		}



		//Testing Version - Records Logs
		/// <summary>
		/// Play a game of sevens out - records logs
		/// </summary>
		/// <param name="playerCount"></param>
		/// <param name="testingMode"></param>
		/// <param name="logSaveLocation"></param>
		public override void playGame(int playerCount, bool testingMode, string logSaveLocation) {
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
					//because in testing I found that without a delay, the game would progress faster than the player could keep up
					int die2roll = die2.rollDie();


					//Turn Start
					Console.WriteLine($"\nPlayer {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
					Console.ReadLine();
					Console.WriteLine($"Player {playerTurn + 1} Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.\n");

					if (die1roll == die2roll) {
						Console.WriteLine("Rolled A Double! \nDouble Points!");
						p1Score = p1Score + (die1roll + die2roll) * 2;
					}
					else {
						if (die1roll + die1roll != 7) {
							p1Score = p1Score + die1roll + die2roll;
						}
					}

					if (die1roll + die2roll == 7) {
						Console.WriteLine("You Got A 7! \nYou're Out!\n");
						p1Out = true;

					}

					//Log Recording
					if (testingMode == true) {
						if (p1Out == true) {
							//string logSaveLocation = System.IO.Directory.GetCurrentDirectory();
							try {
								//Console.WriteLine(logSaveLocation);
								using (StreamWriter logWriter = File.AppendText(logSaveLocation + "\\logFile.txt")) {
									writeLog(die1roll, die2roll, logWriter, playerTurn); 
								}
							}
							catch (DirectoryNotFoundException error) {
								Console.WriteLine($"{error}! Invalid File Path!");
							}

						}
						//Debug.assert is after log saving because if it is before, it can prevent the log from being written
						Debug.Assert(p2Out == false, $"Player 2 Rolled A Seven. Log Saved To {logSaveLocation}. Check Log File For More Information.");

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
						if (die1roll + die1roll != 7) {
							p2Score = p2Score + die1roll + die2roll;
						}
					}

					if (die1roll + die2roll == 7) {
						Console.WriteLine("You Got A 7! \nYou're Out!\n");
						p2Out = true;
					}

					if (testingMode == true) {
						if (p2Out == true) {
							//string logSaveLocation = System.IO.Directory.GetCurrentDirectory();
							//Console.WriteLine(logSaveLocation);
							using (StreamWriter logWriter = File.AppendText(logSaveLocation + "\\logFile.txt")) {
								writeLog(die1roll, die2roll, logWriter, playerTurn);
							}
						}
						Debug.Assert(p2Out == false, $"Player 2 Rolled A Seven. Log Saved To {logSaveLocation}. Check Log File For More Information.");

					}

					Console.WriteLine($"Player 2's Score Is {p2Score}.\n");
				}


				if (p1Out && p2Out) {
					gameEnded = true;
				}
			}

			//I am not proud of the above code

			//End of game and calculating winner
			Console.WriteLine("\nGame Over!\n");
			int winner = 0;
			int winningScore = 0;
			if (p1Score > p2Score) {
				Console.WriteLine($"Player 1 Wins With A Score Of {p1Score}!");
				winner = 1;
				winningScore = p1Score;
			}
			else if (p2Score > p1Score && singlePlayer == false) {
				Console.WriteLine($"Player 2 Wins With A Score Of {p2Score}!");
				winner = 2;
				winningScore = p2Score;
			}
			else if (p2Score > p1Score && singlePlayer == true) {
				Console.WriteLine($"The Computer Wins With A Score Of {p2Score}!");
				winner = 2;
				winningScore = p2Score;
			}
			else {
				Console.WriteLine($"Both Players Tie With A Score Of {p1Score}!");
				winningScore = p1Score;
			}

			if (winner == 1) {
				Console.WriteLine($"Player 2 Loses With A Score Of {p2Score}.");
			}
			else if (winner == 2) {
				Console.WriteLine($"Player 1 Loses With A Score Of {p1Score}.");

			}

			//Statistics handling

			//Exit
			Stats.updateStats(winningScore, "Sevens", winner); //Update statistics
			returnToMenu(); //Go back to main menu

		}
	}
}
