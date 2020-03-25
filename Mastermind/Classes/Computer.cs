/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 3/24/2020
 * Mastermind Game - Colors Class
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
    //This class is used to store the answer code for the game and check to see if the user has won or lost. This class will act as the “Mastermind” of the game 
    class Computer
    {
        private int hiddenCodeLength;
        private Color[] hiddenAnswer;  //each element is a color that makes up the answer code
        private ColorsClass colorObj;

        //Constructor initializes attributes
        public Computer(int codeLength)
        {
            hiddenCodeLength = codeLength;
            hiddenAnswer = new Color[hiddenCodeLength];
            colorObj = new ColorsClass();
        }

        //Calls the method from Colors class to generate random colors for the answer
        private void createAnswer()
        {
            colorObj.createRandomCode(hiddenAnswer);
        }

        //Checks to see if the background colors of each button in currentPlayerRow matches
        //the colors in hiddenAnswer in the correct positions; will return true if every color and positions match or false otherwise
        private bool isMatch(Button[] currPlayerRow)
        {
            bool match = false;
            for(int i = 0; i < hiddenCodeLength; i++)
            {
                if(currPlayerRow[i].BackColor.Equals(hiddenAnswer[i]))
                {
                    match = true;
                }
                else
                {
                    match = false;
                }
            }
            return match;
        }
        
    }
}
