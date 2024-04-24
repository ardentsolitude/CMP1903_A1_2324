using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace CMP1903_A1_2324 {
    internal class SevensOut : Game {
        public SevensOut() {
            /*
            Sevens Out
            2 x dice
            Rules:
	        Roll the two dice, noting the total rolled each time.
	        If it is a 7 - stop.
	        If it is any other number - add it to your total.
		    If it is a double - add double the total to your score (3,3 would add 12 to your total)
            */




        }

        public override void playGame(int playerCount) {
            Die die1 = new Die();
            Die die2 = new Die();

            if (playerCount == 1) {
                sevensOnePlayer(die1, die2);
            }
            else if (playerCount == 2) {
                sevensTwoPlayer(die1, die2);
            }
        }

        public void sevensOnePlayer(Die die1, Die die2) {
            int playerTurn = 1;
            int p1Score = 0;
            int p2Score = 0;
            bool gameEnded = false;
            while (!gameEnded) {
                playerTurn++;
                playerTurn = playerTurn % 2;
                if (playerTurn == 0) {
                    takeTurn(die1, die2, false, playerTurn, p1Score);
                }
                else if (playerTurn == 1) {
                    takeTurn(die1, die2, true, playerTurn, p2Score); //Computer's turn (no player input required)
                }
            }

        }

        public void sevensTwoPlayer(Die die1, Die die2) {
            int playerTurn = 1;
            int p1Score = 0;
            int p2Score = 0;
            bool gameEnded = false;
            bool p1out = false;
            bool p2out = false;
            while (!gameEnded) {
                playerTurn++;
                playerTurn = playerTurn % 2;
                if (playerTurn == 0) {
                    takeTurn(die1, die2, false, playerTurn, p1Score);
                }
                else if (playerTurn == 1) {
                    takeTurn(die1, die2, false, playerTurn, p2Score);
                }
            }
        }

        public void takeTurn(Die die1, Die die2, bool autoTurn, int playerTurn, int playerScore) {
            int die1roll = die1.rollDie();
            Thread.Sleep(1);
            int die2roll = die2.rollDie();
            if (!autoTurn) { //Player controlled turn
                Console.WriteLine($"Player {playerTurn + 1}'s Turn!\nPress Enter To Begin.");
                Console.ReadLine();
                Console.WriteLine($"Player {playerTurn + 1} Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.");
            }
            else { //Computer controlled turn
                Console.WriteLine("Computer's Turn!");
                Console.WriteLine($"Computer Rolled {die1roll} and {die2roll}, giving a total of {die1roll + die2roll}.");
            }
            if (die1roll == die2roll) {
                Console.WriteLine("Rolled A Double! \nDouble Points!");
            }

            if (die1roll + die2roll == 7) {
                Console.WriteLine("You Got A 7! \nYou're Out!");
            }



        }
    }
}
