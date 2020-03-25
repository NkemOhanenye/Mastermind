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

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            Form InstructionForm = new frmHowToPlay();
            InstructionForm.ShowDialog();
        }

        private void btnPlayMastermind_Click(object sender, EventArgs e)
        {
            Form PlayGame = new frmMastermindGame();
            PlayGame.ShowDialog();
        }
    }
}
