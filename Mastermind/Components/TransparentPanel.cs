/*
 * Nkem Ohanenye, Tracy Lan
 * CIS 3309 Section 001
 * Date: 4/1/2020
 * Mastermind Game - Transparent Current Row Color
 * 
 * Solution is from: Abdusalam Ben Haj
 * https://stackoverflow.com/questions/4463363/how-can-i-set-the-opacity-or-transparency-of-a-panel-in-winforms
 * Who in turn got it from: William Smash
 * http://williamsmash.com/posts/transparent-controls-in-winforms
 * Who in turn got it from: Tobias Hertkorn
 * http://www.fsmpi.uni-bayreuth.de/~dun3/archives/creating-a-transparent-panel-in-net/108.html
 * 
 * This is a new object for use in the Mastermind Form
 * A transparent panel
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind.Components
{
    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}
