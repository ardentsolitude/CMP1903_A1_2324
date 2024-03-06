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

    //Methods

    /// <summary> 
    /// Creates 3 die objects, rolls them, and sums the rolls 
    /// </summary>
    public int playGame()
    {
      //Creating 3 die objects
      Die die1 = new Die();
      Die die2 = new Die();
      Die die3 = new Die();
      int result1 = die1.rollDie();

      Thread.Sleep(1); //Because random numbers are calculated using the system clock, calling random multiple times in the same instance
                       //will return the same value.
                       //Therefore a small delay is needed to prevent this from happening.

      int result2 = die2.rollDie();
      Thread.Sleep(1);
      
      int result3 = die3.rollDie();

      int sumResults = result1 + result2 + result3; //Summing results - self explanatory

      Console.WriteLine($"The Sum of All Rolls is {sumResults}.");

      return sumResults; //This return is only used for comparing the testing value with the expected results
    }
  }
}
