/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Created: 3/24/2020
 * Mastermind Game - Main Form Class
 * Last Modified: 4/1/2020
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
using Mastermind.Classes;


// Notes: for the hints, red means the color is a correct color and in correct position, 
// white means the color is correct but in the wrong position, black if wrong
namespace Mastermind
{
    public partial class frmMastermindGame : Form
    {
        private int codeLength = 4;  // the size of the answer (number of colored marbles, or colored buttons in our case, in the answer); default is 4
        private int numRows = 10;    // number of rows for the main board and check board; default is 10

        private Button[] answerBoard; // an array of buttons of size codeLength
        private Button[,] mainBoard; // 2d array of buttons representing the board where the player will place his/her guesses
        private Button[,] checkBoard; // 2d array of buttons representing the board which will give hints to indicate whether the player’s guessed colors are correct and in the right position
        private Button[,] givenColorsBoard = new Button[2, 4];   // 2d array of buttons with two rows of 4 to represent the given colors the player can choose from

        // an array of buttons that acts as the currently active row for the player
        private Button[] currPlayerRow;
        // an array of buttons that acts as the previously active row
        // used to set the previous row disabled
        private Button[] prevPlayerRow;
        private int colIndex = 0; // gets the index to the current index the currPlayerRow is pointing to
        private int currPlayerIndex = 0; // the index for what row the current player is at on the board
        // an array of buttons that acts as the currently active row for the computer
        private Button[] currCheckRow;

        private Size size; // sets the size for the buttons 
        private int padding = 30; // sets the padding around the buttons
        private Point loc = new Point(0, 15); // sets the x,y coordinates for the buttons on the panels

        // creates referance variables of objects of the ColorsClass and the Computer class
        private ColorsClass color = new ColorsClass();
        private Computer cpu;


        // Constructor that creates a new game form
        public frmMastermindGame()
        {
            InitializeComponent();
        }


        // Upon loading the form, the buttons in each "board" (answerBoard, mainBoard, checkBoard, and givenColorsBoard)
        // Are created and displayed in their respective panels
        // instantiates the reference variables of the Buttons 
        // instiates the cpu reference variable of the Computer Class
        public void frmMastermindGame_Load(object sender, EventArgs e)
        {
            answerBoard = new Button[codeLength];
            mainBoard = new Button[numRows, codeLength];
            checkBoard = new Button[numRows, codeLength];
            currPlayerRow = new Button[codeLength];
            prevPlayerRow = new Button[codeLength];
            currCheckRow = new Button[codeLength];
            cpu = new Computer(codeLength);

            createAnswerBoard();
            createMainBoard();
            createCheckBoard();
            createColorsBoard();
        }

        // Creates the array of buttons of length codeLength; sets the background color of each button to be 
        // the colors from hiddenAnswer of the Computer class
        // Initializes them to be visible = false until the player either wins or uses up all of his guesses
        public void createAnswerBoard()
        {
            size = new Size(23, 23);
            loc.Y = padding/2;
            for (int col = 0; col < codeLength; col++)
            {
                answerBoard[col] = new Button();
                answerBoard[col].Location = new Point((padding / 2 - 3) + col * (size.Width + padding), loc.Y);
                answerBoard[col].Size = size;
                answerBoard[col].Enabled = false;
                //answerBoard[col].Visible = false;
                answerBoard[col].Name = "btnAnswer" + col.ToString();
                pnlAnswerBoard.Controls.Add(answerBoard[col]);
            }
            // generates the hidden answer
            cpu.createAnswer();
            for (int col = 0; col < cpu.getAnswer().Length; col++)
                answerBoard[col].BackColor = cpu.getAnswer()[col];
        }

        // Creates a 2d array of row x col buttons and displays these buttons on the main panel on the form;
        // Disables all of the buttons except the buttons in the first row (the first row buttons will be the 
        // initial currentPlayerRow)
        public void createMainBoard()
        {
            size = new Size(23, 23);
            for (int row = 0; row < numRows; row++)
            {
                loc.Y =  10 + row * (size.Height + padding);
                for (int col = 0; col < codeLength; col++)
                {
                    mainBoard[row, col] = new Button();
                    mainBoard[row, col].Location = new Point(padding + col * (size.Width + padding), loc.Y);
                    mainBoard[row, col].Size = size;
                    mainBoard[row, col].Enabled = false;
                    mainBoard[row, col].Name = "btnMain" + row.ToString() + col.ToString();
                    pnlMainBoard.Controls.Add(mainBoard[row, col]);
                    mainBoard[row, col].Click += new EventHandler(MainButton_Click);
                }
            }
            // assigns the first row in the 2D array to be the current row
            for (int col = 0; col < codeLength; col++)
            {
                currPlayerRow[colIndex] = mainBoard[currPlayerIndex, col];
                currPlayerRow[colIndex].Enabled = true;
                currPlayerRow[colIndex].BringToFront();
                colIndex++;
            }
        }

        // Creates a 2d array of row x col buttons and displays these buttons in the panel to the right of the main board
        // All buttons are disabled and the background colors of all of them are initialized 
        // to be black (the first row buttons will be the initial currentCheckRow)
        public void createCheckBoard()
        {
            size = new Size(17, 23);
            for (int row = 0; row < numRows; row++)
            {
                loc.Y = 10 + row * (size.Height + padding);
                for (int col = 0; col < codeLength; col++)
                {
                    checkBoard[row, col] = new Button();
                    checkBoard[row, col].Location = new Point(col * (size.Width + 15), loc.Y);
                    checkBoard[row, col].Size = size;
                    checkBoard[row, col].Enabled = false;
                    checkBoard[row, col].Name = "btnCheck" + row.ToString() + col.ToString();
                    checkBoard[row, col].BackColor = Color.Black;
                    pnlCheckBoard.Controls.Add(checkBoard[row, col]);
                }
            }
            // assigns the first row in the 2D array to be the current row
            colIndex = 0;
            for (int col = 0; col < codeLength; col++)
            {
                currCheckRow[colIndex] = checkBoard[currPlayerIndex, col];
                colIndex++;
            }
        }

