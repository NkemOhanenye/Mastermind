/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 3/24/2020
 * Mastermind Game - Player Board Class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    //This class keeps track of the colors that the user places in the current guessing row
    class PlayerBoard
    {
        private Button[] currentPlayerRow;

        //Constructor takes in the row the player places his/her guesses in and sets it as the currentPlayerRow 
        public PlayerBoard()
        {
            
        }

        //Takes in the row the player places his/her guesses in and sets it as the currentPlayerRow
        public void setPlayerRow (Button[] currGuessRow)
        {
            currentPlayerRow = currGuessRow;
        }

        //Returns currentPlayerRow
        public Button[] getCurrentPlayerRow
        {
            get
            {
                return currentPlayerRow;
            }


        }
    }
}
