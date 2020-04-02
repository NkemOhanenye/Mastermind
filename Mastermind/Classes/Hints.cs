/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/2/2020
 * Mastermind Game - Hints Generator Class
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind.Classes
{
    //This class keeps track of the number of colors in the currentPlayerRow that are correct color in the correct position
    //and the number of colors that are correct but in the wrong position;
    //sets/displays the colors in currentCheckRow (red if right color & right place, white if right color & wrong place, default black if wrong color) 
    //to give player hints as to whether his/her color guesses are correct and in the right position
    class Hints
    {
        private Button[] currentCheckRow;
        private int numPerfectGuess = 0;       //counts number of colors that are correct and in correct position
        private int numOKGuess = 0;          //counts number of colors tht are correct but in the wrong position
        private Color[] colorsSeen;        //keeps track of colors that have been seen before in currentPlayerRow

        //Constructor 
        public Hints()
        {

        }

        //Sets currentCheckRow as the current row of the checkBoard where current hints are supposed to go
        public void setCheckRow(Button[] currHintRow)
        {
            currentCheckRow = currHintRow;
            colorsSeen = new Color[currentCheckRow.Length];
        }


        //Loops through the colors in currentPlayerRow and increases either numPerfectGuess or numOKGuess
        //If a color appears in colorsSeen, neither of the counts are incremented as this color is a duplicate
        //Returns a count of the number of perfect guesses
        public int countGuesses(Color[] hiddenAnswer, Button[] currentPlayerRow)
        {
            int i = 0;
            int sameColorCount = 1;
            Color first = currentPlayerRow[0].BackColor;

            for (int j = 1; j < currentPlayerRow.Length; j++)
            {
                if (first.Equals(currentPlayerRow[j].BackColor))
                {
                    sameColorCount++;
                }
            }

            //if all the colors in the player's guess are the same and this color is in the answer,
            //increment numPerfectGuess by one since one of those positions is correct
            if (sameColorCount == currentPlayerRow.Length)
            {
                if (hiddenAnswer.Contains(first))
                {
                    numPerfectGuess++;
                }
            }
            else
            {
                while (i < hiddenAnswer.Length)
                {
              
                    if (currentPlayerRow[i].BackColor.Equals(hiddenAnswer[i]))
                    {
                        //if the color in the player's guess has not been seen before, place it in the isSeen array
                        if (!colorsSeen.Contains(currentPlayerRow[i].BackColor))
                        {
                            colorsSeen[i] = currentPlayerRow[i].BackColor;
                        }
                        //if the color has been seen elsewhere in the player's guess and numOKGuess was incremented for it, 
                        //decrement it bc the color is not an OkGuess; it is a PerfectGuess
                        else if (colorsSeen.Contains(currentPlayerRow[i].BackColor))
                        {
                            numOKGuess--;
                        }
                        numPerfectGuess++;
                    }
                    //if the color is in the answer and also is not seen anywhere else in the player's guess, increment okGuess
                    else if (hiddenAnswer.Contains(currentPlayerRow[i].BackColor)
                             && !colorsSeen.Contains(currentPlayerRow[i].BackColor))      //if hiddenAnswer contains the color but not necessarily at the right position
                    {
                        colorsSeen[i] = currentPlayerRow[i].BackColor;
                        numOKGuess++;
                    }
                    i++;
                }

            }
            return numPerfectGuess;
        }


        //Using the counters, changes the colors of the buttons in currentCheckRow and displays them as hints for the user
        public void placeHints()
        {
            int index = 0;
            while (numPerfectGuess > 0)
            {
                currentCheckRow[index].BackColor = Color.Red;
                numPerfectGuess--;
                index++;
            }

            while (numOKGuess > 0)
            {
                currentCheckRow[index].BackColor = Color.White;
                numOKGuess--;
                index++;
            }
        }

    }
}
