namespace Pacman
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lbPlay = new System.Windows.Forms.Label();
            this.lbAuthorization = new System.Windows.Forms.Label();
            this.lbResults = new System.Windows.Forms.Label();
            this.lbExit = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPlay
            // 
            this.lbPlay.AutoSize = true;
            this.lbPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbPlay.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlay.ForeColor = System.Drawing.Color.Orange;
            this.lbPlay.Location = new System.Drawing.Point(437, 357);
            this.lbPlay.Name = "lbPlay";
            this.lbPlay.Size = new System.Drawing.Size(147, 60);
            this.lbPlay.TabIndex = 1;
            this.lbPlay.Text = "Play";
            this.lbPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPlay.Click += new System.EventHandler(this.LbPlay_Click);
            // 
            // lbAuthorization
            // 
            this.lbAuthorization.AutoSize = true;
            this.lbAuthorization.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthorization.ForeColor = System.Drawing.Color.Orange;
            this.lbAuthorization.Location = new System.Drawing.Point(304, 437);
            this.lbAuthorization.Name = "lbAuthorization";
            this.lbAuthorization.Size = new System.Drawing.Size(412, 60);
            this.lbAuthorization.TabIndex = 2;
            this.lbAuthorization.Text = "Authorization";
            this.lbAuthorization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAuthorization.Click += new System.EventHandler(this.LbAuthorization_Click);
            // 
            // lbResults
            // 
            this.lbResults.AutoSize = true;
            this.lbResults.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResults.ForeColor = System.Drawing.Color.Orange;
            this.lbResults.Location = new System.Drawing.Point(399, 521);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(223, 60);
            this.lbResults.TabIndex = 3;
            this.lbResults.Text = "Results";
            this.lbResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbResults.Click += new System.EventHandler(this.LbResults_Click);
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.Orange;
            this.lbExit.Location = new System.Drawing.Point(443, 606);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(135, 60);
            this.lbExit.TabIndex = 4;
            this.lbExit.Text = "Exit";
            this.lbExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExit.Click += new System.EventHandler(this.LbExit_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::Pacman.Resource.logo;
            this.pbLogo.Location = new System.Drawing.Point(21, -90);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(1000, 400);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1000, 775);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.lbAuthorization);
            this.Controls.Add(this.lbPlay);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbPlay;
        private System.Windows.Forms.Label lbAuthorization;
        private System.Windows.Forms.Label lbResults;
        private System.Windows.Forms.Label lbExit;
    }
}