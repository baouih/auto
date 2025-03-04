using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using TextBox = System.Windows.Forms.TextBox;

namespace GameQuay
{
    public partial class Form_setting_thu : Form
    {
        public static Form_setting_thu form_;
        public Form_setting_thu()
        {
            InitializeComponent();
            form_ = this;
            //panel1.Hide();
            if (File.Exists("datajson.txt"))
            {
                string readjson = File.ReadAllText("datajson.txt");
                if (readjson != "")
                {
                    var deptList = JsonSerializer.Deserialize<Dictionary<string, cjsondata>>(readjson);
                    foreach (var dept in deptList)
                    {
                        Form_Home.form_.adddatajson(dept.Key, dept.Value.Kname, dept.Value.Text);
                    }
                    foreach (var dept in deptList)
                    {
                        if (dept.Value.Kname == "textBoxthu")
                        {
                            TextBox textBox = (TextBox)Controls.Find(dept.Key, true).FirstOrDefault();
                            textBox.Text = dept.Value.Text;
                        }
                        else if (dept.Value.Kname == "buttonthu")
                        {
                            if (dept.Value.Text == "True")
                            {
                                var split = dept.Key.Split('_');
                                listbutton.Add(Convert.ToInt32(split[1]));
                                Guna2Button button = (Guna2Button)Controls.Find(dept.Key, true).FirstOrDefault();
                                button.Image = openblue;
                            }
                        }
                        else if (dept.Value.Kname == "checkboxthu")
                        {
                            if (dept.Value.Text == "True")
                            {
                                var split = dept.Key.Split('_');
                                Guna2CheckBox checkBox = (Guna2CheckBox)Controls.Find(dept.Key, true).FirstOrDefault();
                                checkBox.Checked = true;
                            }
                        }
                    }
                }
            }


        }
        public class cjsondata
        {
            public string Kname { get; set; }
            public string Text { get; set; }

        }
        Bitmap openblue = (Bitmap)Bitmap.FromFile(@"Image\Button_Icon_Blue.svg.png");
        Bitmap openred = (Bitmap)Bitmap.FromFile(@"Image\Button_Icon_Red.svg.png");
        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {

        }
        public List<int> listbutton = new List<int>();
        private void butablexe_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;
            var split = button.Name.Split('_');
            int number = Convert.ToInt32(split[1]);
            if (!listbutton.Contains(number))
            {
                Form_Home.form_.adddatajson(button.Name, "buttonthu", "True");
                listbutton.Add(number);
                button.Image = openblue;
            }
            else
            {
                Form_Home.form_.adddatajson(button.Name, "buttonthu", "False");
                listbutton.Remove(number);
                button.Image = openred;
            }
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_setting_thu_Load(object sender, EventArgs e)
        {
            
        }
        public string[] arraygap()
        {
            string[] arraygap = textBoxthu_arraygap.Text.Split('_');
            return arraygap;
        }
        public int intphantramlon()
        {
            if (textBoxthu_lon.Text != "")
            {
                return Convert.ToInt32(textBoxthu_lon.Text);
            }
            return 0;
        }
        public int Pdep()
        {
            if (textBoxthu_Pdep.Text != "")
            {
                return Convert.ToInt32(textBoxthu_Pdep.Text);
            }
            return 0;
        }
        public int CountFight()
        {
            if (textBoxthu_socay.Text != "")
            {
                return Convert.ToInt32(textBoxthu_socay.Text);
            }
            return 0;
        }
        public int MoneyLimit()
        {
            if (textBoxthu_moneylimit.Text != "")
            {
                return Convert.ToInt32(textBoxthu_moneylimit.Text);
            }
            return 0;
        }
        private void AddDataTextbox(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Form_Home.form_.adddatajson(textBox.Name, "textBoxthu", textBox.Text);
        }
        private void Button_Change(object sender, EventArgs e)
        {

        }
        public bool checkboxp0()
        {
            return guna2CheckBoxthu_P0.Checked;
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CheckBox checkBox = (Guna2CheckBox)sender;
            Form_Home.form_.adddatajson(checkBox.Name, "checkboxthu", checkBox.Checked.ToString());
        }
    }
}
