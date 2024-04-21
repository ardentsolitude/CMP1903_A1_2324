using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
