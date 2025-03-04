using FoxLearn.License;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameQuay
{
    public partial class form_login : Form
    {
        public static form_login form_;
        public form_login()
        {
            InitializeComponent();
            form_ = this;
            if (File.Exists("Key.txt"))
            {
                string readfile = File.ReadAllText("Key.txt");
                guna2TextBox1_key.Text = readfile;
            }
        }
        public static string RandomString()
        {
            string key = "";
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 8; i++)
            {
                if (i == 7)
                {
                    key += new string(Enumerable.Repeat(chars, 5)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                }   
                else
                {
                    key += new string(Enumerable.Repeat(chars, 5)
                        .Select(s => s[random.Next(s.Length)]).ToArray()) + "-";
                }    
            }
            return key;
        }
        private void form_login_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_login_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(@"C:\Program Files\SH"))
            {
                System.IO.Directory.CreateDirectory(@"C:\Program Files\SH");
            }

            if (!File.Exists(@"C:\Program Files\SH\Key.txt"))
            {
                HttpClient httpClientt = new HttpClient();
                string requestUri22 = "https://docs.google.com/spreadsheets/d/11jwdmOw4xzRqDUWbogLE-od6hOc9bPaiGTDDoK-h04k/edit#gid=0";
                string text33 = httpClientt.GetAsync(requestUri22).Result.Content.ReadAsStringAsync().Result.ToString();
                string keyy = "";
                while (true)
                {
                    keyy = RandomString();
                    if (!text33.Contains(keyy))
                    {
                        File.WriteAllText(@"C:\Program Files\SH\key.txt", keyy);
                        break;
                    }
                }
            }
            string key = File.ReadAllText(@"C:\Program Files\SH\Key.txt");
            string keys = guna2TextBox1_key.Text;
            HttpClient httpClient = new HttpClient();
            string requestUri2 = "https://docs.google.com/spreadsheets/d/11jwdmOw4xzRqDUWbogLE-od6hOc9bPaiGTDDoK-h04k/edit#gid=0";
            string text3 = httpClient.GetAsync(requestUri2).Result.Content.ReadAsStringAsync().Result.ToString();
            Match match2 = Regex.Match(text3.ToString(), keys + ".*?(?=ok)");
            bool flag2 = match2 != Match.Empty;
            if (flag2 && key == keys)
            {
                string[] array = match2.ToString().Split(new char[]
                {
                            '|'
                });


                DateTime time = DateTime.Now;
                int dayn = time.Day;
                int monthn = time.Month;
                int yearn = time.Year;

                string[] arrays = array[1].ToString().Split(new char[]
               {
                            '/'
               });

                int dayt = Int32.Parse(arrays[0]);
                int montht = Int32.Parse(arrays[1]);
                int yeart = Int32.Parse(arrays[2]);

                System.DateTime now = new System.DateTime(yearn, monthn, dayn);
                System.DateTime then = new System.DateTime(yeart, montht, dayt);
                System.TimeSpan diff1 = then.Subtract(now);


                int days = (int)Math.Ceiling(diff1.TotalDays);

                bool flag3 = days <= 0;
                if (flag3)
                {
                    MessageBox.Show("Vui lòng liên hệ admin để gia hạn.", "Phần mềm hết hạn" + days, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thành Công .", "Còn lại: " + days + " ngày!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Main.form_.openhome();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(string.Format("Bạn chưa mua bản quyền tool, vui lòng bấm Ctrl + V để gửi mã \"{0}\" cho chúng tôi để kích hoạt tool!", key), "Thông báo active bản quyền!", MessageBoxButtons.OK);

                System.Windows.Forms.Clipboard.SetText(key);
            }

        }

        
        private void guna2TextBox1_key_TextChanged(object sender, EventArgs e)
        {
            File.Delete("Key.txt");
            File.WriteAllText("Key.txt", guna2TextBox1_key.Text);
        }
    }
}
