using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
  internal class Die
  {
    /*
     * The Die class should contain one property to hold the current die value,
     * and one method that rolls the die, returns and integer and takes no parameters.
     */

    //Property

    private int result = 0; //Result of the roll of the die

    public int getValue //Getter/Setter for the die result
    {
      get {return result; }
      set {result = value;}
    }
    //Method
    /// <summary>
    /// Generates a random number from 1-6 and returns it
    /// </summary>
    public int roll()
    {
      Random random = new Random();
      result = random.Next(1, 7); //Generates random int from 1-6
      Console.WriteLine($"Die Roll = {result}.");
      return result;
    }
  }


}
