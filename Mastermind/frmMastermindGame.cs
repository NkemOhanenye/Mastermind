/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/2/2020
 * Mastermind Game - Main Form Class
 * 
 * Some of the code for dynamically creating the buttons is courtesy of Professor Frank Friedman
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
// red always goes before white regardless of position of colors in the player's row; this prevents 
// the game from being too easy as it does not give away the real position of the color in the answer
namespace Mastermind
{
    public partial class frmMastermindGame : Form
    {
        private int codeLength;  // the size of the answer (number of colored marbles, or colored buttons in our case, in the answer)
        private int numRows;    // number of rows for the main board and check board

        private Button[] answerBoard;  // a reference variable of a Button array
        private Button[,] mainBoard;  // 2d reference variable array of buttons representing the board where the player will place his/her guesses
        private Button[,] checkBoard;  // 2d reference variable array of buttons representing the board which will give hints to indicate whether the player’s guessed colors are correct and in the right position
        private Button[,] givenColorsBoard = new Button[2, 4];   // 2d reference variable array of buttons with two rows of 4 to represent the given colors the player can choose from

        // a reference variable array of buttons that acts as the currently active row for the player
        private Button[] currPlayerRow;
        // a reference variable array of buttons that acts as the previously active row
        // used to set the previous row disabled
        private Button[] prevPlayerRow;
        private int currPlayerIndex = 0; // the index for what row the current player is at on the board
        // a reference variable array of buttons that acts as the currently active row for the computer
        private Button[] currCheckRow;
        
        // reference variables for the original size and loactions of the form, boards and panels
        private int originalFormWidth;
        private int originalFormHeight;
        private Size originalAnswerBoardSize;
        private Size originalMainBoardSize;
        private Size originalCurrRowColorSize;
        private Size originalCheckBoardSize;
        private Point originalGameButtonsLocation;
        private Point originalCurrRowColorLocation;
        private Point originalCheckBoardLocation;
        private Point originalPickAColorLocation;
        private Point originalGivenColorBoardLocation;

        private Size size; // sets the size for the buttons 
        private int padding = 30; // sets the padding around the buttons
        private Point loc = new Point(0, 15); // sets the x,y coordinates for the buttons on the panels

        // boolean to mark whether duplicates in the answer are allowed
        private bool allowDuplicates;

        // creates reference variables of objects of the ColorsClass, the Computer class, the PlayerBoard class and Hints class
        private ColorsClass color = new ColorsClass();
        private Computer cpu;
        private PlayerBoard playerRow = new PlayerBoard();
        private Hints hintObj = new Hints();


        // Constructor that creates a new game form
        public frmMastermindGame()
        {
            InitializeComponent();
        }

        // Upon loading the form, the player will have to choose to allow duplicates
        // instantiates the reference variables of the original size and location of the forms, 
        // boards and panels
        // The check button and the boards are not created until the player chooses YES or NO
        // and then chooses a code length and row length
        // Label, Check and Reset button hidden
        public void frmMastermindGame_Load(object sender, EventArgs e)
        {
            originalFormWidth = this.Width;
            originalFormHeight = this.Height;
            originalAnswerBoardSize = pnlAnswerBoard.Size;
            originalMainBoardSize = pnlMainBoard.Size;
            originalCurrRowColorSize = transPnlCurrRow.Size;
            originalCheckBoardSize = pnlCheckBoard.Size;
            originalGameButtonsLocation = pnlGameButtons.Location;
            originalCurrRowColorLocation = transPnlCurrRow.Location;
            originalCheckBoardLocation = pnlCheckBoard.Location;
            originalPickAColorLocation = lblPickAColor.Location;
            originalGivenColorBoardLocation = pnlGivenColorsBoard.Location;

            btnCheck.Visible = false;
            btnReset.Visible = false;
            lblPickAColor.Visible = false;
        }


