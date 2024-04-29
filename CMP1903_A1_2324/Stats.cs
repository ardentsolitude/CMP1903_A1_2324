using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
	static internal class Stats {
		static private int p1wins = 0;//How many times player 1 has won games
		static private int p2wins = 0;//How many times player 2 has won games
		static private int threeGames = 0;//How many games of three or more have been played
		static private int sevenGames = 0;//How many games of sevens out have been played
		static private int sevenHighScore = 0;//Highest score achieved in sevens out
		//Note: There's no high score for three or more because
		//the highest possible score achievable is 30
		//(18 points + 5-of-a-kind (12 points)),
		//so I didn't think it was worth tracking

		static public void displayStats() { //Output stats for player
			Console.WriteLine($"You Have Played {sevenGames} Game(s) of Sevens Out And {threeGames} Game(s) Of Three Or More. \nPlayer 1 Has Won {p1wins} Time(s) And Player 2 Has Won {p2wins} Time(s). \nThe Highest Score Achieved In Sevens Out Is {sevenHighScore} Points.");
		}
		
		static public void updateStats(int score, string gameType, int winner) {
			//Updates stats after each game.
			//This is unfathomably scuffed
			//This is the reason for all the passing of variables across basically every function
			//This is responsible for so many headaches

			//Update: I changed how stats work so it's a lot better, but I'm leaving these comments as a testament to my own stupidity
			//Because my idiocy deserves to be documented

			if (gameType == "Sevens") {
				sevenGames++;
				if (score > sevenHighScore) {
					sevenHighScore = score;
				}
			}
			else if (gameType == "Threes") {
				threeGames++;
			}

			if (winner == 1) {
				p1wins++;
			}
			else if (winner == 2) {
				p2wins++;
			}

			//returnToMenu(p1wins, p2wins, sevenGames, threeGames, sevenHighScore); //Return back to main menu
		}
		
	}







}
