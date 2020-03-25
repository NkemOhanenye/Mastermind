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

namespace Mastermind
{
    //Contains attributes and methods pertaining to the colors
    //Stores all of the given colors in the game 
    //Generates and keeps track of the random colors chosen for the answer code
    class ColorsClass
    {
        private Color[] givenColors;     //holds the 8 given colors the player can choose from
        private bool[] chosenAnswerColors;   //used to keep track of which colors have been chosen in the random color generation process
        private Color colorPicker;        //holds the value of the chosen color that the user picks

        //Constructor initializes color attributes
        public ColorsClass()
        {
            givenColors = new Color[8] {Color.Red, Color.Blue, Color.Yellow, Color.Lime, Color.White, Color.Black, Color.SaddleBrown, Color.DarkOrange};
            chosenAnswerColors = new bool[givenColors.Length];
        }

        //Generates the random 4 colors for the hiddenAnswer
        private void createRandomCode(Color[] hiddenAnswer)
        {
            Random rand = new Random();
            int i = 0;

            while(i < hiddenAnswer.Length)
            {
                int index = rand.Next(givenColors.Length);
                if(checkForDuplicates(index) == false)
                {
                    hiddenAnswer[i] = givenColors[index];    //retrieves the random color at randomly generated index value and gives color to hiddenAnswer
                    i++;                    //only increments if a non-duplicate color is chose; if the color is a duplicate, random will go again
                }
            }    
        }

        //Looks through chosenAnswerColors array to see if the given index (representing a color at that index in givenColors) has been generated before
        //Returns the value at that index (true or false)
        private bool checkForDuplicates(int index)
        {
            if(chosenAnswerColors[index] == true)
            {
                return true;
            }
            else
            {
                chosenAnswerColors[index] = true;      //if color has not been picked before, return false but also mark it as true since it has just now been picked
                return false;
            }
        }

        //Returns the saved Color that is referenced by colorPicker
        //Aids in setting the color of the button that the player clicked on the main board to the saved color returned by this method (colorPicker)
        private Color setColorPicked()
        {
            return colorPicker;
        }

        //Gets the color of the button that the player chose from the given colors and assigns the reference to the color to colorPicker
        private void getColorPicked(Color userPickedColor)
        {
            colorPicker = userPickedColor;
        }
    }
}
