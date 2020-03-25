/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 3/25/2020
 * Mastermind Game - Hints Generator Class
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
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

        //Constructor initializes currentCheckRow as the current row of the checkBoard where current hints are suppsoed to go
        public Hints(Button[] currHintRow)
        {
            currentCheckRow = currHintRow;
            colorsSeen = new Color[currentCheckRow.Length];
        }

        //Loops through the colors in currentPlayerRow and increases either numPerfectGuess or numOKGuess
        //If a color appears in colorsSeen, neither of the counts are incremented as this color is a duplicate
        public void countGuesses(Color[] hiddenAnswer, Button[] currentPlayerRow)
        {
            int i = 0;
            while(i < hiddenAnswer.Length && !isSeen(currentPlayerRow[i].BackColor))     //while i is less than the length of the answer AND the color of the button at i has not been seen before
            {
                if (currentPlayerRow[i].BackColor.Equals(hiddenAnswer[i]))
                {
                    numPerfectGuess++;
                }
                else if (hiddenAnswer.Contains(currentPlayerRow[i].BackColor))       //if hiddenAnswer contains the color but not necessarily at the right position
                {
                    numOKGuess++;
                }
                i++;
            }
                
        }

        //Goes through colorsSeen to see if a color from currentPlayerRow has appeared before
        //Returns true if the color is in colorsSeen; returns false if otherwise but also adds the new color to colorsSeen
        public bool isSeen(Color playersGuess)
        {
            for (int i = 0; i < colorsSeen.Length; i++)
            {
                if (playersGuess.Equals(colorsSeen[i]))
                {
                    return true;
                }
                else
                {
                    colorsSeen[i] = playersGuess;     //if color is not seen in colorsSeen, place it there once and then break to prevent putting the color multiple times
                    break;
                }
            }
            return false;
        }

        //Using the counters, changes the colors of the buttons in currentCheckRow and displays them as hints for the user
        public void placeHints()
        {
            int index = 0;
            while(numPerfectGuess > 0)
            {
                currentCheckRow[index].BackColor = Color.Red;
                numPerfectGuess--;
                index++;
            }

            while(numOKGuess > 0)
            {
                currentCheckRow[index].BackColor = Color.White;
                numOKGuess--;
                index++;
            }
        }

    }
}
