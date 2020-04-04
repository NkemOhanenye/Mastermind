/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/4/2020
 * Mastermind Game - Computer Class
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
    //This class is used to store the answer code for the game and check to see if the user has won or lost. This class will act as the “Mastermind” of the game 
    class Computer
    {
        private int hiddenCodeLength;
        private Color[] hiddenAnswer;  //each element is a color that makes up the answer code
        private Image[] marbles;  // each element is an image that makes up the answer code
        private ColorsClass colorObj;

        //Constructor initializes attributes
        public Computer(int codeLength)
        {
            hiddenCodeLength = codeLength;
            hiddenAnswer = new Color[hiddenCodeLength];
            marbles = new Image[hiddenCodeLength];
            colorObj = new ColorsClass();
        }

        //Calls the method from Colors class to generate random colors for the answer
        public void createAnswer(bool allowDuplicates)
        {
            colorObj.createRandomCode(hiddenAnswer, allowDuplicates);
        }

        // Calls the copyRandomCode method from Colors class to generate random marbles for the answer
        public Image[] copyAnswer(Image[] storedMarbles)
        {
            colorObj.copyRandomCode(marbles, storedMarbles);
            return marbles;
        }
        
        // returns the hiddenAnswer to be used to color the buttons
        public Color[] getAnswer
        {
            get
            {
                return hiddenAnswer;
            }
        }

        //Checks to see if the number of perfect colors (right color, right position) in the player's guess is equal to the amount of colors in the answer
        //If the numbers are equal, every color matches perfectly; will return true if every color and positions match or false otherwise
        public bool isMatch(Button[] currPlayerRow, Hints hintObj)
        {
            bool match = false;
            int numPerfectGuesses = hintObj.countGuesses(hiddenAnswer, currPlayerRow);
            hintObj.placeHints();
            if (numPerfectGuesses == hiddenAnswer.Length)
            {
                match = true;
            }
            return match;
        }
    }
}
