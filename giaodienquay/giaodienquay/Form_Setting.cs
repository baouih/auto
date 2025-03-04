using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameQuay
{
    public partial class Form_Setting : Form
    {
        public static Form_Setting form_;
        public Form_Setting()
        {
            InitializeComponent();
            form_ = this;
        }
        public Panel panelsetting = new Panel();
        public Form_setting_thu setting_Thu = new Form_setting_thu();
        public Form_setting_xe setting_Xe = new Form_setting_xe();
        public Form_setting_LD setting_LD = new Form_setting_LD();
        private void Form_Setting_Load(object sender, EventArgs e)
        {
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_thu_Click(object sender, EventArgs e)
        {
            panelsetting.Controls.Remove(setting_LD);
            panelsetting.Controls.Remove(setting_Xe);
            guna2Panel1.Controls.Remove(panelsetting);
            panelsetting.Location = new System.Drawing.Point(0, 60);
            panelsetting.Size = new System.Drawing.Size(1088, 460);
            panelsetting.BackColor = Color.Transparent;
            setting_Thu.TopLevel = false;
            setting_Thu.Dock = DockStyle.Fill;
            panelsetting.Controls.Add(setting_Thu);
            setting_Thu.Show();
            guna2Panel1.Controls.Add(panelsetting);
        }

        private void guna2Button2_xe_Click(object sender, EventArgs e)
        {
            panelsetting.Controls.Remove(setting_LD);
            panelsetting.Controls.Remove(setting_Thu);
            guna2Panel1.Controls.Remove(panelsetting);
            panelsetting.Location = new System.Drawing.Point(0, 60);
            panelsetting.Size = new System.Drawing.Size(1088, 460);
            panelsetting.BackColor = Color.Transparent;
            setting_Xe.TopLevel = false;
            setting_Xe.Dock = DockStyle.Fill;
            panelsetting.Controls.Add(setting_Xe);
            setting_Xe.Show();
            guna2Panel1.Controls.Add(panelsetting);
        }

        private void guna2Button_LD_Click(object sender, EventArgs e)
        {
            panelsetting.Controls.Remove(setting_Xe);
            panelsetting.Controls.Remove(setting_Thu);
            guna2Panel1.Controls.Remove(panelsetting);
            panelsetting.Location = new System.Drawing.Point(0, 60);
            panelsetting.Size = new System.Drawing.Size(1088, 460);
            panelsetting.BackColor = Color.Transparent;
            setting_LD.TopLevel = false;
            setting_LD.Dock = DockStyle.Fill;
            panelsetting.Controls.Add(setting_LD);
            setting_LD.Show();
            guna2Panel1.Controls.Add(panelsetting);
        }
    }
}
