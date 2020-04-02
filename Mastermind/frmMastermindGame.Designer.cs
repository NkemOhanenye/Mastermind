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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblAllowDuplicates = new System.Windows.Forms.Label();
            this.pnlAnswerBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainBoard
            // 
            this.pnlMainBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainBoard.Location = new System.Drawing.Point(24, 140);
            this.pnlMainBoard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMainBoard.Name = "pnlMainBoard";
            this.pnlMainBoard.Size = new System.Drawing.Size(504, 985);
            this.pnlMainBoard.TabIndex = 0;
            // 
            // pnlAnswerBoard
            // 
            this.pnlAnswerBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnswerBoard.Controls.Add(this.btnYes);
            this.pnlAnswerBoard.Controls.Add(this.btnNo);
            this.pnlAnswerBoard.Controls.Add(this.lblAllowDuplicates);
            this.pnlAnswerBoard.Location = new System.Drawing.Point(22, 17);
            this.pnlAnswerBoard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlAnswerBoard.Name = "pnlAnswerBoard";
            this.pnlAnswerBoard.Size = new System.Drawing.Size(504, 110);
            this.pnlAnswerBoard.TabIndex = 1;
            // 
            // pnlCheckBoard
            // 
            this.pnlCheckBoard.Location = new System.Drawing.Point(540, 140);
            this.pnlCheckBoard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlCheckBoard.Name = "pnlCheckBoard";
            this.pnlCheckBoard.Size = new System.Drawing.Size(258, 985);
            this.pnlCheckBoard.TabIndex = 2;
            // 
            // pnlGivenColorsBoard
            // 
            this.pnlGivenColorsBoard.Location = new System.Drawing.Point(172, 1179);
            this.pnlGivenColorsBoard.Margin = new System.Windows.Forms.Padding(6);
            this.pnlGivenColorsBoard.Name = "pnlGivenColorsBoard";
            this.pnlGivenColorsBoard.Size = new System.Drawing.Size(512, 162);
            this.pnlGivenColorsBoard.TabIndex = 3;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(596, 79);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(6);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(150, 44);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(596, 23);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 44);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPickAColor
            // 
            this.lblPickAColor.AutoSize = true;
            this.lblPickAColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPickAColor.Location = new System.Drawing.Point(14, 1131);
            this.lblPickAColor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPickAColor.Name = "lblPickAColor";
            this.lblPickAColor.Size = new System.Drawing.Size(318, 39);
            this.lblPickAColor.TabIndex = 6;
            this.lblPickAColor.Text = "Please pick a color:";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.LightGreen;
            this.btnYes.Location = new System.Drawing.Point(66, 48);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(123, 50);
            this.btnYes.TabIndex = 7;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.IndianRed;
            this.btnNo.Location = new System.Drawing.Point(278, 48);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(117, 50);
            this.btnNo.TabIndex = 8;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblAllowDuplicates
            // 
            this.lblAllowDuplicates.AutoSize = true;
            this.lblAllowDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowDuplicates.Location = new System.Drawing.Point(3, 16);
            this.lblAllowDuplicates.Name = "lblAllowDuplicates";
            this.lblAllowDuplicates.Size = new System.Drawing.Size(488, 29);
            this.lblAllowDuplicates.TabIndex = 9;
            this.lblAllowDuplicates.Text = "Allow duplicate colors in the hidden answer?";
            // 
            // frmMastermindGame
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(824, 1352);
            this.Controls.Add(this.pnlCheckBoard);
            this.Controls.Add(this.lblPickAColor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.pnlGivenColorsBoard);
            this.Controls.Add(this.pnlAnswerBoard);
            this.Controls.Add(this.pnlMainBoard);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMastermindGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mastermind Game";
            this.Load += new System.EventHandler(this.frmMastermindGame_Load);
            this.pnlAnswerBoard.ResumeLayout(false);
            this.pnlAnswerBoard.PerformLayout();
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
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblAllowDuplicates;
    }
}