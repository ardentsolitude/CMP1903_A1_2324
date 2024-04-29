using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324 {
	internal class Game {
		/*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */


		/*
        Rules:
        Dice Games

        Sevens Out
        2 x dice
        Rules:
	        Roll the two dice, noting the total rolled each time.
	        If it is a 7 - stop.
	        If it is any other number - add it to your total.
		        If it is a double - add double the total to your score (3,3 would add 12 to your total)

        Three or More
        5 x dice
        Rules:
	        Roll all 5 dice hoping for a 3-of-a-kind or better.
	        If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	        3-of-a-kind: 3 points
	        4-of-a-kind: 6 points
	        5-of-a-kind: 12 points
	        First to a total of 20.


        Player can choose either game to play through a menu.
        Play with partner (on the same computer), or against the computer.
        Should be a console implementation - but scope for extending it to a GUI application should be possible.


        */

		//Methods

		/// <summary> 
		/// Creates 3 die objects, rolls them, and sums the rolls 
		/// </summary>

		//Note: The below section of code is from part 1 of this assignment. It is not used for part 2
		/*
        public int playGame() {

            
            

            //Creating 3 die objects
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            int result1 = die1.roll();

            Thread.Sleep(1); //Because random numbers are calculated using the system clock, calling random multiple times in the same instance
                             //will return the same value.
                             //Therefore a small delay is needed to prevent this from happening.

            int result2 = die2.roll();
            Thread.Sleep(1);

            int result3 = die3.roll();

            int sumResults = result1 + result2 + result3; //Summing results - self explanatory

            Console.WriteLine($"The Sum of All Rolls is {sumResults}.");

            return sumResults; //This return is only used for comparing the testing value with the expected results
            
            return 0;
        }
        */


		//Part II Starts Here

		public Game() {
			//gameStart(); 
		}

		public void gameStart(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) { //Starting point for the games. Calls game menu,
														  //program returns here after completing a game
			int menuChoice = gameMenu(); //Open main menu

			//Console.WriteLine($"Menu Choice = {menuChoice}");

			switch (menuChoice) {
				case 1: //Select Game
					selectGame(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 2: //View Rules
					displayRules(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 3: //View Statistics
					displayStats(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 4: //Test Game
					Console.WriteLine("Testing :)");
					Testing testing = new Testing();
					string logSaveLocation = $"C:\\Users\\{Environment.UserName}\\Documents"; //Default save location
					testing.testGame(p1wins, p2wins, sevenGames, threeGames, sevenHighScore, logSaveLocation);
					break;
				case 5: //Quit
					Console.WriteLine("Exiting...");
					break;
			}
		}

		//Selection menu
		/*
         * Display Rules
         * Select Game
         *      Sevens Out
         *      Three or More
         * Statistics
         * Testing
         * Quit
         * */
		public int gameMenu() {
			int menuChoice = 0;
			bool menuChoiceMade = false;

			while (menuChoiceMade != true) {
				Console.WriteLine("\n----------MENU---------");
				Console.WriteLine("Enter 1 To Select A Game. \nEnter 2 To View Rules. \nEnter 3 View Statistics. \nEnter 4 For Testing. \nEnter 5 To Exit.");
				string menuChoiceStr = Console.ReadLine();
				if (int.TryParse(menuChoiceStr, out _)) { //Check if input is an integer
					menuChoice = int.Parse(menuChoiceStr);
					if (menuChoice > 0 && menuChoice < 6) { //Check if input is between accepted values
						menuChoiceMade = true;
					}
					else {
						Console.WriteLine("Invalid Input. Please Try Again.");
					}
				}
				else {
					Console.WriteLine("Invalid Input. Please Try Again.");
				}
			}

			return menuChoice;
		}

		public void selectGame(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			int gameChoice = 0;
			bool gameChoiceMade = false;
			int playerCount = 0;

			while (gameChoiceMade != true) {
				Console.WriteLine("\n----------GAMES---------");
				Console.WriteLine("Enter 1 To Play Sevens Out. \nEnter 2 To Play Three Or More. \nEnter 3 To Return To Menu.");
				string gameChoiceStr = Console.ReadLine();
				if (int.TryParse(gameChoiceStr, out _)) { //Check if input is an integer
					gameChoice = int.Parse(gameChoiceStr);
					if (gameChoice > 0 && gameChoice < 4) { //Check if input is between accepted values
						gameChoiceMade = true;
					}
					else {
						Console.WriteLine("Invalid Input. Please Try Again.");
					}
				}
				else {
					Console.WriteLine("Invalid Input. Please Try Again.");
				}
			}

			switch (gameChoice) {
				case 1:
					Console.WriteLine("\nSevens Out Selected.\n");
					playerCount = playerChoice();
					SevensOut sevens = new SevensOut();
					sevens.playGame(playerCount, false, "", p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 2:
					Console.WriteLine("\nThree Or More Selected.\n");
					playerCount = playerChoice();
					ThreeOrMore threes = new ThreeOrMore();
					threes.playGame(playerCount, false, "", p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 3:
					Console.WriteLine("\n");
					gameStart(p1wins, p2wins, sevenGames, threeGames, sevenHighScore); //Return to start
					break;
			}
		}

		//Input number of players (player vs computer, player vs player)
		public int playerChoice() {
			int playerCount = 0;
			bool playerChoiceMade = false;

			while (playerChoiceMade != true) {
				Console.WriteLine("\n----NUMBER OF PLAYERS----");
				Console.WriteLine("Enter 1 For Player vs Computer.\nEnter 2 For Player vs Player.");
				string playerChoiceStr = Console.ReadLine();
				if (int.TryParse(playerChoiceStr, out _)) { //Check if input is an integer
					playerCount = int.Parse(playerChoiceStr);
					if (playerCount > 0 && playerCount < 3) { //Check if input is between accepted values
						playerChoiceMade = true;
					}
					else {
						Console.WriteLine("Invalid Input. Please Try Again.");
					}
				}
				else {
					Console.WriteLine("Invalid Input. Please Try Again.");
				}
			}
			return playerCount;
		}

		//Display rules list
		public void displayRules(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			int rulesChoice = 0;
			bool rulesChoiceMade = false;

			while (rulesChoiceMade != true) {
				Console.WriteLine("\n----------RULES---------");
				Console.WriteLine("Enter 1 For Sevens Out. \nEnter 2 For Three Or More.");
				string rulesChoiceStr = Console.ReadLine();
				if (int.TryParse(rulesChoiceStr, out _)) { //Check if input is an integer
					rulesChoice = int.Parse(rulesChoiceStr);
					if (rulesChoice > 0 && rulesChoice < 3) { //Check if input is between accepted values
						rulesChoiceMade = true;
					}
					else {
						Console.WriteLine("Invalid Input. Please Try Again.");
					}
				}
				else {
					Console.WriteLine("Invalid Input. Please Try Again.");
				}
			}

			switch (rulesChoice) {
				case 1:
					Console.WriteLine("\n\nRules of Sevens Out: \nRoll two six-sided dice. \nIf the sum is equal to seven, stop. \nOtherwise, add the sum to your score. \nIf the sum is a double, add the sum to your score again.");
					break;
				case 2:
					Console.WriteLine("\n\nRules of Three or More: \nRoll five six-sided dice. \nNo Matches: No Points. \nTwo of a Kind: Either re-roll all remaining dice, or re-roll all dice. \nThree of a Kind: Score 3 points. \nFour of a Kind: Score 6 points. \nFive of a Kind: Score 12 points. \nThe first player to reach 20 points wins.");
					break;
			}
			Console.WriteLine("\n");
			gameStart(p1wins, p2wins, sevenGames, threeGames, sevenHighScore); // return back to game menu after viewing rules
		}

		//Regular Version
		public virtual void playGame(int playerCount, int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			throw new NotImplementedException("No Game Selected! Run From SevensOut.cs or ThreeOrMore.cs Instead.");
		}

		//Test Version
		public virtual void playGame(int playerCount, bool testingMode, string logSaveLocation, int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			throw new NotImplementedException("No Game Selected! Run From SevensOut.cs or ThreeOrMore.cs Instead.");
		}

		public void returnToMenu(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) { //Return to main menu after game is complete - used only by inherited classes
			int menuChoice = 0;
			bool menuChoiceMade = false;

			//updateStats(score, gameType);

			while (menuChoiceMade != true) {
				Console.WriteLine("\nEXIT");
				Console.WriteLine("Enter 1 To Return To The Main Menu. \nEnter 2 To Quit.");
				string menuChoiceStr = Console.ReadLine();
				if (int.TryParse(menuChoiceStr, out _)) { //Check if input is an integer
					menuChoice = int.Parse(menuChoiceStr);
					if (menuChoice > 0 && menuChoice < 3) { //Check if input is between accepted values
						menuChoiceMade = true;
					}
					else {
						Console.WriteLine("Invalid Input. Please Try Again.");
					}
				}
				else {
					Console.WriteLine("Invalid Input. Please Try Again.");
				}
			}
			switch (menuChoice) {
				case 1:
					gameStart(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 2:
					break;
			}

		}

		public virtual void writeLog() {

		}
		public void displayStats(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) { //Output stats for player
			Console.WriteLine($"You Have Played {sevenGames} Game(s) of Sevens Out And {threeGames} Game(s) Of Three Or More. \nPlayer 1 Has Won {p1wins} Times And Player 2 Has Won {p2wins} Times. \nThe Highest Score Achieved In Sevens Out Is {sevenHighScore} Points.");
			gameStart(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
		}

		public void updateStats(int score, string gameType, int winner, int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {
			//Updates stats after each game.
			//This is unfathomably scuffed
			//This is the reason for all the passing of varibales across basically every function
			//This is responsible for so many headaches

			if(gameType == "Sevens") {
				sevenGames++;
				if(score > sevenHighScore) {
					sevenHighScore = score;
				}
			}
			else if(gameType == "Threes") {
				threeGames++;
			}

			if(winner == 1) {
				p1wins++;
			}
			else if(winner == 2) {
				p2wins++;
			}

			returnToMenu(p1wins, p2wins, sevenGames, threeGames, sevenHighScore); //Return back to main menu

		}
		



	}

	/* A Failed attempt to implement interfaces. Very sad :(
	public interface IPlayable() {
		void playGame(int playerCount);
	}
	*/
}