        // used to call a method to get the next row, 
        // if the index has the same value of rows, then the player loses, 
        // you cant go to the 11th row if there are only 10 
        public void nextRow()
        {
            if (currPlayerIndex == numRows - 1)
            {
                // the player loses and all the buttons are disabled
                // the answerBoard is shown to the user
                colIndex = 0;
                for (int col = 0; col < codeLength; col++)
                {
                    currPlayerRow[colIndex].Enabled = false;
                    answerBoard[colIndex].Visible = true;
                    colIndex++;
                }
                pnlGivenColorsBoard.Enabled = false;
                btnCheck.Enabled = false;
                MessageBox.Show("You Lost");
            }
            else
            {
                // disable the previously used player row
                colIndex = 0;
                prevPlayerRow = currPlayerRow;
                for (int col = 0; col < codeLength; col++)
                    prevPlayerRow[colIndex++].Enabled = false;

                // goes to the next row
                colIndex = 0;
                currPlayerIndex++;
                for (int col = 0; col < codeLength; col++)
                {
                    currPlayerRow[colIndex] = mainBoard[currPlayerIndex, col];
                    currPlayerRow[colIndex].Enabled = true;
                    currPlayerRow[colIndex].BringToFront();
                    currCheckRow[colIndex] = checkBoard[currPlayerIndex, col];
                    colIndex++;
                }
                // traverses the current row color to the next active row
                loc.Y = currPlayerIndex * (size.Height + padding);
                transPnlCurrRow.Location = new Point(17, loc.Y);
            }
        }

        // Creates the 2d array of 2 rows of 4 buttons and initializes each of the button 
        // colors to be a color from givenColors in the Colors class
        public void createColorsBoard()
        {
            int givenColorIndex = 0;
            size = new Size(40, 23);
            for (int row = 0; row < givenColorsBoard.GetUpperBound(0) + 1; row++)
            {
                loc.Y = row * (size.Height + padding);
                for (int col = 0; col < givenColorsBoard.GetUpperBound(givenColorsBoard.Rank-1) + 1; col++)
                {
                    givenColorsBoard[row, col] = new Button();
                    givenColorsBoard[row, col].Location = new Point(col * (size.Width + padding), loc.Y);
                    givenColorsBoard[row, col].Size = size;
                    givenColorsBoard[row, col].Name = "btnColor" + row.ToString() + col.ToString();
                    givenColorsBoard[row, col].BackColor = color.givenColors[givenColorIndex];
                    pnlGivenColorsBoard.Controls.Add(givenColorsBoard[row, col]);
                    givenColorIndex++;
                    givenColorsBoard[row, col].Click += new EventHandler(GivenButton_Click);
                }
            }
        }

        // Convert a charcter to its equivalent integer
        int convertCharToInt(char c)
        {
            return ((int)(c) - (int)('0'));
        } // end convertCharToInt

        // Button click event for all buttons in the givenColorsBoard (to find which colored button is clicked)
        private void GivenButton_Click(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[8]);
            int colID = convertCharToInt(((Button)sender).Name[9]);
            color.setColorPicked(givenColorsBoard[rowID, colID].BackColor);
        }
        
        // Button click event for all of the buttons in mainBoard (to find which button on the board that the player clicked)
        private void MainButton_Click(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[7]);
            int colID = convertCharToInt(((Button)sender).Name[8]);
            mainBoard[rowID, colID].BackColor = color.getColorPicked();
        }

        // Calls on the isMatch method of the Computer Class to see if player's guess matches the hiddenAnswer
        // Displays the colored hints in the currentCheckRow if all of the board colors for currentPlayerRow have been set
        // If the row is not finished, player will be asked to finish the row
        public void btnCheck_Click(object sender, EventArgs e)
        {
            Boolean validCheck = true;
            colIndex = 0;
            for (int col = 0; col < codeLength; col++) {
                if (currPlayerRow[colIndex].BackColor == null || 
                    currPlayerRow[colIndex].BackColor == Color.Empty ||
                    currPlayerRow[colIndex].BackColor == SystemColors.Control)
                {
                    MessageBox.Show("Your current row needs to have a color selected for each button.");
                    validCheck = false;
                    break;
                }
                colIndex++;
            }
            if (validCheck == true)
            {
                if (cpu.isMatch(currPlayerRow))
                {
                    colIndex = 0;
                    for (int col = 0; col < codeLength; col++)
                    {
                        currPlayerRow[colIndex].Enabled = false;
                        answerBoard[colIndex].Visible = true;
                        colIndex++;
                    }
                    pnlGivenColorsBoard.Enabled = false;
                    btnCheck.Enabled = false;
                    MessageBox.Show("Congratulations, You Won!");
                }
                else
                {
                    nextRow();
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            codeLength = 5;
            //numRows = 11;
            colIndex = 0;
            currPlayerIndex = 0;

            pnlAnswerBoard.Controls.Clear();
            pnlMainBoard.Controls.Clear();
            //transPnlCurrRow.Controls.Clear();
            pnlCheckBoard.Controls.Clear();
            pnlGivenColorsBoard.Controls.Clear();

            frmMastermindGame_Load(sender, e);
        }

        //Closes the form when user clicks Exit button
        public void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
