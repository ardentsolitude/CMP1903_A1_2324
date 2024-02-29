﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */
        public Testing()
        {
            Game gameTesting = new Game();
            Die dieTesting = new Die();
        }

        public void testFunctions(Game gameTesting, Die dieTesting)
        {
            int testResult = gameTesting.rollDice(dieTesting);
            Debug.Assert(testResult < 7, "Test Number is Greater Than 6.");
            Debug.Assert(testResult > 0, "Test Number is Less Than 1.");
        }



        //Method
    }
}
