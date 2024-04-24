using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324 {
    internal class ThreeOrMore : Game{
        public ThreeOrMore() {
            /*
            Three or More
            5 x dice
            Rules:
	        Roll all 5 dice hoping for a 3-of-a-kind or better.
	        If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	        3-of-a-kind: 3 points
	        4-of-a-kind: 6 points
	        5-of-a-kind: 12 points
	        First to a total of 20.
            */


        }

        public override void playGame(int playerCount) {
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            Die die4 = new Die();
            Die die5 = new Die();

            List<Die> dieList = new List<Die>();
            dieList.Add(die1);
            dieList.Add(die2);
            dieList.Add(die3);
            dieList.Add(die4);
            dieList.Add(die5);

        }
    }
}
