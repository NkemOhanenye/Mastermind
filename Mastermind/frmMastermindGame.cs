/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/4/2020
 * Mastermind Game - Main Form Class
 * 
 * Some of the code for dynamically creating the buttons is courtesy of Professor Frank Friedman
 * The code for changing the image of the cursor is from https://www.youtube.com/watch?v=fxjCB84sCxo
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

        Image[] marbles;  // reference variable of a Image array

        // a reference variable array of buttons that acts as the currently active row for the player
        private Button[] currPlayerRow;
        // a reference variable array of buttons that acts as the previously active row
        // used to set the previous row disabled
        private Button[] prevPlayerRow;
        private int currPlayerIndex = 0; // the index for what row the current player is at on the board
        // a reference variable array of buttons that acts as the currently active row for the computer
        private Button[] currCheckRow;
        
        // reference variables for the original size and loactions of the form, boards and panels
        // used for the reset button
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
            size = new Size(30, 30);
            loc.Y = padding/3;

            for (int col = 0; col < codeLength; col++)
            {
                answerBoard[col] = new Button();
                answerBoard[col].Location = new Point((padding + 5) + col * (size.Width + padding), loc.Y);
                answerBoard[col].Size = size;
                answerBoard[col].Enabled = true;
                answerBoard[col].Name = "btnAnswer" + col.ToString();
                // removes button border and style
                answerBoard[col].TabStop = false;
                answerBoard[col].FlatStyle = FlatStyle.Flat;
                answerBoard[col].FlatAppearance.BorderSize = 0;
                // makes the hover that appears when hovering over the button transparent
                answerBoard[col].FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                answerBoard[col].FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                pnlAnswerBoard.Controls.Add(answerBoard[col]);
            }
            // generates the hidden answer and gives the colors to the hidden answer buttons
            // changes the image of each button to a marble
            cpu.createAnswer(allowDuplicates);
            Image[] marbleAnswers = cpu.copyAnswer(marbles);
            for (int col = 0; col < cpu.getAnswer.Length; col++)
            {
                answerBoard[col].ForeColor = cpu.getAnswer[col];
                answerBoard[col].Image = marbleAnswers[col];
            }
            pnlAnswerBoard.Visible = false;
        }


        // Creates a 2d array of row x col buttons and displays these buttons on the main panel on the form;
        // Disables all of the buttons except the buttons in the first row (the first row buttons will be the 
        // initial currentPlayerRow)
        public void createMainBoard()
        {
            size = new Size(30, 30);
            for (int row = 0; row < numRows; row++)
            {
                loc.Y =  5 + row * (size.Height + 20);
                for (int col = 0; col < codeLength; col++)
                {
                    mainBoard[row, col] = new Button();
                    mainBoard[row, col].Location = new Point((padding + 5) + col * (size.Width + padding), loc.Y);
                    mainBoard[row, col].Size = size;
                    mainBoard[row, col].Enabled = false;
                    mainBoard[row, col].Name = "btnMain" + row.ToString() + col.ToString();
                    mainBoard[row, col].ForeColor = SystemColors.Control;
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
            size = new Size(30, 30);
            for (int row = 0; row < numRows; row++)
            {
                loc.Y = 5 + row * (size.Height + 20);
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
        // each button is given a marble as an image
        public void createColorsBoard()
        {
            int givenColorIndex = 0;
            size = new Size(30, 30);
            for (int row = 0; row < givenColorsBoard.GetUpperBound(0) + 1; row++)
            {
                loc.Y = row * (size.Height + padding);
                for (int col = 0; col < givenColorsBoard.GetUpperBound(givenColorsBoard.Rank-1) + 1; col++)
                {
                    givenColorsBoard[row, col] = new Button();
                    givenColorsBoard[row, col].Location = new Point(col * (size.Width + padding), loc.Y);
                    givenColorsBoard[row, col].Size = size;
                    givenColorsBoard[row, col].Name = "btnColor" + row.ToString() + col.ToString();
                    givenColorsBoard[row, col].ForeColor = color.getGivenColor(givenColorIndex);
                    // removes button border and style
                    givenColorsBoard[row, col].TabStop = false;
                    givenColorsBoard[row, col].FlatStyle = FlatStyle.Flat;
                    givenColorsBoard[row, col].FlatAppearance.BorderSize = 0;
                    // makes the hover that appears when hovering over the button transparent
                    givenColorsBoard[row, col].FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                    pnlGivenColorsBoard.Controls.Add(givenColorsBoard[row, col]);
                    givenColorIndex++;
                    givenColorsBoard[row, col].Click += new EventHandler(GivenButton_Click);
                    givenColorsBoard[row, col].MouseEnter += new EventHandler(GivenButton_Enter);
                    givenColorsBoard[row, col].MouseLeave += new EventHandler(GivenButton_Leave);
                }
            }
            givenColorIndex = 0;
            // changes the image of each button to a marble
            for (int row = 0; row < givenColorsBoard.GetUpperBound(0) + 1; row++)
            {
                for (int col = 0; col < givenColorsBoard.GetUpperBound(givenColorsBoard.Rank - 1) + 1; col++)
                {
                    givenColorsBoard[row, col].Image = marbles[givenColorIndex];
                    givenColorIndex++;
                }
            }
        }


        // Used to call a method to get the next row 
        // If the player index is equal to the number of rows on the player board, then the player loses; answer is revealed
        // Player can't go to the next row if they reached the max value of rows
        public void nextRow()
        {
            if (currPlayerIndex == numRows - 1)
            {
                // the player loses and all the button's events are removved
                // the answerBoard is shown to the user
                for (int col = 0; col < codeLength; col++)
                {
                    currPlayerRow[col].FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                    currPlayerRow[col].Click -= MainButton_Click;
                    currPlayerRow[col].MouseEnter -= MainButton_Enter;
                    currPlayerRow[col].MouseLeave -= MainButton_Leave;
                }
                // if the events are not fully removed
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < codeLength; col++)
                    {
                        mainBoard[row, col].Click -= MainButton_Click;
                        mainBoard[row, col].MouseEnter -= MainButton_Enter;
                        mainBoard[row, col].MouseLeave -= MainButton_Leave;
                    }
                }
                pnlAnswerBoard.Visible = true;
                transPnlCurrRow.Visible = false;
                pnlGivenColorsBoard.Enabled = false;
                btnCheck.Enabled = false;
                btnReset.Text = "Play Again?";
                MessageBox.Show("You Lost");
            }
            else
            {
                // disable the previously used player row
                prevPlayerRow = currPlayerRow;

                for (int col = 0; col < codeLength; col++)
                {
                    prevPlayerRow[col].FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                    prevPlayerRow[col].Click -= MainButton_Click;
                    prevPlayerRow[col].MouseEnter -= MainButton_Enter;
                    prevPlayerRow[col].MouseLeave -= MainButton_Leave;
                }
                // if the events are not fully removed
                for (int row = 0; row < numRows; row++)
                {
                    for (int col = 0; col < codeLength; col++)
                    {
                        mainBoard[row, col].MouseEnter -= MainButton_Enter;
                        mainBoard[row, col].MouseLeave -= MainButton_Leave;
                    }
                }

                // goes to the next player row and enables buttons
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
                loc.Y = currPlayerIndex * ((padding + 6)  + (padding / 2));
                transPnlCurrRow.Location = new Point(17, loc.Y);
            }
        }


        // Convert a character from the names of the buttons to it's int value
        int convertCharToInt(char c)
        {
            return ((int)(c) - (int)('0'));
        } // end convertCharToInt


        // Button click event for all buttons in the givenColorsBoard (to find which colored button is clicked)
        // cursor changes to marble as if the user is dragging the marble
        private void GivenButton_Click(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[8]);
            int colID = convertCharToInt(((Button)sender).Name[9]);
            color.setColorPicked(givenColorsBoard[rowID, colID].ForeColor);
            color.setMarblePicked(givenColorsBoard[rowID, colID].Image);
            changeCursor(givenColorsBoard[rowID, colID].Image);
        }

        // creates a new cursor from an image and size
        private Cursor createCursor(Bitmap bm, Size size)
        {
            bm = new Bitmap(bm, size);
            bm.MakeTransparent();
            return new Cursor(bm.GetHicon());
        }

        // a method to be used in GivenButton_Click that changes the cursor's image on button click
        private void changeCursor(Image marble)
        {
            this.Cursor = createCursor( (Bitmap) marble, new Size(25, 25));
        }

        // Clears the cursor back to the default one prepared by the system
        private Cursor clearCursor()
        {
            return this.Cursor = Cursors.Default;
        }

        // the button enter event for all buttons in the givenColorsBoard (creates a border to size 1 on hover)
        private void GivenButton_Enter(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[8]);
            int colID = convertCharToInt(((Button)sender).Name[9]);
            givenColorsBoard[rowID, colID].FlatAppearance.BorderSize = 1;
        }

        // the button leave event for all buttons in the givenColorsBoard (removes the border on leave)
        private void GivenButton_Leave(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[8]);
            int colID = convertCharToInt(((Button)sender).Name[9]);
            givenColorsBoard[rowID, colID].FlatAppearance.BorderSize = 0;
        }


        // Button click event for all of the buttons in mainBoard (to find which button on the game board that the player clicked)
        // Chars can only hold 1 place value so if the game has 11 or 12 rows, the rowID and colID values will change
        // depending on if the button's text contains isDisabled
        private void MainButton_Click(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[7]);
            int colID = convertCharToInt(((Button)sender).Name[8]);

            if (currPlayerIndex >= 10)
            {
                rowID = 10;
                colID = convertCharToInt(((Button)sender).Name[9]);
                if (currPlayerIndex == 11)
                {
                    rowID = 11;
                    mainBoard[rowID, colID].ForeColor = color.getColorPicked();
                    mainBoard[rowID, colID].Image = color.getMarblePicked();
                    // removes button border and style
                    mainBoard[rowID, colID].TabStop = false;
                    mainBoard[rowID, colID].FlatStyle = FlatStyle.Flat;
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
                    // makes the hover that appears when hovering over the button transparent
                    mainBoard[rowID, colID].FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                    mainBoard[rowID, colID].MouseEnter += new EventHandler(MainButton_Enter);
                    mainBoard[rowID, colID].MouseLeave += new EventHandler(MainButton_Leave);
                }
                else
                {
                    mainBoard[rowID, colID].ForeColor = color.getColorPicked();
                    mainBoard[rowID, colID].Image = color.getMarblePicked();
                    // removes button border and style
                    mainBoard[rowID, colID].TabStop = false;
                    mainBoard[rowID, colID].FlatStyle = FlatStyle.Flat;
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
                    // makes the hover that appears when hovering over the button transparent
                    mainBoard[rowID, colID].FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                    mainBoard[rowID, colID].MouseEnter += new EventHandler(MainButton_Enter);
                    mainBoard[rowID, colID].MouseLeave += new EventHandler(MainButton_Leave);
                }
            }
            else
            {
                mainBoard[rowID, colID].ForeColor = color.getColorPicked();
                mainBoard[rowID, colID].Image = color.getMarblePicked();
                // removes button border and style
                mainBoard[rowID, colID].TabStop = false;
                mainBoard[rowID, colID].FlatStyle = FlatStyle.Flat;
                mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
                // makes the hover that appears when hovering over the button transparent
                mainBoard[rowID, colID].FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                mainBoard[rowID, colID].MouseEnter += new EventHandler(MainButton_Enter);
                mainBoard[rowID, colID].MouseLeave += new EventHandler(MainButton_Leave);
            }
        }

        // the button enter event for the clicked buttons on the mainBoard (creates a border to size 1 on hover)
        private void MainButton_Enter(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[7]);
            int colID = convertCharToInt(((Button)sender).Name[8]);
            if (currPlayerIndex >= 10)
            {
                rowID = 10;
                colID = convertCharToInt(((Button)sender).Name[9]);
                if (currPlayerIndex == 11)
                {
                    rowID = 11;
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 1;
                }
                else
                {
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 1;
                }
            }
            else
            {
                mainBoard[rowID, colID].FlatAppearance.BorderSize = 1;
            }
        }

        // the button leave event for the clicked buttons on the mainBoard (removes the border on leave)
        private void MainButton_Leave(object sender, EventArgs e)
        {
            int rowID = convertCharToInt(((Button)sender).Name[7]);
            int colID = convertCharToInt(((Button)sender).Name[8]);
            if (currPlayerIndex >= 10)
            {
                rowID = 10;
                colID = convertCharToInt(((Button)sender).Name[9]);
                if (currPlayerIndex == 11)
                {
                    rowID = 11;
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
                }
                else
                {
                    mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
                }
            }
            else
            {
                mainBoard[rowID, colID].FlatAppearance.BorderSize = 0;
            }
        }


        // Calls on the isMatch method of the Computer Class to see if player's guess matches the hiddenAnswer
        // Displays the colored hints in the currentCheckRow if all of the board colors for currentPlayerRow have been set
        // If the row is not finished, player will be asked to finish the row
        public void btnCheck_Click(object sender, EventArgs e)
        {
            // resets the color in the reference variable
            color.setColorPicked(Color.Empty);

            // resets the cursor to default
            clearCursor();

            Boolean validCheck = true;

            for (int col = 0; col < codeLength; col++) {
                if (currPlayerRow[col].ForeColor == SystemColors.Control)
                {
                    MessageBox.Show("Your current row needs to have a marble selected for each button.");
                    validCheck = false;
                    break;
                }
            }
            if (validCheck == true)
            {
                bool match = cpu.isMatch(playerRow.getCurrentPlayerRow, hintObj);      //places hints on board; returns true if all colors match in the correct position and false otherwise
                if (match)
                {
                    // the player wins and all the button's events are removved
                    // the answerBoard is shown to the user
                    for (int col = 0; col < codeLength; col++)
                    {
                        currPlayerRow[col].FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                        currPlayerRow[col].Click -= MainButton_Click;
                        currPlayerRow[col].MouseEnter -= MainButton_Enter;
                        currPlayerRow[col].MouseLeave -= MainButton_Leave;
                    }
                    // if the events are not fully removed
                    for (int row = 0; row < numRows; row++)
                    {
                        for (int col = 0; col < codeLength; col++)
                        {
                            mainBoard[row, col].Click -= MainButton_Click;
                            mainBoard[row, col].MouseEnter -= MainButton_Enter;
                            mainBoard[row, col].MouseLeave -= MainButton_Leave;
                        }
                    }
                    pnlAnswerBoard.Visible = true;
                    transPnlCurrRow.Visible = false;
                    pnlGivenColorsBoard.Enabled = false;
                    btnCheck.Enabled = false;
                    btnReset.Text = "Play Again?";
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

                        // initializes the referance variable for the Image array  that holds all the images of marbles
                        marbles = new Image[] { collectionOfMarbles.Images[0],
                            collectionOfMarbles.Images[1], collectionOfMarbles.Images[2],
                            collectionOfMarbles.Images[3], collectionOfMarbles.Images[4],
                            collectionOfMarbles.Images[5], collectionOfMarbles.Images[6],
                            collectionOfMarbles.Images[7]};

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
            // sets the default size of the board at code length (4) and number of rows (10)
            // form
            this.Width = this.Width + 50;
            this.Height = this.Height + 10;
            // answer board
            pnlAnswerBoard.Width = pnlAnswerBoard.Width + padding;
            // game buttons
            pnlGameButtons.Location = new Point(pnlGameButtons.Location.X + 40,
                pnlGameButtons.Location.Y);
            // main board
            pnlMainBoard.Width = pnlMainBoard.Width + padding;
            pnlMainBoard.Height = pnlMainBoard.Height;
            // current row color
            transPnlCurrRow.Width = transPnlCurrRow.Width + 40;
            // check board
            pnlCheckBoard.Width = pnlCheckBoard.Width + 50;
            pnlCheckBoard.Height = pnlCheckBoard.Height;
            pnlCheckBoard.Location = new Point(pnlCheckBoard.Location.X + 20,
                pnlCheckBoard.Location.Y);
            //given color board
            lblPickAColor.Location = new Point(lblPickAColor.Location.X + 60,
                    lblPickAColor.Location.Y + 10);
            pnlGivenColorsBoard.Location = new Point(pnlGivenColorsBoard.Location.X + 60,
                    pnlGivenColorsBoard.Location.Y + 10);

            Boolean rowChanged = false;
            int height = (numRows * numRows) - ((numRows/2) * numRows);
            int width = codeLength * (codeLength * 4) - 20;

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
                transPnlCurrRow.Width = transPnlCurrRow.Width + width;
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
        // also the play again button
        private void btnReset_Click(object sender, EventArgs e)
        {
            // sets the Cursor back to default
            clearCursor();

            // sets the current player index back to 0
            currPlayerIndex = 0;

            // the text on the button is put back to normal
            btnReset.Text = "Reset";

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
            pnlAnswerBoard.Visible = true;
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
