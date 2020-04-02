/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Created: 3/25/2020
 * Mastermind Game - How To Play Form
 * Last Modified: 3/27/2020
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
    public partial class frmHowToPlay : Form
    {
        public frmHowToPlay()
        {
            InitializeComponent();
        }

        // closes the form when the user is done reading the rules
        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
