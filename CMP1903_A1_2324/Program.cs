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

            //A Note From Me: This Is Unfathomable Horrible To Read And Code, But IT WORKS. I Don't Know How Or Why, But It Works

            Game game = new Game(); //Create game object
            //Stats stats = new Stats();

			//For stats. Horribly clunky, I hate it.
			//But can't really change it at this point
			//I have commited a sin against Anders Hejlsberg
            //I really wish global variables existed in c#
            //It would mean I don't have to do this

            //Update: I changed how stats work, but I'm leaving these comments in because they are a testament to my own stupidity

            game.gameStart(); //Go to start menu.
                                                                                    //Not part of the constructor for game
                                                                                    //because it breaks the testing class when it is, due to recursion.
                                                                                    //I know that this entire program is one giant recursion
                                                                                    //Issue waiting to happen, but it somehow works
                                                                                    //I don't think I should program in c# anymore 



        }



    }
}
