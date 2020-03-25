/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date:
 * Mastermind Game - Main Form Class
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Notes: for the hints, red means the color is a correct color and in correct position, white means the color is correct but in the wrong position, black if wrong
namespace Mastermind
{
    public partial class frmMastermindGame : Form
    {
        private const int CODELENGTH = 4;  //the size of the answer (number of colored marbles, or colored buttons in our case, in the answer); An option we would like to incorporate: player chooses the codeLength.
        private const int NUMROWS = 10;    //number of rows for the main board and check board; default is 10

        private Button[] answerBoard = new Button[CODELENGTH]; //an array of buttons of size codeLength
        private Button[,] mainBoard = new Button[NUMROWS, CODELENGTH];  //2d array of buttons representing the board where the player will place his/her guesses
        private Button[,] checkBoard = new Button[NUMROWS, CODELENGTH]; //2d array of buttons representing the board which will give hints to indicate whether the player’s guessed colors are correct and in the right position
        private Button[,] givenColorsBoard = new Button[2, 4];   //2d array of buttons with two rows of 4 to represent the given colors the player can choose from


        //Constructor that creates a new game form
        public frmMastermindGame()
        {
            InitializeComponent();
        }


        //Upon loading the form, the buttons in each "board" (answerBoard, mainBoard, checkBoard, and givenColorsBoard)
        //Are created and displayed in their respective panels
        private void frmMastermindGame_Load(object sender, EventArgs e)
        {
            createAnswerBoard();
            createMainBoard();
            createCheckBoard();
            createColorsBoard();
        }

        //Creates the array of buttons of length codeLength; sets the background color of each button to be the colors from hiddenAnswer of the Computer class
        //Initializes them to be visible = false until the player either wins or uses up all of his guesses
        private void createAnswerBoard()
        {

        }

        //Creates a 2d array of row x col buttons and displays these buttons on the main panel on the form;
        //Disables all of the buttons except the buttons in the first row (the first row buttons will be the initial currentPlayerRow)
        private void createMainBoard()
        {

        }

        //Creates a 2d array of row x col buttons and displays these buttons in the panel to the right of the main board
        //All buttons are disabled and the background colors of all of them are initialized to be black (the first row buttons will be the initial currentCheckRow)
        private void createCheckBoard()
        {

        }

        //Creates the 2d array of 2 rows of 4 buttons and initializes each of the button colors to be a color from givenColors in the Colors class
        private void createColorsBoard()
        {

        }

        //Calls on the isMatch method of the Computer Class to see if player's guess matches the hiddenAnswer
        //Displays the colored hints in the currentCheckRow if all of the board colors for currentPlayerRow have been set
        //If the row is not finished, player will be asked to finish the row
        private void btnCheck_Click(object sender, EventArgs e)
        {

        }


        //Button click event for all buttons in the givenColorsBoard (to find which colored button is clicked)
        
        //Button click event for all of the buttons in mainBoard (to find which button on the board that the player clicked)



        //Closes the form when user clicks Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
