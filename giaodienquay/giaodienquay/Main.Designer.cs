namespace GameQuay
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Buexit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.guna2Button4_setting = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3_home = new Guna.UI2.WinForms.Guna2Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.Buexit);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Location = new System.Drawing.Point(826, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 76);
            this.panel2.TabIndex = 53;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Buexit
            // 
            this.Buexit.BackColor = System.Drawing.Color.Transparent;
            this.Buexit.BorderColor = System.Drawing.Color.Transparent;
            this.Buexit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Buexit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Buexit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Buexit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Buexit.FillColor = System.Drawing.Color.Transparent;
            this.Buexit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Buexit.ForeColor = System.Drawing.Color.White;
            this.Buexit.Image = global::GameQuay.Properties.Resources.icons8_exit_48;
            this.Buexit.ImageSize = new System.Drawing.Size(42, 42);
            this.Buexit.Location = new System.Drawing.Point(299, 0);
            this.Buexit.Name = "Buexit";
            this.Buexit.Size = new System.Drawing.Size(33, 35);
            this.Buexit.TabIndex = 48;
            this.Buexit.Click += new System.EventHandler(this.Buexit_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Image = global::GameQuay.Properties.Resources.icons8_minimize_48;
            this.guna2Button2.ImageSize = new System.Drawing.Size(42, 42);
            this.guna2Button2.Location = new System.Drawing.Point(260, 0);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(33, 35);
            this.guna2Button2.TabIndex = 50;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 76);
            this.panel1.TabIndex = 52;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Thú, Xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Game Quay";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // guna2ResizeForm1
            // 
            this.guna2ResizeForm1.TargetForm = this;
            // 
            // guna2Button4_setting
            // 
            this.guna2Button4_setting.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4_setting.BackgroundImage = global::GameQuay.Properties.Resources._126472;
            this.guna2Button4_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Button4_setting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4_setting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4_setting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4_setting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4_setting.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4_setting.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4_setting.ForeColor = System.Drawing.Color.White;
            this.guna2Button4_setting.Location = new System.Drawing.Point(11, 521);
            this.guna2Button4_setting.Name = "guna2Button4_setting";
            this.guna2Button4_setting.Size = new System.Drawing.Size(44, 45);
            this.guna2Button4_setting.TabIndex = 55;
            this.guna2Button4_setting.Click += new System.EventHandler(this.guna2Button4_setting_Click);
            // 
            // guna2Button3_home
            // 
            this.guna2Button3_home.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3_home.BackgroundImage = global::GameQuay.Properties.Resources._7133312;
            this.guna2Button3_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Button3_home.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3_home.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3_home.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3_home.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3_home.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3_home.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3_home.ForeColor = System.Drawing.Color.White;
            this.guna2Button3_home.Location = new System.Drawing.Point(12, 93);
            this.guna2Button3_home.Name = "guna2Button3_home";
            this.guna2Button3_home.Size = new System.Drawing.Size(44, 45);
            this.guna2Button3_home.TabIndex = 54;
            this.guna2Button3_home.Click += new System.EventHandler(this.guna2Button3_home_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameQuay.Properties.Resources.material_style_5k_hd6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1156, 588);
            this.Controls.Add(this.guna2Button4_setting);
            this.Controls.Add(this.guna2Button3_home);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button Buexit;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ResizeForm guna2ResizeForm1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3_home;
        private Guna.UI2.WinForms.Guna2Button guna2Button4_setting;
    }
}

