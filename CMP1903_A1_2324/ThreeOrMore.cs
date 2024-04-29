using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324 {
	internal class ThreeOrMore : Game {
		public ThreeOrMore() {
			/*
            Three or More
            5 x dice
            Rules:
	        Roll all 5 dice hoping for a 3-of-a-kind or better.
	        If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	        3-of-a-kind: 3 points
	        4-of-a-kind: 6 points
	        5-of-a-kind: 12 points
	        First to a total of 20.
            */

			//I did some maths to this and the odds of rolling a pair with 5 dice is about 46% 
			//The odds of rolling none of the same number is much lower, at about 9%

		}

		public override void playGame(int playerCount, int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			Die die1 = new Die();
			Die die2 = new Die();
			Die die3 = new Die();
			Die die4 = new Die();
			Die die5 = new Die();

			List<Die> dieList = new List<Die>();
			dieList.Add(die1);
			dieList.Add(die2);
			dieList.Add(die3);
			dieList.Add(die4);
			dieList.Add(die5);

			int p1Score = 0; //Player 1 score
			int p2Score = 0; //player 2 score
			bool gameOver = false; //flips to true when a score exceeds 20
			int playerTurn = 1; //current player's turn. 0 = player 1, 1 = player 2/computer
			bool singlePlayer = false; //true = playing vs computer, false = playing vs another player
			List<int> rolls = new List<int>(); //stores rolled values

			if (playerCount == 1) {
				singlePlayer = true;
			}

			while (!gameOver) {
				rolls.Clear(); //Reset rolled dice
				playerTurn++; //cycle player turn
				playerTurn = playerTurn % 2;

				//Console.WriteLine($"Player {playerTurn+1}'s Turn!");
				Console.WriteLine("\n");
				if (singlePlayer && playerTurn == 1) { //Computer controlled turn
					Console.WriteLine("\n\nComputer's Turn!");
					Console.WriteLine($"Computer's Score Is {p2Score}");
				}

				else { //Player controlled turn
					Console.WriteLine($"\n\nPlayer {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
					Console.ReadLine();
					if (playerTurn == 0) {
						Console.WriteLine($"Player 1's Current Score Is {p1Score}");
					}
					else if (playerTurn == 1 && !singlePlayer) {
						Console.WriteLine($"Player 2's Current Score Is {p2Score}");
					}
				}

				rolls = rollDice(dieList); //Not to be confused with rollDie() in Die.cs

				//outputRolls(rolls);

				if (playerTurn == 0) {
					p1Score = p1Score + checkRolls(rolls, dieList, false, playerTurn, singlePlayer);
				}
				else if (playerTurn == 1) {
					p2Score = p2Score + checkRolls(rolls, dieList, false, playerTurn, singlePlayer);
				}

				if (playerTurn == 0) {
					Console.WriteLine($"Your Current Score Is {p1Score}");
				}
				else if (playerTurn == 1) {
					Console.WriteLine($"Your Current Score Is {p2Score}");
				}

				if (p1Score >= 20 || p2Score >= 20) {
					gameOver = true;
				}

			}

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
			updateStats(winningScore, "Threes", winner, p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
			//returnToMenu(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);


		}


		public List<int> rollDice(List<Die> dieList) {
			List<int> rolls = new List<int>();
			foreach (var die in dieList) { //Initial die roll
				rolls.Add(die.rollDie());
				Thread.Sleep(1);
			}
			return rolls;
		}



		public void outputRolls(List<int> rolls) {
			Console.Write("You Rolled ");
			foreach (var roll in rolls) {
				Console.Write($"{roll} ");
			}
			Console.WriteLine("\n");
		}

		public int checkRolls(List<int> rolls, List<Die> dieList, bool alreadyRerolled, int playerTurn, bool singlePlayer) { //Check rolls for duplicates
			rolls.Sort(); //Sort the rolls so they're easier to read for the user.
			outputRolls(rolls);
			int[] rollCounts = new int[6]; //how many times each roll appears in the list
										   //outputRolls(rolls);
			int points = 0; //how many points scored
			bool rolledPair = false; //has a pair been rolled, so doesnt have to reroll for having two pairs in a sequence e.g. 1,1,3,3,4
			int pairValue = 0; //Number that has been rolled twice
			for (int i = 1; i < 7; i++) {
				int count = rolls.Where(temp => temp.Equals(i)).Select(temp => temp).Count();
				rollCounts[i - 1] = count;
				if (count == 2) {
					pairValue = i;
					rolledPair = true;

				}



				Debug.Assert(rolledPair = false, $"Player {playerTurn + 1} Rolled A Double. Log Saved To Documents. Check Log File For More Information. ");

			}

			//Console.WriteLine($"Already Rerolled: {alreadyRerolled}\nRolled Pair: {rolledPair}\nPair Value: {pairValue}");

			foreach (var count in rollCounts) {
				if (count == 5) { //Doing this as an if/else rather than a switch case because the order of execution matters
					Console.WriteLine("You Rolled Five Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 12) {
							points = 12;
						}
					}

				}
				else if (count == 4) {
					Console.WriteLine("You Rolled Four Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 6) {
							points = 6;
						}
					}

				}
				else if (count == 3) {
					Console.WriteLine("You Rolled Three Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 3) {
							points = 3;
						}
					}
				}
				else if (count == 2 && rolledPair == true) {
					Console.WriteLine("You Rolled A Pair!");
					//Reroll all or limited number
					rolledPair = true; //rolled a pair
					if (alreadyRerolled == false) { //Can't reroll more than once
						alreadyRerolled = true;
						int rerollChoice = 0;
						if (singlePlayer == true && playerTurn == 1) {
							Random random = new Random();
							rerollChoice = random.Next(1, 2); //randomly decide to reroll all or some as computer
						}
						else {

							bool rerollChoiceMade = false;

							while (rerollChoiceMade != true) {
								Console.WriteLine("\n---------REROLL----------");
								Console.WriteLine("Enter 1 To Reroll All Dice. \nEnter 2 To Reroll All Remaining Dice.");
								string rerollChoiceStr = Console.ReadLine();
								if (int.TryParse(rerollChoiceStr, out _)) { //Check if input is an integer
									rerollChoice = int.Parse(rerollChoiceStr);
									if (rerollChoice > 0 && rerollChoice < 3) { //Check if input is between accepted values
										rerollChoiceMade = true;
									}
									else {
										Console.WriteLine("Invalid Input. Please Try Again.");
									}
								}
								else {
									Console.WriteLine("Invalid Input. Please Try Again.");
								}
							}
						}

						var newRolls = rollDice(dieList);
						//outputRolls(rolls);
						//outputRolls(newRolls);
						switch (rerollChoice) {
							case 1: //Reroll all dice
								points = checkRolls(newRolls, dieList, true, playerTurn, singlePlayer);
								break;
							case 2: //Reroll some dice
								newRolls.RemoveAt(3); //I couldn't figure out how to only reroll some of the dice, 
													  //so removing two rolls and replacing them with the original values does the same thing
													  //If its stupid and it works
								newRolls.RemoveAt(3);
								newRolls.Insert(0, pairValue);
								newRolls.Insert(0, pairValue);
								//outputRolls(newRolls);
								points = checkRolls(newRolls, dieList, alreadyRerolled, playerTurn, singlePlayer);
								break;
						}
					}
				}

				else {
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 0) {
							points = 0;
						}
					}
				}

			}
			if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
				Console.WriteLine($"You Scored {points} Points!");
			}
			return points;
		}





		//Testing Version

		public override void playGame(int playerCount, bool testingMode, string logSaveLocation, int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			Die die1 = new Die();
			Die die2 = new Die();
			Die die3 = new Die();
			Die die4 = new Die();
			Die die5 = new Die();

			List<Die> dieList = new List<Die>();
			dieList.Add(die1);
			dieList.Add(die2);
			dieList.Add(die3);
			dieList.Add(die4);
			dieList.Add(die5);

			int p1Score = 0; //Player 1 score
			int p2Score = 0; //player 2 score
			bool gameOver = false; //flips to true when a score exceeds 20
			int playerTurn = 1; //current player's turn. 0 = player 1, 1 = player 2/computer
			bool singlePlayer = false; //true = playing vs computer, false = playing vs another player
			List<int> rolls = new List<int>(); //stores rolled values

			if (playerCount == 1) {
				singlePlayer = true;
			}

			while (!gameOver) {
				rolls.Clear(); //Reset rolled dice
				playerTurn++; //cycle player turn
				playerTurn = playerTurn % 2;

				//Console.WriteLine($"Player {playerTurn+1}'s Turn!");
				Console.WriteLine("\n");
				if (singlePlayer && playerTurn == 1) { //Computer controlled turn
					Console.WriteLine("\n\nComputer's Turn!");
					Console.WriteLine($"Computer's Score Is {p2Score}");
				}

				else { //Player controlled turn
					Console.WriteLine($"\n\nPlayer {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
					Console.ReadLine();
					if (playerTurn == 0) {
						Console.WriteLine($"Player 1's Current Score Is {p1Score}");
					}
					else if (playerTurn == 1 && !singlePlayer) {
						Console.WriteLine($"Player 2's Current Score Is {p2Score}");
					}
				}

				rolls = rollDice(dieList); //Not to be confused with rollDie() in Die.cs

				//outputRolls(rolls);

				if (playerTurn == 0) {
					p1Score = p1Score + checkRolls(rolls, dieList, false, playerTurn, singlePlayer, testingMode, logSaveLocation);
				}
				else if (playerTurn == 1) {
					p2Score = p2Score + checkRolls(rolls, dieList, false, playerTurn, singlePlayer, testingMode, logSaveLocation);
				}

				if (playerTurn == 0) {
					Console.WriteLine($"Your Current Score Is {p1Score}");
				}
				else if (playerTurn == 1) {
					Console.WriteLine($"Your Current Score Is {p2Score}");
				}

				if (p1Score >= 20 || p2Score >= 20) {
					gameOver = true;
				}

			}

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
			updateStats(winningScore, "Threes", winner, p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
			//returnToMenu(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);


		}

		public int checkRolls(List<int> rolls, List<Die> dieList, bool alreadyRerolled, int playerTurn, bool singlePlayer, bool testingMode, string logSaveLocation) { //Check rolls for duplicates
			rolls.Sort(); //Sort the rolls so they're easier to read for the user.
			outputRolls(rolls);
			int[] rollCounts = new int[6]; //how many times each roll appears in the list
										   //outputRolls(rolls);
			int points = 0; //how many points scored
			bool rolledPair = false; //has a pair been rolled, so doesnt have to reroll for having two pairs in a sequence e.g. 1,1,3,3,4
			int pairValue = 0; //Number that has been rolled twice
			for (int i = 1; i < 7; i++) {
				int count = rolls.Where(temp => temp.Equals(i)).Select(temp => temp).Count();
				rollCounts[i - 1] = count;
				if (count == 2) {
					pairValue = i;
					rolledPair = true;

				}

				if (testingMode == true) {
					if (rolledPair == true) {
						try {
							Console.WriteLine(logSaveLocation);
							using (StreamWriter logWriter = File.AppendText(logSaveLocation + "\\logFile.txt")) {
								writeLog(pairValue, logWriter);
							}
						}
						catch (DirectoryNotFoundException error) {
							Console.WriteLine($"{error}! Invalid File Path!");
						}
					}
				}

				Debug.Assert(rolledPair = false, $"Player {playerTurn + 1} Rolled A Double. Log Saved To Documents. Check Log File For More Information. ");

			}

			//Console.WriteLine($"Already Rerolled: {alreadyRerolled}\nRolled Pair: {rolledPair}\nPair Value: {pairValue}");

			foreach (var count in rollCounts) {
				if (count == 5) { //Doing this as an if/else rather than a switch case because the order of execution matters
					Console.WriteLine("You Rolled Five Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 12) {
							points = 12;
						}
					}

				}
				else if (count == 4) {
					Console.WriteLine("You Rolled Four Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 6) {
							points = 6;
						}
					}

				}
				else if (count == 3) {
					Console.WriteLine("You Rolled Three Of A Kind!");
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 3) {
							points = 3;
						}
					}
				}
				else if (count == 2 && rolledPair == true) {
					Console.WriteLine("You Rolled A Pair!");
					//Reroll all or limited number
					rolledPair = true; //rolled a pair
					if (alreadyRerolled == false) { //Can't reroll more than once
						alreadyRerolled = true;
						int rerollChoice = 0;
						if (singlePlayer == true && playerTurn == 1) {
							Random random = new Random();
							rerollChoice = random.Next(1, 2); //randomly decide to reroll all or some as computer
						}
						else {

							bool rerollChoiceMade = false;

							while (rerollChoiceMade != true) {
								Console.WriteLine("\n---------REROLL----------");
								Console.WriteLine("Enter 1 To Reroll All Dice. \nEnter 2 To Reroll All Remaining Dice.");
								string rerollChoiceStr = Console.ReadLine();
								if (int.TryParse(rerollChoiceStr, out _)) { //Check if input is an integer
									rerollChoice = int.Parse(rerollChoiceStr);
									if (rerollChoice > 0 && rerollChoice < 3) { //Check if input is between accepted values
										rerollChoiceMade = true;
									}
									else {
										Console.WriteLine("Invalid Input. Please Try Again.");
									}
								}
								else {
									Console.WriteLine("Invalid Input. Please Try Again.");
								}
							}
						}

						var newRolls = rollDice(dieList);
						//outputRolls(rolls);
						//outputRolls(newRolls);
						switch (rerollChoice) {
							case 1: //Reroll all dice
								points = checkRolls(newRolls, dieList, true, playerTurn, singlePlayer, false, logSaveLocation);
								break;
							case 2: //Reroll some dice
								newRolls.RemoveAt(3); //I couldn't figure out how to only reroll some of the dice, 
													  //so removing two rolls and replacing them with the original values does the same thing
													  //If its stupid and it works
								newRolls.RemoveAt(3);
								newRolls.Insert(0, pairValue);
								newRolls.Insert(0, pairValue);
								//outputRolls(newRolls);
								points = checkRolls(newRolls, dieList, alreadyRerolled, playerTurn, singlePlayer, false, logSaveLocation);
								break;
						}
					}
				}

				else {
					if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
						if (points <= 0) {
							points = 0;
						}
					}
				}

			}
			if (rolledPair == true && alreadyRerolled == true || rolledPair == false) {
				Console.WriteLine($"You Scored {points} Points!");
			}
			return points;
		}
		void writeLog(int pairValue, TextWriter logWriter) {
			logWriter.WriteLine($"\n Time: {DateTime.Now.ToString("HH:mm:ss")}\nRolled a Pair Of {pairValue}s."); //Write to log file
		}
	}
}

