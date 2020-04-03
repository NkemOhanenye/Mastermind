namespace Mastermind
{
    partial class frmGameStart
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
            this.lblWelcomeToMastermind = new System.Windows.Forms.Label();
            this.btnPlayMastermind = new System.Windows.Forms.Button();
            this.btnHowToPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcomeToMastermind
            // 
            this.lblWelcomeToMastermind.AutoSize = true;
            this.lblWelcomeToMastermind.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWelcomeToMastermind.Location = new System.Drawing.Point(24, 68);
            this.lblWelcomeToMastermind.Name = "lblWelcomeToMastermind";
            this.lblWelcomeToMastermind.Size = new System.Drawing.Size(560, 39);
            this.lblWelcomeToMastermind.TabIndex = 0;
            this.lblWelcomeToMastermind.Text = "Welcome to The Mastermind Game!";
            // 
            // btnPlayMastermind
            // 
            this.btnPlayMastermind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPlayMastermind.Location = new System.Drawing.Point(209, 258);
            this.btnPlayMastermind.Name = "btnPlayMastermind";
            this.btnPlayMastermind.Size = new System.Drawing.Size(190, 37);
            this.btnPlayMastermind.TabIndex = 1;
            this.btnPlayMastermind.Text = "Play Mastermind";
            this.btnPlayMastermind.UseVisualStyleBackColor = true;
            this.btnPlayMastermind.Click += new System.EventHandler(this.btnPlayMastermind_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHowToPlay.Location = new System.Drawing.Point(209, 164);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(190, 37);
            this.btnHowToPlay.TabIndex = 3;
            this.btnHowToPlay.Text = "How To Play";
            this.btnHowToPlay.UseVisualStyleBackColor = true;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // frmGameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 389);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnPlayMastermind);
            this.Controls.Add(this.lblWelcomeToMastermind);
            this.Name = "frmGameStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Mastermind";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeToMastermind;
        private System.Windows.Forms.Button btnPlayMastermind;
        private System.Windows.Forms.Button btnHowToPlay;
    }
}

