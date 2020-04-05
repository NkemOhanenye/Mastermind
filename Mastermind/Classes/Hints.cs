/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/5/2020
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
        private Dictionary<Color, int> countForAnswer = new Dictionary<Color, int>(); //gives each color in hiddenAnswer a count value (useful for when there's duplicate colors)
        private Dictionary<Color, int> countForCurrRow = new Dictionary<Color, int>();  //gives each color in currentPlayerRow a count value (aka how many times the player placed color)

        //Constructor 
        public Hints()
        {

        }

        //Sets currentCheckRow as the current row of the checkBoard where current hints are supposed to go
        public void setCheckRow(Button[] currHintRow)
        {
            currentCheckRow = currHintRow;
      
        }


        //Goes through currentPlayerRow and hiddenAnswer and places the colors in Dictionaries along with a count for each color
        //Increments numOKGuess for every color that is in currentPlayerRow and in hiddenAnswer
        //If a color in currentPlayerRow matches the position of the same color in hiddenAnswer, numPerfectGuess is incremented
        //Returns the count value for numPerfectGuess
        public int countGuesses(Color[] hiddenAnswer, Button[] currentPlayerRow)
        {
            if (countForAnswer.Count == 0)         //if the count of the colors in hidden answer is empty, populate it
            {
                populateCountForAnswer(hiddenAnswer);
            }
            populateCountForCurrRow(currentPlayerRow);

            Color first = currentPlayerRow[0].ForeColor;
            int count;
            countForCurrRow.TryGetValue(first, out count);

            //increments numPerfectGuess by 1 if all colors in currentPlayerRow are the same AND this color is in hiddenAnswer
            if (count == currentPlayerRow.Length && hiddenAnswer.Contains(first))
            {
                numPerfectGuess++;
            }
            else
            {
                //increment numOKGuess for every color that the player has that is in hiddenAnswer
                //ex: if player places exactly two blues and hiddenAnswer contains exactly two blues, numOKGuess increments by 2
                //ex: if player places exactly two blues but hiddenAnswer contains only one blue, numOKGuess increments by 1
                //incrementation based on the count value of the color from countForAnswer
                //if player's count for a color is less, numOKGuess would increment by the count value from countForCurrRow instead
                Dictionary<Color, int>.KeyCollection playerColors = countForCurrRow.Keys;
                foreach (Color currentColor in playerColors)
                { 
                    if (hiddenAnswer.Contains(currentColor) && countForAnswer.ContainsKey(currentColor))
                    {
                        if (countForCurrRow[currentColor] == countForAnswer[currentColor] 
                            || countForCurrRow[currentColor] > countForAnswer[currentColor])
                        {
                            numOKGuess += countForAnswer[currentColor];
                        } else if (countForCurrRow[currentColor] < countForAnswer[currentColor])
                        {
                            numOKGuess += countForCurrRow[currentColor];
                        }
                    }
                }

                //this changes an OKGuess to a PerfectGuess if the color from player's row is also in the correct position
                int i = 0;
                while (i < hiddenAnswer.Length)
                {
                    if (currentPlayerRow[i].ForeColor.Equals(hiddenAnswer[i]))
                    {
                        numPerfectGuess++;
                        numOKGuess--;
                    }
                    i++;
                }

            }

            countForCurrRow.Clear();  //clears all key, value pairs so it can be used for next row
            return numPerfectGuess;
        }

        //Puts the colors from hiddenAnswer into a Dictionary along with a count of how many times the color appears
        public void populateCountForAnswer(Color[] hiddenAnswer)
        {
            foreach(Color c in hiddenAnswer)
            {
                int count = 1;
                //if color is already in the Dictionary, increment and set its count
                if (countForAnswer.ContainsKey(c))
                {
                    int currentCount;
                    countForAnswer.TryGetValue(c, out currentCount);
                    countForAnswer[c] = currentCount + 1;
                }
                else
                {
                    countForAnswer.Add(c, count);
                }
            }
        }


        //Puts the colors from currentPlayerRow in a Dictionary along with a count of how many times that color was placed
        public void populateCountForCurrRow(Button[] currPlayerRow)
        {
            foreach (Button b in currPlayerRow)
            {
                Color c = b.ForeColor;
                int count = 1;
                if (!countForCurrRow.ContainsKey(c))
                {
                    countForCurrRow.Add(c, count);
                }
                else
                {
                    //if color is already in the Dictionary, increment and set its count
                    int currentCount;
                    countForCurrRow.TryGetValue(c, out currentCount);
                    countForCurrRow[c] = currentCount + 1;
                }
            }
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
