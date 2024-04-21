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
        public int playGame() {

            //Note: The below section of code is from part 1 of this assignment. It is not used for part 2
            /*

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
            */
            return 0;
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
                Console.WriteLine("----------MENU----------");
                Console.WriteLine("Enter 1 To Select A Game. \nEnter 2 To View Rules. \nEnter 3 View Statistics. \nEnter 4 For Testing. \nEnter 5 To Exit.");
                string menuChoiceStr = Console.ReadLine();
                if (int.TryParse(menuChoiceStr, out _)) { //Check if input is an integer
                    menuChoice = int.Parse(menuChoiceStr);
                    if (menuChoice > 0 && menuChoice < 6) { //Check if input is between accpeted values
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

        public int selectGame() {
            return 0; //placeholder
        }

        //Display rules list
        public void displayRules() {
            int rulesChoice = 0;
            bool rulesChoiceMade = false;

            while (rulesChoiceMade != true) {
                Console.WriteLine("----------RULES----------");
                Console.WriteLine("Enter 1 For Sevens Out. \nEnter 2 For Three Or More.");
                string rulesChoiceStr = Console.ReadLine();
                if (int.TryParse(rulesChoiceStr, out _)) { //Check if input is an integer
                    rulesChoice = int.Parse(rulesChoiceStr);
                    if (rulesChoice > 0 && rulesChoice < 3) { //Check if input is between accpeted values
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
                    Console.WriteLine("\nRoll two six-sided dice. \nIf the sum is equal to seven, stop. \nOtherwise, add the sum to your score. \nIf the sum is a double, add the sum to your score again."); 
                    break;
                case 2: 
                    Console.WriteLine("\nRoll five six-sided dice. \nNo Matches: No Points. \nTwo of a Kind: Either re-roll all non-pair dice, or re-roll all dice. \nThree of a Kind: Score 3 points. \nFour of a Kind: Score 6 points. \nFive of a Kind: Score 12 points. \nThe first player to reach 20 points wins.");
                    break;
            }
        }

        public void displayStatistics() {

        }
    }
}
