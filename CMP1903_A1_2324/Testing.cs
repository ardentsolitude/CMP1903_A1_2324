using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    internal class Testing {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        public Testing() {
            //Note: The below section of code is from part 1 of this assignment. It is not used for part 2

            /*
            Game gameTesting = new Game();
            Die dieTesting = new Die();

            //Test Game
            int testSum = gameTesting.playGame(); //Returns a number between 3 and 18 (3 lots of 1-6)
            Debug.Assert(testSum < 19, "Sum is Greater Than 18."); //Causes error if condition is not filled
            Debug.Assert(testSum > 2, "Sum is Less Than 3.");

            //Testing Die Roll
            int testResult = dieTesting.rollDie(); //Rolls 1 die, outputs random int from 1-6
            Debug.Assert(testResult < 7, "Number is Greater Than 6."); //Test conditions. 
            Debug.Assert(testResult > 0, "Number is Less Than 1.");
            */

		}
		 
			//Part II Starts Here :)

        public void testGame(int p1wins, int p2wins, int sevenGames, int threeGames, int sevenHighScore) {


			Console.WriteLine("\n--------TESTING--------");
			Game testingGame = new Game();
			SevensOut testSevens = new SevensOut();
			ThreeOrMore testThrees = new ThreeOrMore();

			int gameChoice = 0;
			bool gameChoiceMade = false;


			string logSaveLocation = $"C:\\Users\\{Environment.UserName}\\Documents"; //Default save location 

			while (gameChoiceMade != true) {
				Console.WriteLine($"Enter 1 To Test Sevens Out. \nEnter 2 To Test Three Or More. \nEnter 3 To Change Log File Path (Default Is {logSaveLocation}. \nEnter 4 To Show Current Save Location. \nEnter 5 To Return To Menu.");
				string gameChoiceStr = Console.ReadLine();
				if (int.TryParse(gameChoiceStr, out _)) { //Check if input is an integer
					gameChoice = int.Parse(gameChoiceStr);
					if (gameChoice > 0 && gameChoice < 6) { //Check if input is between accepted values
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
					testSevens.playGame(1, true, logSaveLocation, p1wins, p2wins, sevenGames, threeGames, sevenHighScore); //true activates testing mode, which logs certain results to a text file
												  //Because I added testing after writing both games, it was easier to do it like this,
												  //with Debug.Assert and writing a log file included in the actual games themselves.
					break;
				case 2:
					testThrees.playGame(1, true, logSaveLocation, p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 3:
					Console.WriteLine("Enter New Save Location. Use \\\\ Instead of \\ Or /: ");
					logSaveLocation = Console.ReadLine();
					testGame(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 4:
					Console.WriteLine(logSaveLocation);
					testGame(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;
				case 5:
					testingGame.returnToMenu(p1wins, p2wins, sevenGames, threeGames, sevenHighScore);
					break;

			}
		}





        //Method
    }
}
