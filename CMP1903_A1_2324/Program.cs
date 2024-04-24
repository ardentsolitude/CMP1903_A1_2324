using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Note: This is the version for part 2 of the assignment



namespace CMP1903_A1_2324 {
    internal class Program {
        static void Main(string[] args) {

            
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            
            /*
            Console.WriteLine("Running Program...\n");
            Game game = new Game(); //Creates game object 
                                    //Placeholder variable needed because playGame returns the sum for the purpose of making testing work.
            int placeholder = game.playGame(); //Game runs without requiring user input
            Console.WriteLine("\nTesting Program...\n");
            Testing test = new Testing(); //Creates test object.
            */

            //Part II starts here

            Game game = new Game(); //Create game object
            game.gameStart(); //Go to start menu



        }



    }
}