        // Creates the array of buttons of length codeLength; sets the background color of each button to be 
        // the colors from hiddenAnswer of the Computer class
        // Initializes the panel to be visible = false until the player either wins or uses up all of his guesses
        public void createAnswerBoard()
        {
            size = new Size(23, 23);
            loc.Y = padding/2;
            for (int col = 0; col < codeLength; col++)
            {
                answerBoard[col] = new Button();
                answerBoard[col].Location = new Point((padding + 5) + col * (size.Width + padding), loc.Y);
                answerBoard[col].Size = size;
                answerBoard[col].Enabled = false;
                answerBoard[col].Name = "btnAnswer" + col.ToString();
                pnlAnswerBoard.Controls.Add(answerBoard[col]);
            }
            // generates the hidden answer and gives the colors to the hidden answer buttons
            cpu.createAnswer(allowDuplicates);
            for (int col = 0; col < cpu.getAnswer.Length; col++)
            {
                answerBoard[col].BackColor = cpu.getAnswer[col];
            }
           // pnlAnswerBoard.Visible = false;
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
                    mainBoard[row, col].Location = new Point((padding + 5) + col * (size.Width + padding), loc.Y);
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
                currPlayerRow[col] = mainBoard[currPlayerIndex, col];
                currPlayerRow[col].Enabled = true;
                currPlayerRow[col].BringToFront();
            }
            // stores current row in a PlayerBoard object (to be accessed and used for the hints)
            playerRow.setPlayerRow(currPlayerRow);
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
            for (int col = 0; col < codeLength; col++)
            {
                currCheckRow[col] = checkBoard[currPlayerIndex, col];
            }

