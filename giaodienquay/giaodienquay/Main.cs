using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameQuay
{
    public partial class Main : Form
    {
        public static Main form_;
        Panel panelmain = new Panel();
        form_login form_Login = new form_login();
        Form_Home Form_Home = new Form_Home();
        Form_Setting Form_Setting = new Form_Setting();
        public Main()
        {
            InitializeComponent();
            form_ = this;
            //guna2Button3_home.Hide();
            //guna2Button4_setting.Hide();
            //panelmain.Location = new System.Drawing.Point(420, 95);
            //panelmain.Size = new System.Drawing.Size(328, 435);
            //panelmain.BackColor = Color.Transparent;

            //form_Login.TopLevel = false;
            //form_Login.Dock = DockStyle.Fill;
            //panelmain.Controls.Add(form_Login);
            //form_Login.Show();
            //Controls.Add(panelmain);

        }
        bool drag = false;
        Point start_point = new Point(0, 0);
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }
        public void openhome()
        {
            guna2Button3_home.Show();
            guna2Button4_setting.Show();
            panelmain.Controls.Remove(form_Login);
            Controls.Remove(panelmain);
            panelmain.Location = new System.Drawing.Point(72, 76);
            panelmain.Size = new System.Drawing.Size(1087, 515);
            panelmain.BackColor = Color.Transparent;
            Form_Home.TopLevel = false;
            Form_Home.Dock = DockStyle.Fill;
            panelmain.Controls.Add(Form_Home);
            Form_Home.Show();
            Controls.Add(panelmain);
        }

        private void guna2Button3_home_Click(object sender, EventArgs e)
        {
            panelmain.Controls.Remove(Form_Setting);
            panelmain.Controls.Remove(form_Login);
            Controls.Remove(panelmain);
            panelmain.Location = new System.Drawing.Point(72, 76);
            panelmain.Size = new System.Drawing.Size(1087, 515);
            panelmain.BackColor = Color.Transparent;
            Form_Home.TopLevel = false;
            Form_Home.Dock = DockStyle.Fill;
            panelmain.Controls.Add(Form_Home);
            Form_Home.Show();
            Controls.Add(panelmain);
        }

        private void guna2Button4_setting_Click(object sender, EventArgs e)
        {
            Form_Setting.panelsetting.Controls.Remove(Form_Setting.setting_Xe);
            Form_Setting.panelsetting.Controls.Remove(Form_Setting.setting_Thu);
            panelmain.Controls.Remove(Form_Setting);
            panelmain.Controls.Remove(Form_Home);
            Controls.Remove(panelmain);
            panelmain.Location = new System.Drawing.Point(72, 76);
            panelmain.Size = new System.Drawing.Size(1087, 515);
            panelmain.BackColor = Color.Transparent;
            Form_Setting.TopLevel = false;
            Form_Setting.Dock = DockStyle.Fill;
            panelmain.Controls.Add(Form_Setting);
            Form_Setting.Show();
            Controls.Add(panelmain);
        }
        private void guna2Button_Ld_Click(object sender, EventArgs e)
        {

        }
        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Buexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
