using System;
using System.Collections.Generic;
using System.Linq;
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


        //Method
         
        public int rollDie()
        {
            //Note: Move this into its own method at some point
            int result = 0; 

            Random random = new Random();
            result = random.Next(1, 6); //Generates random int from 1-6
            Console.WriteLine($"Die Roll = {result}."); 
            return result;
        }
    }


}
