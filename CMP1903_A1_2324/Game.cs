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
      ;
    }


    //Methods

    /// <summary> 
    /// Creates 3 die objects, rolls them, and sums the rolls 
    /// </summary>
    public int playGame()
    {
      Die die1 = new Die();
      Die die2 = new Die();
      Die die3 = new Die();

      //int result1 = rollDice(die1); //This calls a function that calls another function.
      int result1 = die1.rollDie();
      Thread.Sleep(1); //Because random numbers are calculated using the system clock, calling random multiple times in the same instance will return the same value.
      //int result2 = rollDice(die2);
      int result2 = die2.rollDie();
      Thread.Sleep(1);
      //int result3 = rollDice(die3);
      int result3 = die3.rollDie();

      int sumResults = result1 + result2 + result3;

      Console.WriteLine($"The Sum of All Rolls is {sumResults}.");

      return sumResults;
    }

    /// <summary> 
    /// Calls the individual roll die functions of the dice 
    /// </summary>
    /// 
    /*
    public int rollDice(Die die) //I don't know why I made this function
    {
        int result = die.rollDie(); //It's bad but it works and when I tried to change it, everything broke.
        return result;
    }
    */
  }
}
