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
            this.transPnlCurrRow = new Mastermind.Components.TransparentPanel();
            this.pnlAnswerBoard = new System.Windows.Forms.Panel();
            this.lblChooseLengths = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmboxRowList = new System.Windows.Forms.ComboBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.cmboxAnswerList = new System.Windows.Forms.ComboBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblAllowDuplicates = new System.Windows.Forms.Label();
            this.pnlCheckBoard = new System.Windows.Forms.Panel();
            this.pnlGivenColorsBoard = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblPickAColor = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlGameButtons = new System.Windows.Forms.Panel();
            this.pnlMainBoard.SuspendLayout();
            this.pnlAnswerBoard.SuspendLayout();
            this.pnlGameButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainBoard
            // 
            this.pnlMainBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainBoard.Controls.Add(this.transPnlCurrRow);
            this.pnlMainBoard.Location = new System.Drawing.Point(29, 74);
            this.pnlMainBoard.Name = "pnlMainBoard";
            this.pnlMainBoard.Size = new System.Drawing.Size(253, 519);
            this.pnlMainBoard.TabIndex = 0;
            // 
            // transPnlCurrRow
            // 
            this.transPnlCurrRow.BackColor = System.Drawing.Color.Pink;
            this.transPnlCurrRow.CausesValidation = false;
            this.transPnlCurrRow.Location = new System.Drawing.Point(19, 2);
            this.transPnlCurrRow.Margin = new System.Windows.Forms.Padding(2);
            this.transPnlCurrRow.Name = "transPnlCurrRow";
            this.transPnlCurrRow.Size = new System.Drawing.Size(208, 35);
            this.transPnlCurrRow.TabIndex = 0;
            this.transPnlCurrRow.Visible = false;
            // 
            // pnlAnswerBoard
            // 
            this.pnlAnswerBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnswerBoard.Controls.Add(this.lblChooseLengths);
            this.pnlAnswerBoard.Controls.Add(this.btnStart);
            this.pnlAnswerBoard.Controls.Add(this.cmboxRowList);
            this.pnlAnswerBoard.Controls.Add(this.btnYes);
            this.pnlAnswerBoard.Controls.Add(this.cmboxAnswerList);
            this.pnlAnswerBoard.Controls.Add(this.btnNo);
            this.pnlAnswerBoard.Controls.Add(this.lblAllowDuplicates);
            this.pnlAnswerBoard.Location = new System.Drawing.Point(29, 9);
            this.pnlAnswerBoard.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAnswerBoard.Name = "pnlAnswerBoard";
            this.pnlAnswerBoard.Size = new System.Drawing.Size(253, 58);
            this.pnlAnswerBoard.TabIndex = 1;
            // 
            // lblChooseLengths
            // 
            this.lblChooseLengths.AutoSize = true;
            this.lblChooseLengths.Location = new System.Drawing.Point(13, 9);
            this.lblChooseLengths.Name = "lblChooseLengths";
            this.lblChooseLengths.Size = new System.Drawing.Size(233, 13);
            this.lblChooseLengths.TabIndex = 14;
            this.lblChooseLengths.Text = "Choose a length from the boxes and hit START.";
            this.lblChooseLengths.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Location = new System.Drawing.Point(159, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 26);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmboxRowList
            // 
            this.cmboxRowList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxRowList.DropDownWidth = 100;
            this.cmboxRowList.FormattingEnabled = true;
            this.cmboxRowList.Items.AddRange(new object[] {
            "Enter a row amount",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmboxRowList.Location = new System.Drawing.Point(99, 28);
            this.cmboxRowList.Margin = new System.Windows.Forms.Padding(2);
            this.cmboxRowList.Name = "cmboxRowList";
            this.cmboxRowList.Size = new System.Drawing.Size(44, 21);
            this.cmboxRowList.TabIndex = 9;
            this.cmboxRowList.Visible = false;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.LightGreen;
            this.btnYes.Location = new System.Drawing.Point(33, 25);
            this.btnYes.Margin = new System.Windows.Forms.Padding(2);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(62, 26);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // cmboxAnswerList
            // 
            this.cmboxAnswerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxAnswerList.DropDownWidth = 110;
            this.cmboxAnswerList.FormattingEnabled = true;
            this.cmboxAnswerList.Items.AddRange(new object[] {
            "Pick a code length",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmboxAnswerList.Location = new System.Drawing.Point(24, 28);
            this.cmboxAnswerList.Name = "cmboxAnswerList";
            this.cmboxAnswerList.Size = new System.Drawing.Size(44, 21);
            this.cmboxAnswerList.TabIndex = 8;
            this.cmboxAnswerList.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.IndianRed;
            this.btnNo.Location = new System.Drawing.Point(139, 25);
            this.btnNo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(58, 26);
            this.btnNo.TabIndex = 11;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblAllowDuplicates
            // 
            this.lblAllowDuplicates.AutoSize = true;
            this.lblAllowDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowDuplicates.Location = new System.Drawing.Point(2, 8);
            this.lblAllowDuplicates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAllowDuplicates.Name = "lblAllowDuplicates";
            this.lblAllowDuplicates.Size = new System.Drawing.Size(249, 15);
            this.lblAllowDuplicates.TabIndex = 12;
            this.lblAllowDuplicates.Text = "Allow duplicate colors in the hidden answer?";
            // 
            // pnlCheckBoard
            // 
            this.pnlCheckBoard.Location = new System.Drawing.Point(298, 74);
            this.pnlCheckBoard.Name = "pnlCheckBoard";
            this.pnlCheckBoard.Size = new System.Drawing.Size(129, 519);
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
            this.btnCheck.Location = new System.Drawing.Point(3, 16);
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
            this.btnExit.Location = new System.Drawing.Point(79, 3);
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(79, 29);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlGameButtons
            // 
            this.pnlGameButtons.Controls.Add(this.btnExit);
            this.pnlGameButtons.Controls.Add(this.btnCheck);
            this.pnlGameButtons.Controls.Add(this.btnReset);
            this.pnlGameButtons.Location = new System.Drawing.Point(286, 9);
            this.pnlGameButtons.Name = "pnlGameButtons";
            this.pnlGameButtons.Size = new System.Drawing.Size(159, 59);
            this.pnlGameButtons.TabIndex = 8;
            // 
            // frmMastermindGame
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(452, 708);
            this.Controls.Add(this.pnlGameButtons);
            this.Controls.Add(this.pnlCheckBoard);
            this.Controls.Add(this.lblPickAColor);
            this.Controls.Add(this.pnlGivenColorsBoard);
            this.Controls.Add(this.pnlAnswerBoard);
            this.Controls.Add(this.pnlMainBoard);
            this.Name = "frmMastermindGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mastermind Game";
            this.Load += new System.EventHandler(this.frmMastermindGame_Load);
            this.pnlMainBoard.ResumeLayout(false);
            this.pnlAnswerBoard.ResumeLayout(false);
            this.pnlAnswerBoard.PerformLayout();
            this.pnlGameButtons.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblAllowDuplicates;
        private Components.TransparentPanel transPnlCurrRow;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cmboxAnswerList;
        private System.Windows.Forms.ComboBox cmboxRowList;
        private System.Windows.Forms.Label lblChooseLengths;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Panel pnlGameButtons;
    }
}