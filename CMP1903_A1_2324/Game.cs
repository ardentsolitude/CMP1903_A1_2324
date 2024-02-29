using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        public Game()
        {
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();

            int result1 = rollDice(die1);
            Thread.Sleep(1); //Due to the way random numbers are done, if they are called too close together, they get the same result.
            int result2 = rollDice(die2);
            Thread.Sleep(1);
            int result3 = rollDice(die3);

            int sumResults = result1 + result2 + result3;

            Console.WriteLine($"The Sum of All Rolls is {sumResults}.");


        }


        //Methods

        public void playGame()
        {
            ;
        }

        public int rollDice(Die die) //I don't know why I made this function
        {
            int result = die.rollDie();
            return result;
        }
    }
}