            //stores current hint row in a Hints object to be used later for placing hints
            hintObj.setCheckRow(currCheckRow);
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
                    givenColorsBoard[row, col].BackColor = color.getGivenColor(givenColorIndex);
                    pnlGivenColorsBoard.Controls.Add(givenColorsBoard[row, col]);
                    givenColorIndex++;
                    givenColorsBoard[row, col].Click += new EventHandler(GivenButton_Click);
                }
            }
        }


        // Used to call a method to get the next row 
        // If the player index is equal to the number of rows on the player board, then the player loses; answer is revealed
        // Player can't go to the 11th row if there are only 10 rows
        public void nextRow()
        {
            if (currPlayerIndex == numRows - 1)
            {
                // the player loses and all the buttons are disabled
                // the answerBoard is shown to the user
                for (int col = 0; col < codeLength; col++)
                {
                    currPlayerRow[col].Enabled = false;
                }
                pnlAnswerBoard.Visible = true;
                pnlGivenColorsBoard.Enabled = false;
                btnCheck.Enabled = false;
                MessageBox.Show("You Lost");
            }
            else
            {
                // disable the previously used player row
                prevPlayerRow = currPlayerRow;

                for (int col = 0; col < codeLength; col++)
                {

                    prevPlayerRow[col].Enabled = false;
                }

                // goes to the next player row an enables buttons
                currPlayerIndex++;
                for (int col = 0; col < codeLength; col++)
                {
                    currPlayerRow[col] = mainBoard[currPlayerIndex, col];
                    currPlayerRow[col].Enabled = true;
                    currPlayerRow[col].BringToFront();
                    currCheckRow[col] = checkBoard[currPlayerIndex, col];
                }
                playerRow.setPlayerRow(currPlayerRow);
                hintObj.setCheckRow(currCheckRow);

                // traverses the current row color to the next active row
                loc.Y = currPlayerIndex * (size.Height + padding);
                transPnlCurrRow.Location = new Point(17, loc.Y);
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

        
        // Button click event for all of the buttons in mainBoard (to find which button on the game board that the player clicked)
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
            // resets the color in the reference variable
            color.setColorPicked(Color.Empty);

            Boolean validCheck = true;

            for (int col = 0; col < codeLength; col++) {
                if (currPlayerRow[col].BackColor == null || 
                    currPlayerRow[col].BackColor == Color.Empty ||
                    currPlayerRow[col].BackColor == SystemColors.Control)
                {
                    MessageBox.Show("Your current row needs to have a color selected for each button.");
                    validCheck = false;
                    break;
                }
            }
            if (validCheck == true)
            {
                bool match = cpu.isMatch(playerRow.getCurrentPlayerRow, hintObj);      //places hints on board; returns true if all colors match in the correct position and false otherwise
                if (match)
                {
                    // Player wins
                    for (int col = 0; col < codeLength; col++)
                    {
                        currPlayerRow[col].Enabled = false;
                    }
                    pnlAnswerBoard.Visible = true;
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

        //Button click event for allowing duplicates in the answer
        private void btnYes_Click(object sender, EventArgs e)
        {
            lblAllowDuplicates.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
            allowDuplicates = true;

            lblChooseLengths.Visible = true;
            cmboxAnswerList.Visible = true;
            cmboxRowList.Visible = true;
            btnStart.Visible = true;
        }


        //Button click event for not allowing duplicates in the answer
        private void btnNo_Click(object sender, EventArgs e)
        {
            lblAllowDuplicates.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
            allowDuplicates = false;

            lblChooseLengths.Visible = true;
            cmboxAnswerList.Visible = true;
            cmboxRowList.Visible = true;
            btnStart.Visible = true;
        }

        // Button click event for initializing the code length and number of rows by user input
        // initializes all the boards and creates them
        private void btnStart_Click(object sender, EventArgs e)
        {
            // the user needs to choose a value 
            if (cmboxAnswerList.Text == "" || cmboxRowList.Text == "")
            {
                MessageBox.Show("You need to pick a value in each box");
            }
            else
            {
                // verifies if the value chosen is a number
                try
                {
                    codeLength = Convert.ToInt32(cmboxAnswerList.Text);
                    numRows = Convert.ToInt32(cmboxRowList.Text);

                    // clears the code length is the user didnt want duplicates but the 
                    // code length was larger than the given colors amount
                    if (allowDuplicates == false && codeLength > 8)
                    {
                        MessageBox.Show("You cant have a code length over 8 if you don't want duplicates");
                        cmboxAnswerList.Text = null;
                    }
                    else
                    {
                        // the user inputted code length and number of rows are passed to the boards
                        // and Computer Class
                        answerBoard = new Button[codeLength];
                        mainBoard = new Button[numRows, codeLength];
                        checkBoard = new Button[numRows, codeLength];
                        currPlayerRow = new Button[codeLength];
                        prevPlayerRow = new Button[codeLength];
                        currCheckRow = new Button[codeLength];
                        cpu = new Computer(codeLength);

                        lblChooseLengths.Visible = false;
                        cmboxAnswerList.Visible = false;
                        cmboxRowList.Visible = false;
                        btnStart.Visible = false;

                        btnCheck.Visible = true;
                        btnReset.Visible = true;
                        lblPickAColor.Visible = true;
                        transPnlCurrRow.Visible = true;

                        // changes the size of the boards based on the code length and number of rows
                        changeSizeOfBoards();

                        createAnswerBoard();
                        createMainBoard();
                        createCheckBoard();
                        createColorsBoard();
                    }
                }
                catch
                {
                    MessageBox.Show("You need to choose a valid number in each box");
                }
            }
        }

        // changes the size of the boards and panels based on the amount of rows and columns
        private void changeSizeOfBoards()
        {
            Boolean rowChanged = false;
            int height = ((numRows * numRows) - padding) - ((numRows/5)*(numRows/4));
            int width = codeLength * (codeLength * 3);
            // changes the width and location X
            if (codeLength > 4)
            {
                // form
                this.Width = this.Width + width;
                // answer board
                pnlAnswerBoard.Width = pnlAnswerBoard.Width + width;
                // game buttons
                pnlGameButtons.Location = new Point(pnlGameButtons.Location.X + width, 
                    pnlGameButtons.Location.Y);
                // main board
                pnlMainBoard.Width = pnlMainBoard.Width + width;
                // current row color
                transPnlCurrRow.Width = transPnlCurrRow.Width + (width + 15);
                // check board
                pnlCheckBoard.Location = new Point(pnlCheckBoard.Location.X + width,
                    pnlCheckBoard.Location.Y);
                pnlCheckBoard.Width = pnlCheckBoard.Width + (width - (codeLength * codeLength));
                // given color board
                lblPickAColor.Location = new Point(lblPickAColor.Location.X + width,
                    lblPickAColor.Location.Y);
                pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X + width,
                    pnlGivenColorsBoard.Location.Y);
                if (numRows > 10 && allowDuplicates == true)  // changes the height and location Y
                {
                    // form
                    this.Height = this.Height + height;
                    // main board
                    pnlMainBoard.Height = pnlMainBoard.Height + height;
                    // check board
                    pnlCheckBoard.Height = pnlCheckBoard.Height + height;
                    // given color board
                    lblPickAColor.Location = new Point(lblPickAColor.Location.X,
                        lblPickAColor.Location.Y + height);
                    pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X,
                        pnlGivenColorsBoard.Location.Y + height);
                    rowChanged = true;
                }
                else if (numRows < 10 && allowDuplicates == true)  // changes the height and location Y
                {
                    height = ((numRows / numRows) + padding) + ((numRows / 3) * (numRows / 2));
                    // form
                    this.Height = this.Height - height;
                    // main board
                    pnlMainBoard.Height = pnlMainBoard.Height - height;
                    // check board
                    pnlCheckBoard.Height = pnlCheckBoard.Height - height;
                    // given color board
                    lblPickAColor.Location = new Point(lblPickAColor.Location.X,
                        lblPickAColor.Location.Y - height);
                    pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X,
                        pnlGivenColorsBoard.Location.Y - height);
                    rowChanged = true;
                }
            }
            // changes the height and location Y only if the code length wasnt changed
            if (numRows > 10 && rowChanged == false)
            {
                // form
                this.Height = this.Height + height;
                // main board
                pnlMainBoard.Height = pnlMainBoard.Height + height;
                // check board
                pnlCheckBoard.Height = pnlCheckBoard.Height + height;
                // given color board
                lblPickAColor.Location = new Point(lblPickAColor.Location.X,
                    lblPickAColor.Location.Y + height);
                pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X,
                    pnlGivenColorsBoard.Location.Y + height);
            }
            // changes the height and location Y only if the code length wasnt changed
            if (numRows < 10 && rowChanged == false)
            {
                height = ((numRows / numRows) + padding) + ((numRows / 3) * (numRows / 2));
                // form
                this.Height = this.Height - height;
                // main board
                pnlMainBoard.Height = pnlMainBoard.Height - height;
                // check board
                pnlCheckBoard.Height = pnlCheckBoard.Height - height;
                // given color board
                lblPickAColor.Location = new Point(lblPickAColor.Location.X,
                    lblPickAColor.Location.Y - height);
                pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X,
                    pnlGivenColorsBoard.Location.Y - height);
            }
        }

        // resets the board if the player wants to start over
        private void btnReset_Click(object sender, EventArgs e)
        {
            // sets the current player index back to 0
            currPlayerIndex = 0;

            // resets the comboboxes to null
            cmboxAnswerList.Text = null;
            cmboxRowList.Text = null;

            // resizes the form, board and panels back to their original size
            // relocates all the boards and panels back to their original position
            pnlAnswerBoard.Size = originalAnswerBoardSize;
            pnlGameButtons.Location = originalGameButtonsLocation;
            pnlMainBoard.Size = originalMainBoardSize;
            transPnlCurrRow.Size = originalCurrRowColorSize;
            transPnlCurrRow.Location = originalCurrRowColorLocation;
            pnlCheckBoard.Size = originalCheckBoardSize;
            pnlCheckBoard.Location = originalCheckBoardLocation;
            lblPickAColor.Location = originalPickAColorLocation;
            pnlGivenColorsBoard.Location = originalGivenColorBoardLocation;
            this.Width = originalFormWidth;
            this.Height = originalFormHeight;

            // resets the answerBoard and currPlayerRow
            for (int col = 0; col < codeLength; col++)
            {
                pnlAnswerBoard.Controls.Remove(answerBoard[col]);
                answerBoard[col].Dispose();
                currPlayerRow[col].Dispose();
            }
            // resets the mainBoard
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < codeLength; col++)
                {
                    this.mainBoard[row, col].Click -= new System.EventHandler(this.
                        MainButton_Click);
                    pnlMainBoard.Controls.Remove(mainBoard[row, col]);
                    mainBoard[row, col].Dispose();
                }
            }
            // resets the givenColorsBoard
            for (int row = 0; row < givenColorsBoard.GetUpperBound(0) + 1; row++)
            {
                for (int col = 0; col < givenColorsBoard.GetUpperBound(givenColorsBoard.Rank - 1) + 1; col++)
                {
                    this.givenColorsBoard[row, col].Click -= new System.EventHandler(this.
                        GivenButton_Click);
                    pnlGivenColorsBoard.Controls.Remove(givenColorsBoard[row, col]);
                    givenColorsBoard[row, col].Dispose();
                }
            }

            // clears all controls in the panels
            pnlCheckBoard.Controls.Clear();
            pnlGivenColorsBoard.Controls.Clear();

            // reloads the form load
            frmMastermindGame_Load(sender, e);

            // resets the state of the board to when the board is first opened
            transPnlCurrRow.Visible = false;
            lblAllowDuplicates.Visible = true;
            btnYes.Visible = true;
            btnNo.Visible = true;
            allowDuplicates = false;
            btnCheck.Visible = false;
            lblPickAColor.Visible = false;

            // in case the user wins/loses the game the enabled values are reset
            btnCheck.Enabled = true;
            pnlGivenColorsBoard.Enabled = true;
        }

        //Closes the form when user clicks Exit button
        public void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
