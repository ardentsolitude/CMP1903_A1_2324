﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void makeDice()
        {
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
        }

        public void rollDice(Die die1, Die die2, Die die3)
        {
            int result1 = die1.rollDie();
            int result2 = die2.rollDie();
            int result3 = die3.rollDie();
        }
    }
}
