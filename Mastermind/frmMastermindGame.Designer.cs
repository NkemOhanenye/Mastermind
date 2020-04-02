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
            // check here
            this.btnRestart = new System.Windows.Forms.Button();
            this.cmboxAnswerList = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.transPnlCurrRow = new Mastermind.Components.TransparentPanel();
            this.pnlMainBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainBoard
            // 
            this.pnlMainBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainBoard.Controls.Add(this.transPnlCurrRow);
            this.pnlMainBoard.Location = new System.Drawing.Point(12, 73);
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
            this.pnlAnswerBoard.Location = new System.Drawing.Point(29, 9);
            this.pnlAnswerBoard.Name = "pnlAnswerBoard";
            this.pnlAnswerBoard.Size = new System.Drawing.Size(210, 58);
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
            this.pnlGivenColorsBoard.Location = new System.Drawing.Point(86, 614);
            this.pnlGivenColorsBoard.Name = "pnlGivenColorsBoard";
            this.pnlGivenColorsBoard.Size = new System.Drawing.Size(512, 162);
            this.pnlGivenColorsBoard.TabIndex = 3;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(327, 44);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(6);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(73, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(327, 13);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPickAColor
            // 
            this.lblPickAColor.AutoSize = true;
            this.lblPickAColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPickAColor.Location = new System.Drawing.Point(7, 589);
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
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(255, 44);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(66, 23);
            this.btnRestart.TabIndex = 10;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // cmboxAnswerList
            // 
            this.cmboxAnswerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxAnswerList.DropDownWidth = 110;
            this.cmboxAnswerList.FormattingEnabled = true;
            this.cmboxAnswerList.Items.AddRange(new object[] {
            "Pick an answer length",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmboxAnswerList.Location = new System.Drawing.Point(255, 14);
            this.cmboxAnswerList.Name = "cmboxAnswerList";
            this.cmboxAnswerList.Size = new System.Drawing.Size(29, 21);
            this.cmboxAnswerList.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 100;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Enter a row amount",
            "10",
            "11",
            "12"});
            this.comboBox1.Location = new System.Drawing.Point(292, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(29, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // transPnlCurrRow
            // 
            this.transPnlCurrRow.BackColor = System.Drawing.Color.Pink;
            this.transPnlCurrRow.CausesValidation = false;
            this.transPnlCurrRow.Location = new System.Drawing.Point(17, 3);
            this.transPnlCurrRow.Name = "transPnlCurrRow";
            this.transPnlCurrRow.Size = new System.Drawing.Size(210, 40);
            this.transPnlCurrRow.TabIndex = 0;
            // 
            // frmMastermindGame
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(412, 727);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmboxAnswerList);
            this.Controls.Add(this.btnRestart);
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
        private Components.TransparentPanel transPnlCurrRow;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.ComboBox cmboxAnswerList;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}