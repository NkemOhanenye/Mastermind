/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/1/2020
 * Mastermind Game - Game Start Form
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

namespace Mastermind
{
    public partial class frmGameStart : Form
    {
        public frmGameStart()
        {
            InitializeComponent();
        }

        // Displays the how to play the game Mastermind
        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            this.Visible = false; // hides this form when the form is opened
            Form InstructionForm = new frmHowToPlay();
            InstructionForm.ShowDialog();
            this.Visible = true; // view is returned when the form is closed
        }

        // Displays the Mastermind Classic game
        private void btnPlayMastermind_Click(object sender, EventArgs e)
        {
            this.Visible = false; // hides this form when the user wants to play the game 
            Form playGame = new frmMastermindGame();
            playGame.ShowDialog();
            this.Close();
        }
    }
}
