namespace Mastermind
{
    partial class frmHowToPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHowToPlay));
            this.lblDirection1 = new System.Windows.Forms.Label();
            this.lblDirections = new System.Windows.Forms.Label();
            this.lblDirection2 = new System.Windows.Forms.Label();
            this.lblDirection3 = new System.Windows.Forms.Label();
            this.picboxExplanation = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxExplanation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDirection1
            // 
            this.lblDirection1.AutoSize = true;
            this.lblDirection1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDirection1.Location = new System.Drawing.Point(136, 12);
            this.lblDirection1.Name = "lblDirection1";
            this.lblDirection1.Size = new System.Drawing.Size(427, 88);
            this.lblDirection1.TabIndex = 0;
            this.lblDirection1.Text = "The goal of the game is to guess the code the \r\nmastermind of the game has set. W" +
    "ithin the set of \r\nrows given, you will have to guess the mastermind\'s \r\ncode of" +
    " marbles.";
            this.lblDirection1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.lblDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDirections.Location = new System.Drawing.Point(12, 140);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(95, 22);
            this.lblDirections.TabIndex = 1;
            this.lblDirections.Text = "Directions:";
            // 
            // lblDirection2
            // 
            this.lblDirection2.AutoSize = true;
            this.lblDirection2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDirection2.Location = new System.Drawing.Point(122, 100);
            this.lblDirection2.Name = "lblDirection2";
            this.lblDirection2.Size = new System.Drawing.Size(473, 110);
            this.lblDirection2.TabIndex = 2;
            this.lblDirection2.Text = resources.GetString("lblDirection2.Text");
            this.lblDirection2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDirection3
            // 
            this.lblDirection3.AutoSize = true;
            this.lblDirection3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDirection3.Location = new System.Drawing.Point(122, 210);
            this.lblDirection3.Name = "lblDirection3";
            this.lblDirection3.Size = new System.Drawing.Size(461, 176);
            this.lblDirection3.TabIndex = 3;
            this.lblDirection3.Text = resources.GetString("lblDirection3.Text");
            this.lblDirection3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picboxExplanation
            // 
            this.picboxExplanation.ErrorImage = null;
            this.picboxExplanation.Image = ((System.Drawing.Image)(resources.GetObject("picboxExplanation.Image")));
            this.picboxExplanation.Location = new System.Drawing.Point(606, 26);
            this.picboxExplanation.Name = "picboxExplanation";
            this.picboxExplanation.Size = new System.Drawing.Size(432, 321);
            this.picboxExplanation.TabIndex = 4;
            this.picboxExplanation.TabStop = false;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDone.Location = new System.Drawing.Point(482, 395);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(84, 28);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // frmHowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1057, 436);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.picboxExplanation);
            this.Controls.Add(this.lblDirection3);
            this.Controls.Add(this.lblDirection2);
            this.Controls.Add(this.lblDirections);
            this.Controls.Add(this.lblDirection1);
            this.Name = "frmHowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How to Play";
            ((System.ComponentModel.ISupportInitialize)(this.picboxExplanation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirection1;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.Label lblDirection2;
        private System.Windows.Forms.Label lblDirection3;
        private System.Windows.Forms.PictureBox picboxExplanation;
        private System.Windows.Forms.Button btnDone;
    }
}