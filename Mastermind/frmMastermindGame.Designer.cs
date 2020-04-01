namespace Mastermind
{
    partial class frmMastermindGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMainBoard = new System.Windows.Forms.Panel();
            this.pnlAnswerBoard = new System.Windows.Forms.Panel();
            this.pnlCheckBoard = new System.Windows.Forms.Panel();
            this.pnlGivenColorsBoard = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPickAColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlMainBoard
            // 
            this.pnlMainBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainBoard.Location = new System.Drawing.Point(12, 73);
            this.pnlMainBoard.Name = "pnlMainBoard";
            this.pnlMainBoard.Size = new System.Drawing.Size(252, 512);
            this.pnlMainBoard.TabIndex = 0;
            // 
            // pnlAnswerBoard
            // 
            this.pnlAnswerBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnswerBoard.Location = new System.Drawing.Point(11, 9);
            this.pnlAnswerBoard.Name = "pnlAnswerBoard";
            this.pnlAnswerBoard.Size = new System.Drawing.Size(253, 58);
            this.pnlAnswerBoard.TabIndex = 1;
            // 
            // pnlCheckBoard
            // 
            this.pnlCheckBoard.Location = new System.Drawing.Point(270, 73);
            this.pnlCheckBoard.Name = "pnlCheckBoard";
            this.pnlCheckBoard.Size = new System.Drawing.Size(129, 512);
            this.pnlCheckBoard.TabIndex = 2;
            // 
            // pnlGivenColorsBoard
            // 
            this.pnlGivenColorsBoard.Location = new System.Drawing.Point(86, 613);
            this.pnlGivenColorsBoard.Name = "pnlGivenColorsBoard";
            this.pnlGivenColorsBoard.Size = new System.Drawing.Size(256, 84);
            this.pnlGivenColorsBoard.TabIndex = 3;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(298, 41);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(298, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPickAColor
            // 
            this.lblPickAColor.AutoSize = true;
            this.lblPickAColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPickAColor.Location = new System.Drawing.Point(7, 588);
            this.lblPickAColor.Name = "lblPickAColor";
            this.lblPickAColor.Size = new System.Drawing.Size(166, 22);
            this.lblPickAColor.TabIndex = 6;
            this.lblPickAColor.Text = "Please pick a color:";
            // 
            // frmMastermindGame
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(412, 703);
            this.Controls.Add(this.pnlCheckBoard);
            this.Controls.Add(this.lblPickAColor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.pnlGivenColorsBoard);
            this.Controls.Add(this.pnlAnswerBoard);
            this.Controls.Add(this.pnlMainBoard);
            this.Name = "frmMastermindGame";
            this.Text = "Mastermind Game";
            this.Load += new System.EventHandler(this.frmMastermindGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainBoard;
        private System.Windows.Forms.Panel pnlAnswerBoard;
        private System.Windows.Forms.Panel pnlCheckBoard;
        private System.Windows.Forms.Panel pnlGivenColorsBoard;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblPickAColor;
    }
}