using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */
            Console.WriteLine("Testing Program...");
            Testing test = new Testing(); //Creates test object.

            Console.WriteLine("Running Program...");
            Game game = new Game(); //Creates game object 
            //Game runs without requiring user input


            //game.playGame();
        }
    }
}
