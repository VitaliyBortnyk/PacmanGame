namespace Pacman
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbNickname = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbRegistration = new System.Windows.Forms.Label();
            this.tbNickname = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbLogIn = new System.Windows.Forms.Label();
            this.lbMenu = new System.Windows.Forms.Label();
            this.pbVisible = new System.Windows.Forms.PictureBox();
            this.lbIncorectPassword = new System.Windows.Forms.Label();
            this.lbIncorectNick = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisible)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::Pacman.Resource.logo;
            this.pbLogo.Location = new System.Drawing.Point(21, -90);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(998, 333);
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // lbNickname
            // 
            this.lbNickname.AutoSize = true;
            this.lbNickname.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNickname.ForeColor = System.Drawing.Color.Gold;
            this.lbNickname.Location = new System.Drawing.Point(111, 265);
            this.lbNickname.Name = "lbNickname";
            this.lbNickname.Size = new System.Drawing.Size(268, 60);
            this.lbNickname.TabIndex = 2;
            this.lbNickname.Text = "Nickname";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.Gold;
            this.lbPassword.Location = new System.Drawing.Point(533, 265);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(285, 60);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Password";
            // 
            // lbRegistration
            // 
            this.lbRegistration.AutoSize = true;
            this.lbRegistration.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistration.ForeColor = System.Drawing.Color.Orange;
            this.lbRegistration.Location = new System.Drawing.Point(290, 558);
            this.lbRegistration.Name = "lbRegistration";
            this.lbRegistration.Size = new System.Drawing.Size(366, 60);
            this.lbRegistration.TabIndex = 4;
            this.lbRegistration.Text = "Registration";
            this.lbRegistration.Click += new System.EventHandler(this.LbRegistration_Click);
            // 
            // tbNickname
            // 
            this.tbNickname.BackColor = System.Drawing.Color.Black;
            this.tbNickname.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNickname.ForeColor = System.Drawing.Color.Yellow;
            this.tbNickname.Location = new System.Drawing.Point(63, 338);
            this.tbNickname.MaxLength = 16;
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new System.Drawing.Size(370, 57);
            this.tbNickname.TabIndex = 5;
            this.tbNickname.TextChanged += new System.EventHandler(this.tbNickname_TextChanged);
            this.tbNickname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Validator);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.Black;
            this.tbPassword.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.Yellow;
            this.tbPassword.Location = new System.Drawing.Point(501, 338);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(370, 57);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Validator);
            // 
            // lbLogIn
            // 
            this.lbLogIn.AutoSize = true;
            this.lbLogIn.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogIn.ForeColor = System.Drawing.Color.Orange;
            this.lbLogIn.Location = new System.Drawing.Point(399, 487);
            this.lbLogIn.Name = "lbLogIn";
            this.lbLogIn.Size = new System.Drawing.Size(147, 60);
            this.lbLogIn.TabIndex = 7;
            this.lbLogIn.Text = "Play";
            this.lbLogIn.Click += new System.EventHandler(this.LbLogIn_Click);
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.ForeColor = System.Drawing.Color.Orange;
            this.lbMenu.Location = new System.Drawing.Point(399, 700);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(158, 60);
            this.lbMenu.TabIndex = 10;
            this.lbMenu.Text = "Menu";
            this.lbMenu.Click += new System.EventHandler(this.LbMenu_Click);
            // 
            // pbVisible
            // 
            this.pbVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVisible.BackColor = System.Drawing.Color.Transparent;
            this.pbVisible.Location = new System.Drawing.Point(888, 351);
            this.pbVisible.Name = "pbVisible";
            this.pbVisible.Size = new System.Drawing.Size(42, 32);
            this.pbVisible.TabIndex = 11;
            this.pbVisible.TabStop = false;
            this.pbVisible.Click += new System.EventHandler(this.PbVisible_Click);
            // 
            // lbIncorectPassword
            // 
            this.lbIncorectPassword.AutoSize = true;
            this.lbIncorectPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIncorectPassword.ForeColor = System.Drawing.Color.Red;
            this.lbIncorectPassword.Location = new System.Drawing.Point(497, 399);
            this.lbIncorectPassword.MaximumSize = new System.Drawing.Size(370, 50);
            this.lbIncorectPassword.Name = "lbIncorectPassword";
            this.lbIncorectPassword.Size = new System.Drawing.Size(0, 20);
            this.lbIncorectPassword.TabIndex = 9;
            this.lbIncorectPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIncorectNick
            // 
            this.lbIncorectNick.AutoSize = true;
            this.lbIncorectNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIncorectNick.ForeColor = System.Drawing.Color.Red;
            this.lbIncorectNick.Location = new System.Drawing.Point(59, 399);
            this.lbIncorectNick.MaximumSize = new System.Drawing.Size(370, 70);
            this.lbIncorectNick.Name = "lbIncorectNick";
            this.lbIncorectNick.Size = new System.Drawing.Size(0, 20);
            this.lbIncorectNick.TabIndex = 8;
            this.lbIncorectNick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1000, 775);
            this.Controls.Add(this.pbVisible);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.lbIncorectPassword);
            this.Controls.Add(this.lbIncorectNick);
            this.Controls.Add(this.lbLogIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbNickname);
            this.Controls.Add(this.lbRegistration);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbNickname);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbNickname;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbRegistration;
        private System.Windows.Forms.TextBox tbNickname;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbLogIn;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.PictureBox pbVisible;
        private System.Windows.Forms.Label lbIncorectPassword;
        private System.Windows.Forms.Label lbIncorectNick;
    }
}