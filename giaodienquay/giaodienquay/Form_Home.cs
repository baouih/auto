using Guna.UI2.WinForms;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace GameQuay
{
    public partial class Form_Home : Form
    {
        public static Form_Home form_;
        public Form_Home()
        {
            InitializeComponent();

            //ADBHelper.ExecuteCMD("adb kill-server");

            form_ = this;
            DictionaryCsetting = new Dictionary<string, cjsondata>();

        }

        private void guna2Button_Restart_Click(object sender, EventArgs e)
        {
            ADBHelper.ExecuteCMD("adb start-server");
            var getdeviceID = ADBHelper.GetDevices();
            guna2ComboBox1.DataSource = getdeviceID;
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_Home_Load(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox13_Click(object sender, EventArgs e)
        {

        }
        void delay(int d)
        {
            Thread.Sleep(d);
        }

        bool dkstart = false;
        Bitmap readpause = (Bitmap)Bitmap.FromFile(@"Image\pause-button.png");
        Bitmap readstart = (Bitmap)Bitmap.FromFile(@"Image\start-button.png");
        Double TongTien = 0;
        private void guna2Button1_start_Click(object sender, EventArgs e)
        {
            TongTien = 0;
            if (!dkstart)
            {
                dkstart = true;
                guna2Button1_start.BackgroundImage = readpause;
                var devices = ADBHelper.GetDevices();
                Thread tt = new Thread(() =>
                {
                    int i = 0;
                    foreach (var deviceID in devices)
                    {
                        Thread t = new Thread(() =>
                        {
                            runmain(deviceID);
                        });
                        t.Start();
                        t.IsBackground = true;
                        delay(2400);
                        i++;

                    }

                });
                tt.Start();
                tt.IsBackground = true;
            }
            else
            {
                dkstart = false;
                guna2Button1_start.BackgroundImage = readstart;
            }
        }
        System.Drawing.Point checkcaptureimage(string deviceID, string file)
        {
            Bitmap doc = (Bitmap)Bitmap.FromFile(file);
            string ID = Regex.Replace(deviceID, ":", "");
            ID = Regex.Replace(ID, "-", "") + "sc";
            Point? point = new Point();
            ADBHelper.ExecuteCMD("adb -s " + deviceID + $" shell screencap /sdcard/{ID}.png");
            ADBHelper.ExecuteCMD("adb -s " + deviceID + $" pull /sdcard/{ID}.png");
            using (Bitmap docne = new Bitmap($"{ID}.png"))
            {
                point = ImageScanOpenCV.FindOutPoint(docne, doc, 0.8);
            }
            File.Delete($"{ID}.png");
            if (point != null)
            {
                return (System.Drawing.Point)point;
            }
            System.Drawing.Point point1 = new System.Drawing.Point(0, 0);
            return point1;
        }
        System.Drawing.Point checkimage(Bitmap sc, string file)
        {
            Bitmap doc = (Bitmap)Bitmap.FromFile(file);
            var point = ImageScanOpenCV.FindOutPoint(sc, doc, 0.8);
            if (point != null)
            {
                return (System.Drawing.Point)point;
            }
            System.Drawing.Point point1 = new System.Drawing.Point(0, 0);
            return point1;
        }
        Bitmap CropImage(Bitmap sc, int pointx, int pointy, int Width, int Height)
        {
            Rectangle crop = new Rectangle(pointx, pointy, Width, Height);
            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(sc, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }
        public class classnumber
        {
            public string number { get; set; }
            public int tdx { get; set; }
        }
        Double getnumberthu(Bitmap imagemain)
        {
            string[] fileList = Directory.GetFiles("numberthu");
            List<classnumber> listnumber = new List<classnumber>();
            for (int inumber = 0; inumber < fileList.Length; inumber++)
            {
                Point? point = new Point();
                using (Bitmap readimg = new Bitmap(fileList[inumber]))
                {
                    point = ImageScanOpenCV.FindOutPoint(imagemain, readimg, 0.8);
                }
                if (point != null)
                {
                    for (int bx = point.Value.X; bx < point.Value.X + 8; bx++)
                    {
                        for (int by = point.Value.Y; by < point.Value.Y + 10; by++)
                        {
                            imagemain.SetPixel(bx, by, Color.White);

                        }
                    }
                    var inumber1 = fileList[inumber].Split('\\');
                    string text = Regex.Replace(inumber1[inumber1.Length - 1], ".png", "");
                    listnumber.Add(new classnumber()
                    {
                        number = text,
                        tdx = point.Value.X
                    });
                    inumber = -1;
                }

            }
            listnumber.Sort((e2, e1) =>
            {
                return e2.tdx.CompareTo(e1.tdx);
            });
            string strnumber = "0";
            foreach (var inumber in listnumber)
            {
                strnumber += inumber.number;
            }
            return Convert.ToDouble(strnumber);

        }
        Double getnumberxe(Bitmap imagemain)
        {
            string[] fileList = Directory.GetFiles("numberxe");
            List<classnumber> listnumber = new List<classnumber>();
            for (int so = 0; so < fileList.Length; so++)
            {
                Point? point = new Point();
                using (Bitmap readimg = new Bitmap(fileList[so]))
                {
                    point = ImageScanOpenCV.FindOutPoint(imagemain, readimg, 0.8);
                }
                if (point != null)
                {
                    for (int bx = point.Value.X; bx < point.Value.X + 8; bx++)
                    {
                        for (int by = point.Value.Y; by < point.Value.Y + 10; by++)
                        {
                            imagemain.SetPixel(bx, by, Color.White);

                        }
                    }
                    var inumber1 = fileList[so].Split('\\');
                    string text = Regex.Replace(inumber1[inumber1.Length - 1], ".png", "");
                    listnumber.Add(new classnumber()
                    {
                        number = text,
                        tdx = point.Value.X
                    });

                    so = -1;
                }

            }
            listnumber.Sort((e2, e1) =>
            {
                return e2.tdx.CompareTo(e1.tdx);
            });
            string strnumber = "0";
            foreach (var inumber in listnumber)
            {
                strnumber += inumber.number;
            }
            return Convert.ToDouble(strnumber);

        }
        Double getnumbertien(string deviceID)
        {
            var sc = scman(deviceID);
            var imagemain = CropImage(sc, 60, 668, 360, 40);
            string[] fileList = Directory.GetFiles("numbertien");
            List<classnumber> listnumber = new List<classnumber>();
            for (int inumber = 0; inumber < fileList.Length; inumber++)
            {
                Point? point = new Point();
                using (Bitmap readimage = new Bitmap(fileList[inumber]))
                {
                    point = ImageScanOpenCV.FindOutPoint(imagemain, readimage, 0.8);
                }
                if (point != null)
                {
                    for (int bx = point.Value.X; bx < point.Value.X + 8; bx++)
                    {
                        for (int by = point.Value.Y; by < point.Value.Y + 10; by++)
                        {
                            imagemain.SetPixel(bx, by, Color.White);
                        }
                    }
                    var inumber1 = fileList[inumber].Split('\\');
                    string text = Regex.Replace(inumber1[inumber1.Length - 1], ".png", "");
                    listnumber.Add(new classnumber()
                    {
                        number = text,
                        tdx = point.Value.X
                    });

                    inumber = -1;
                }

            }
            listnumber.Sort((e2, e1) =>
            {
                return e2.tdx.CompareTo(e1.tdx);
            });
            string strnumber = "0";
            foreach (var inumber in listnumber)
            {
                strnumber += inumber.number;
            }
            return Convert.ToDouble(strnumber);

        }
        public class classFight
        {
            public string type { get; set; }
            public int count { get; set; }
        }
        System.Drawing.Point pointFight(string type)
        {
            var DictionaryPoint = new Dictionary<string, Point>
            {
                ["ferari"] = new Point(28, 35),
                ["porsche"] = new Point(43, 35),
                ["maserati"] = new Point(59, 35),
                ["mercedes"] = new Point(73, 35),
                ["bmw"] = new Point(28, 55),
                ["cadilac"] = new Point(43, 55),
                ["volkswogen"] = new Point(59, 55),
                ["mazda"] = new Point(73, 55),
                ["chimden"] = new Point(22, 34),
                ["chimtrang"] = new Point(33, 34),
                ["khi"] = new Point(66, 34),
                ["tho"] = new Point(78, 34),
                ["caocao"] = new Point(22, 52),
                ["daibang"] = new Point(33, 52),
                ["cavang"] = new Point(44, 52),
                ["caxanh"] = new Point(55, 52),
                ["sutu"] = new Point(66, 52),
                ["gau"] = new Point(78, 52),
            };
            return DictionaryPoint[type];
        }
        List<string> listname = new List<string>() { "ferari", "porsche", "maserati", "mercedes", "bmw", "cadilac", "volkswogen", "mazda", "chimden", "chimtrang", "khi", "tho", "caocao", "daibang", "cavang", "caxanh", "sutu", "gau" };
        List<string> listthu = new List<string>() { "chimden", "chimtrang", "khi", "tho", "caocao", "daibang", "cavang", "caxanh", "sutu", "gau" };
        List<string> listxe = new List<string>() { "ferari", "porsche", "maserati", "mercedes", "bmw", "cadilac", "volkswogen", "mazda" };

        async Task Fight(string deviceID, List<string> listFight, int Countgap, string type)
        {
            Random rd = new Random();
            if (Countgap == -1)
            {
                listFight.RemoveAt(listFight.Count - 1);

                int intrd = -1;
                if (type == "thu")
                {
                    intrd = rd.Next(0, ListThuLon.Count - 1);
                    listFight.Add(ListThuLon[intrd]);
                }
                if (type == "xe")
                {
                    intrd = rd.Next(0, ListXeLon.Count - 1);
                    listFight.Add(ListXeLon[intrd]);
                }
            }
            ADBHelper.TapByPercent(deviceID, 42.0, 93.0);
            delay(1000);
            List<Task> Tasks = new List<Task>();
            await Task.Run(() =>
            {
                foreach (var item in listFight)
                {
                    Tasks.Add(taskFight5(deviceID, type, item, Countgap));
                }
            });

            await Task.WhenAll(Tasks.ToArray());

            List<Task> Tasks1 = new List<Task>();
            ADBHelper.TapByPercent(deviceID, 33.1, 91.9);
            delay(1000);
            await Task.Run(() =>
            {
                foreach (var item in listFight)
                {
                    Tasks1.Add(taskFight1(deviceID, type, item, Countgap));
                }
            });
            await Task.WhenAll(Tasks1.ToArray());
        }

        async Task taskFight5(string deviceID, string type, string Fighttt, int Countgap)
        {
            await Task.Run(async () =>
            {
                int pp = Countgap;
                if (pp == 0)
                {
                    var dic = DictionaryCsetting[$"textBox{type}_" + Fighttt].Text.Split('_');
                    pp = Convert.ToInt32(dic[1]);
                }
                if (pp == -1)
                {
                    var dic = DictionaryCsetting[$"textBox{type}_" + Fighttt].Text.Split('_');
                    pp = Convert.ToInt32(dic[2]);
                }
                var chia5 = pp / 5;
                for (int p = 0; p < chia5; p++)
                {
                    ADBHelper.TapByPercent(deviceID, pointFight(Fighttt).X, pointFight(Fighttt).Y);
                }
            });
        }
        async Task taskFight1(string deviceID, string type, string Fighttt, int Countgap)
        {
            await Task.Run(async () =>
            {
                int pp = Countgap;
                if (pp == 0)
                {
                    var dic = DictionaryCsetting[$"textBox{type}_" + Fighttt].Text.Split('_');
                    pp = Convert.ToInt32(dic[1]);
                }
                if (pp == -1)
                {
                    var dic = DictionaryCsetting[$"textBox{type}_" + Fighttt].Text.Split('_');
                    pp = Convert.ToInt32(dic[2]);
                }
                var chia5 = pp / 5;
                pp -= chia5 * 5;
                for (int p = 0; p < pp; p++)
                {
                    ADBHelper.TapByPercent(deviceID, pointFight(Fighttt).X, pointFight(Fighttt).Y);
                }
            });
        }
        List<string> ListLon = new List<string>() { "ferari", "porsche", "maserati", "mercedes", "daibang", "cavang", "caxanh", "sutu" };
        List<string> ListXeLon = new List<string>() { "ferari", "porsche", "maserati", "mercedes" };
        List<string> ListThuLon = new List<string>() { "daibang", "cavang", "caxanh", "sutu" };
        List<string> ListNho = new List<string>() { "chimden", "chimtrang", "khi", "tho", "caocao", "gau", "bmw", "cadilac", "volkswogen", "mazda" };
        List<string> ListXeNho = new List<string>() { "bmw", "cadilac", "volkswogen", "mazda" };
        List<string> ListThuNho = new List<string>() { "chimden", "chimtrang", "khi", "tho", "caocao", "gau" };
        (bool, List<string>) CheckTableBox(List<string> ListTable, List<int> ListBoxc)
        {
            List<string> list = new List<string>();
            foreach (var value in ListBoxc)
            {
                if (ListLon.Contains(ListTable[value]))
                {
                    return (false, list);
                }
                else
                {
                    list.Add(ListTable[value]);
                }

            }
            return (true, list);
        }

        bool CheckBatThuong(List<string> ListTable)
        {
            for (int i = ListTable.Count - 5; i < ListTable.Count; i++)
            {
                if (ListLon.Contains(ListTable[i]))
                {
                    return false;
                }
            }

            return true;
        }

        Dictionary<string, double> GetPhanTram(Bitmap sc, List<string> ListCheck, int type)
        {
            Dictionary<string, double> ListPhanTram = new Dictionary<string, double>();
            foreach (var value in ListCheck)
            {
                while (dkstart)
                {
                    if (type == 0)
                    {
                        var point = checkimage(sc, @"thu\" + value + ".png");
                        if (point != null)
                        {
                            var crop = CropImage(sc, point.X + 50, point.Y + 6, 100, 38);
                            Double number = 0;
                            number = getnumberthu(crop) / 10;
                            ListPhanTram.Add(value, number);
                            break;
                        }
                    }

                    else if (type == 1)
                    {
                        var point = checkimage(sc, @"xe\" + value + ".png");
                        if (point != null)
                        {
                            var crop = CropImage(sc, point.X + 50, point.Y + 6, 100, 38);
                            Double number = 0;
                            number = getnumberxe(crop) / 10;
                            ListPhanTram.Add(value, number);
                            break;
                        }
                    }
                }
            }

            return ListPhanTram;
        }
        bool CheckPDep(List<string> ListTable, int intpdep)
        {
            for (int i = ListTable.Count - intpdep; i < ListTable.Count; i++)
            {
                if (ListLon.Contains(ListTable[i]))
                {
                    return false;
                }
            }

            return true;
        }
        string ketquatable(Bitmap tablene, int x, int y, string listtype)
        {
            var cr = CropImage(tablene, x, y, 85, 65);
            string[] fileList = Directory.GetFiles(listtype);

            for (int i = 0; i < fileList.Length; i++)
            {
                System.Drawing.Point? point = new Point();
                using (Bitmap docne = new Bitmap(fileList[i]))
                {
                    point = ImageScanOpenCV.FindOutPoint(cr, docne, 0.8);
                }
                if (point != null)
                {
                    var sone = fileList[i].Split('\\');
                    string textne = Regex.Replace(sone[sone.Length - 1], ".png", "");
                    return textne;
                }
            }

            return "";

        }
        List<string> Table(Bitmap tablene, string listtype)
        {
            List<string> listtable = new List<string>();
            for (int y = 0; y <= 325; y += 65)
            {
                for (int x = 0; x <= 855; x += 85)
                {
                    string ketquane = ketquatable(tablene, x, y, listtype);
                    if (ketquane != "")
                    {
                        listtable.Add(ketquane);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return listtable;
        }
        List<string> Getttable(Bitmap sc, int type)
        {
            var listtable = new List<string>();
            if (type == 1)
            {
                using (Bitmap readfile = new Bitmap("xe\\bmw.png"))
                {
                    var point = ImageScanOpenCV.FindOutPoint(sc, readfile, 0.8);
                    var crop = CropImage(sc, point.Value.X - 55, point.Value.Y + 60, 860, 330);
                    listtable = Table(crop, "listxe");
                }
            }
            else if (type == 0)
            {
                using (Bitmap readfile = new Bitmap("thu\\caocao.png"))
                {
                    var cropsc = CropImage(sc, 171, 78, 1100, 260);
                    var point = ImageScanOpenCV.FindOutPoint(cropsc, readfile, 0.8);
                    var crop = CropImage(sc, point.Value.X + 130, point.Value.Y + 132, 860, 330);
                    listtable = Table(crop, "listthu");
                }
            }
            return listtable;
        }
        Bitmap scman(string deviceID)
        {
            string ID = Regex.Replace(deviceID, ":", "");
            ID = Regex.Replace(ID, "-", "") + "cr";
            ADBHelper.ExecuteCMD("adb -s " + deviceID + $" shell screencap /sdcard/{ID}.png");
            ADBHelper.ExecuteCMD("adb -s " + deviceID + $" pull /sdcard/{ID}.png");
            Bitmap newImage = null;
            using (var image = new Bitmap($"{ID}.png"))
            {
                newImage = new Bitmap(image);
            }
            return newImage;
        }

        (int, int, int) OpenGame(string deviceID, bool checkthu, bool checkxe)
        {
            Random rd = new Random();
            int intrdquay = -1;
            if (checkthu && checkxe)
            {
                intrdquay = rd.Next(0, 2);
            }
            else
            {
                if (checkthu)
                {
                    intrdquay = 0;
                }
                else if (checkxe)
                {
                    intrdquay = 1;
                }

            }
            while (dkstart)
            {
                if (intrdquay == 0)
                {
                    bool dkluot = true;
                    for (int q = 0; q < 8; q++)
                    {
                        var point = checkcaptureimage(deviceID, $"IMG\\quaythu{q}.png");
                        if (point.X != 0 || point.Y != 0)
                        {
                            dkluot = false;

                            ADBHelper.Tap(deviceID, point.X + 50, point.Y - 60);
                            ADBHelper.Tap(deviceID, point.X + 50, point.Y - 60);
                            delay(800);
                            return (intrdquay, 0, 0);
                        }
                    }
                    if (dkluot)
                    {
                        ADBHelper.SwipeByPercent(deviceID, 60, 50.9, 35, 50.9, 400);
                        delay(3000);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (intrdquay == 1)
                {
                    bool dkluot = true;
                    for (int q = 0; q < 8; q++)
                    {
                        var point = checkcaptureimage(deviceID, $"IMG\\quayxe{q}.png");
                        if (point.X != 0 || point.Y != 0)
                        {
                            dkluot = false;
                            ADBHelper.Tap(deviceID, point.X + 50, point.Y - 60);
                            ADBHelper.Tap(deviceID, point.X + 50, point.Y - 60);
                            delay(800);
                            return (intrdquay, 0, 0);
                        }
                    }
                    if (dkluot)
                    {
                        ADBHelper.SwipeByPercent(deviceID, 60, 50.9, 35, 50.9, 400);
                        delay(3000);
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return (intrdquay, 0, 0);
        }
        Double TongPhantram(Dictionary<string, double> GetPhanTram)
        {
            Double tong = 0;
            foreach (var dicvalue in GetPhanTram)
            {
                tong += dicvalue.Value;
            }
            return tong;
        }

        void addvalueform(Dictionary<string, double> keyValues)
        {
            this.Invoke(new Action(() =>
            {
                foreach (var dicvalue in keyValues)
                {
                    Label label = (Label)Controls.Find("label_" + dicvalue.Key, true).FirstOrDefault();
                    label.Text = dicvalue.Value.ToString() + "%";
                }
            }));
        }
        List<string> sortDictionary(List<string> Listnho, Dictionary<string, double> Dictionaryyy, int countfight, int type)
        {
            Random rd = new Random();
            var sortedDictByOrder = Dictionaryyy.OrderBy(v => v.Value);
            var cv = sortedDictByOrder.ToDictionary(pair => pair.Key, pair => pair.Value);
            //for (int i = cv.Count - 1; i >= 0; i--)
            //{
            //    var dict = cv.ElementAt(i);
            //    if (Listnho.Count < countfight)
            //    {
            //        if (!Listnho.Contains(dict.Key))
            //        {
            //            Listnho.Add(dict.Key);
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            List<string> ListNhoo = new List<string>();
            if (type == 0)
            {
                foreach (var itemnho in ListThuNho)
                {
                    if (!Listnho.Contains(itemnho))
                    {
                        ListNhoo.Add(itemnho);
                    }
                }
                int intrd = rd.Next(0, ListNhoo.Count - 1);
                Listnho.Add(ListNhoo[intrd]);
            }
            else if (type == 1)
            {
                foreach (var itemnho in ListXeNho)
                {
                    if (!Listnho.Contains(itemnho))
                    {
                        ListNhoo.Add(itemnho);
                    }
                }
            }
            while (Listnho.Count < countfight)
            {
                int intrd = rd.Next(0, ListNhoo.Count - 1);
                Listnho.Add(ListNhoo[intrd]);
                ListNhoo.Remove(ListNhoo[intrd]);
            }
            return Listnho;
        }
        bool CheckPhanTramDon(Dictionary<string, double> GetPhanTram, int type)
        {
            string typee = "";
            if (type == 0)
            {
                typee = "thu";
            }
            else if (type == 1)
            {
                typee = "xe";
            }
            foreach (var dicvalue in GetPhanTram)
            {
                var dic = DictionaryCsetting[$"textBox{typee}_" + dicvalue.Key].Text.Split('_');
                var pp = Convert.ToInt32(dic[0]);
                if (pp < dicvalue.Value && pp != 0)
                {
                    return false;
                }    
            }
            return true;
        }
        Dictionary<string, double> DictionaryTong(Dictionary<string, double> main , Dictionary<string, double> sub)
        {
            foreach (var dicvalue in sub) 
            {
                main.Add(dicvalue.Key, dicvalue.Value);
            }
            return main;
        }
        (List<string>, double, List<string>) checkdkFight(string deviceID, List<int> ListBoxc, int dkPhanTram, int type, int intpdep, int countfight)
        {
            Random rd = new Random();
            while (dkstart)
            {
                if (type == 1)
                {
                    var point = checkcaptureimage(deviceID, "xe\\bmw.png");
                    if (point.X != 0 || point.Y != 0)
                    {
                        break;
                    }
                }
                else if (type == 0)
                {
                    var point = checkcaptureimage(deviceID, "thu\\caocao.png");
                    if (point.X != 0 || point.Y != 0)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            delay(800);
            var sc = scman(deviceID);
            List<string> listdk = new List<string>();
            Double PhanTramSum = 0;
            var getpt = new Dictionary<string, double>();
            var Dictionarynho = new Dictionary<string, double>();
            var DictionaryTongg = new Dictionary<string, double>();
            List<string> Listnho = new List<string>();
            if (type == 0)
            {
                Listnho = Listthunho;
                getpt = GetPhanTram(sc, ListThuLon, type);
                Dictionarynho = GetPhanTram(sc, Listthunho, type);
                PhanTramSum = TongPhantram(getpt);
            }
            else if (type == 1)
            {
                Listnho = ListThuLon;
                getpt = GetPhanTram(sc, ListXeLon, type);
                Dictionarynho = GetPhanTram(sc, Listxenho, type);
                PhanTramSum = TongPhantram(getpt);
            }
            this.Invoke(new Action(() =>
            {
                if (type == 0)
                {
                    Label label = (Label)Controls.Find($"labelthu_lon", true).FirstOrDefault();
                    label.Text = PhanTramSum.ToString() + "%";
                }
                else if (type == 1)
                {
                    Label label = (Label)Controls.Find($"labelxe_lon", true).FirstOrDefault();
                    label.Text = PhanTramSum.ToString() + "%";
                }
            }));
            addvalueform(getpt);
            DictionaryTongg = DictionaryTong(getpt, Dictionarynho);
            if (PhanTramSum == 0 && ((Form_setting_xe.form_.checkboxp0() && type == 1) || (Form_setting_thu.form_.checkboxp0() && type == 0)))
            {
                listdk.Add("BinhThuong0");
            }
            if (dkPhanTram > PhanTramSum && CheckPhanTramDon(DictionaryTongg, type))
            {
                listdk.Add("Phantram");
                var listtable = Getttable(sc, type);
                if (listtable.Count >= 48)
                {
                    var dktable = CheckTableBox(listtable, ListBoxc);
                    Listnho = dktable.Item2.Distinct().ToList();
                    if (Listnho.Count < countfight)
                    {
                        Listnho = sortDictionary(Listnho, Dictionarynho, countfight, type);
                    }
                    else if (Listnho.Count > countfight)
                    {
                        int intt = Listnho.Count - countfight;
                        for (int i = 0; i <= intt; i++)
                        {
                            Listnho.RemoveAt(i);
                        }

                        List<string> ListNhoo = new List<string>();
                        if (type == 0)
                        {
                            foreach (var itemnho in ListThuNho)
                            {
                                if (!Listnho.Contains(itemnho))
                                {
                                    ListNhoo.Add(itemnho);
                                }
                            }
                        }
                        else if (type == 1)
                        {
                            foreach (var itemnho in ListXeNho)
                            {
                                if (!Listnho.Contains(itemnho))
                                {
                                    ListNhoo.Add(itemnho);
                                }
                            }
                        }

                        int intrd = rd.Next(0, ListNhoo.Count - 1);
                        Listnho.Add(ListNhoo[intrd]);
                    }
                    if (dktable.Item1)
                    {
                        bool dkbatthuong = CheckBatThuong(listtable);
                        if (dkbatthuong)
                        {
                            bool dkpdep = CheckPDep(listtable, intpdep);
                            if (dkpdep)
                            {
                                listdk.Add("Gap");
                            }
                            else
                            {
                                listdk.Add("BinhThuong");
                            }
                        }
                        else
                        {
                            bool dkp1 = CheckPDep(listtable, 1);
                            if (!dkp1)
                            {
                                listdk.Add("FightPhanTram1");
                            }
                            listdk.Add("FightPhanTram");
                        }
                    }
                    else
                    {
                        listdk.Add("Fighth1n3");
                    }
                }
                else
                {
                    listdk.Remove("Phantram");
                }

            }

            return (listdk, PhanTramSum, Listnho);
        }
        public class cjsondata
        {
            public string Kname { get; set; }
            public string Text { get; set; }

        }
        public Dictionary<string, cjsondata> DictionaryCsetting;
        public void adddatajson(string name, string kname, string text)
        {
            DictionaryCsetting.Remove(name);
            DictionaryCsetting.Add(name, new cjsondata { Kname = kname, Text = text });

            var cvjson = JsonSerializer.Serialize(DictionaryCsetting);
            File.Delete("datajson.txt");
            File.WriteAllText("datajson.txt", cvjson);
        }

        List<string> Listthunho = new List<string>() { "chimden", "chimtrang", "khi", "tho", "caocao", "gau" };
        List<string> Listxenho = new List<string>() { "bmw", "cadilac", "volkswogen", "mazda" };

        List<string> ListFight0(int intCountFigh, int type)
        {
            List<string> Listthunhoo = Listthunho;
            List<string> Listxenhoo = Listxenho;
            if (type == 0)
            {
                if (Listthunhoo.Count > intCountFigh)
                {
                    int intt = Listthunhoo.Count - intCountFigh;
                    for (int i = 0; i < intt; i++)
                    {
                        Listthunhoo.RemoveAt(i);
                    }
                }
                return Listthunhoo;
            }
            else
            {
                if (Listxenhoo.Count > intCountFigh)
                {
                    int intt = Listxenhoo.Count - intCountFigh;
                    for (int i = 0; i < intt; i++)
                    {
                        Listxenhoo.RemoveAt(i);
                    }
                }

                return Listxenhoo;
            }
        }
        void runmain(string deviceID)
        {
            Double tien = 0;
            while (dkstart)
            {
                List<int> ListBoxxthu = Form_setting_thu.form_.listbutton;
                List<int> ListBoxxxe = Form_setting_xe.form_.listbutton;
                string[] arraygapthu = Form_setting_thu.form_.arraygap();
                string[] arraygapxe = Form_setting_xe.form_.arraygap();
                int intphantramlonthu = Form_setting_thu.form_.intphantramlon();
                int intphantramlonxe = Form_setting_xe.form_.intphantramlon();
                int intPdepthu = Form_setting_thu.form_.Pdep();
                int intPdepxe = Form_setting_xe.form_.Pdep();

                int intCountFighthu = Form_setting_thu.form_.CountFight();
                int intCountFightxe = Form_setting_xe.form_.CountFight();

                int intFighth1n3 = 0;
                int intFightPhanTram = 0;
                int intFightPhanTram0 = 0;
                bool dkFightPhanTram = true;
                bool dkFightPhanTram1 = true;
                bool dkFighth1n3 = true;
                int intgap = 0;

                int moneylimitthu = Form_setting_thu.form_.MoneyLimit();
                int moneylimitxe = Form_setting_xe.form_.MoneyLimit();

                var tOpenGame = OpenGame(deviceID, guna2CheckBox1_thu.Checked, guna2CheckBox2_xe.Checked);

                bool Out = false;
                while (dkstart)
                {
                    if (tOpenGame.Item1 == 0)
                    {
                        var point = checkcaptureimage(deviceID, "IMG\\thubd.png");
                        if (point.X != 0 || point.Y != 0)
                        {
                            while (dkstart)
                            {
                                if (moneylimitthu < TongTien && TongTien != 0)
                                {
                                    dkstart = false;
                                    break;
                                }    
                                point = checkcaptureimage(deviceID, "IMG\\thubd1.png");
                                if (point.X != 0 || point.Y != 0)
                                {
                                    Double so = getnumbertien(deviceID);
                                    Double tttien = so - tien;
                                    tien = so;
                                    TongTien += tttien;
                                    this.Invoke(new Action(() =>
                                    {
                                        labeltongtien.Text = TongTien.ToString();
                                    }));

                                    ADBHelper.TapByPercent(deviceID, 97.5, 45.3);
                                    delay(2000);

                                    var CheckdkFight = checkdkFight(deviceID, ListBoxxthu, intphantramlonthu, tOpenGame.Item1, intPdepthu, intCountFighthu);

                                    ADBHelper.TapByPercent(deviceID, 83.0, 12.0);
                                    delay(1200);

                                    if (CheckdkFight.Item1.Count > 0)
                                    {
                                        while (dkstart)
                                        {
                                            point = checkcaptureimage(deviceID, "IMG\\thubd.png");
                                            if (point.X == 0 && point.Y == 0)
                                            {
                                                if (CheckdkFight.Item1.Contains("BinhThuong0"))
                                                {
                                                    Fight(deviceID, ListFight0(intCountFighthu, tOpenGame.Item1), 0, "thu");
                                                }
                                                else
                                                {
                                                    if ((!CheckdkFight.Item1.Contains("FightPhanTram") && dkFightPhanTram) || !dkFighth1n3)
                                                    {
                                                        if (CheckdkFight.Item1.Contains("Fighth1n3") || !dkFighth1n3)
                                                        {
                                                            dkFighth1n3 = false;
                                                            intFighth1n3++;
                                                            if (intFighth1n3 == 3)
                                                            {
                                                                Fight(deviceID, CheckdkFight.Item3, -1, "thu");
                                                                dkFighth1n3 = true;
                                                                intFighth1n3 = 0;
                                                            }
                                                        }
                                                        else if (CheckdkFight.Item1.Contains("Gap"))
                                                        {
                                                            int cvgap = Convert.ToInt32(arraygapthu[intgap]);
                                                            Fight(deviceID, CheckdkFight.Item3, cvgap, "thu");
                                                            intgap++;
                                                        }
                                                        else if (CheckdkFight.Item1.Contains("BinhThuong"))
                                                        {
                                                            Fight(deviceID, CheckdkFight.Item3, 0, "thu");
                                                        }
                                                    }

                                                    if (CheckdkFight.Item1.Contains("FightPhanTram1") && !dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        dkFightPhanTram1 = false;
                                                    }
                                                    if (CheckdkFight.Item1.Contains("FightPhanTram") && dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        dkFightPhanTram = false;
                                                    }
                                                    if (!dkFightPhanTram1 && dkFighth1n3)
                                                    {
                                                        intFightPhanTram0++;
                                                        if (intFightPhanTram0 == 3)
                                                        {
                                                            Fight(deviceID, CheckdkFight.Item3, -1, "thu");
                                                            intFightPhanTram0 = 0;
                                                        }
                                                    }
                                                    else if (!dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        Fight(deviceID, CheckdkFight.Item3, -1, "thu");
                                                        intFightPhanTram++;

                                                        if (intFightPhanTram == 6)
                                                        {
                                                            dkFightPhanTram = true;
                                                            intFightPhanTram = 0;
                                                        }
                                                    }
                                                    if (!CheckdkFight.Item1.Contains("Gap") || (arraygapthu.Length - 1) == intgap)
                                                    {
                                                        intgap = 0;
                                                    }
                                                }

                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Out = true;
                                        ADBHelper.TapByPercent(deviceID, 3.3, 4.9);
                                        delay(600);
                                        ADBHelper.TapByPercent(deviceID, 3.3, 38.9);
                                        delay(800);
                                        //ADBHelper.TapByPercent(deviceID, 78.0, 28.5);
                                        //delay(800);
                                        ADBHelper.SwipeByPercent(deviceID, 40, 50.9, 90, 50.9, 800);
                                        delay(6000);
                                    }
                                    break;
                                }
                            }
                            if (Out)
                            {
                                break;
                            }
                        }
                    }
                    else if (tOpenGame.Item1 == 1)
                    {
                        var point = checkcaptureimage(deviceID, "IMG\\xebd.png");
                        if (point.X != 0 || point.Y != 0)
                        {
                            while (dkstart)
                            {
                                if (moneylimitxe < TongTien && TongTien != 0)
                                {
                                    dkstart = false;
                                    break;
                                }
                                point = checkcaptureimage(deviceID, "IMG\\xebd.png");
                                if (point.X == 0 && point.Y == 0)
                                {
                                    Double so = getnumbertien(deviceID);
                                    Double tttien = so - tien;
                                    tien = so;
                                    TongTien += tttien;
                                    this.Invoke(new Action(() =>
                                    {
                                        labeltongtien.Text = TongTien.ToString();
                                    }));

                                    ADBHelper.TapByPercent(deviceID, 97.5, 45.3);
                                    delay(2000);

                                    var CheckdkFight = checkdkFight(deviceID, ListBoxxxe, intphantramlonxe, tOpenGame.Item1, intPdepxe, intCountFightxe);

                                    ADBHelper.TapByPercent(deviceID, 83.0, 12.0);
                                    delay(1200);
                                    if (CheckdkFight.Item1.Count > 0)
                                    {
                                        while (dkstart)
                                        {
                                            point = checkcaptureimage(deviceID, "IMG\\xebd.png");
                                            if (point.X == 0 && point.Y == 0)
                                            {
                                                if (CheckdkFight.Item1.Contains("BinhThuong0"))
                                                {
                                                    Fight(deviceID, ListFight0(intCountFightxe, tOpenGame.Item1), 0, "thu");
                                                }
                                                else
                                                {
                                                    if ((!CheckdkFight.Item1.Contains("FightPhanTram") && dkFightPhanTram) || !dkFighth1n3)
                                                    {
                                                        if (CheckdkFight.Item1.Contains("Fighth1n3") || !dkFighth1n3)
                                                        {
                                                            dkFighth1n3 = false;
                                                            intFighth1n3++;
                                                            if (intFighth1n3 == 3)
                                                            {
                                                                Fight(deviceID, CheckdkFight.Item3, -1, "xe");
                                                                dkFighth1n3 = true;
                                                                intFighth1n3 = 0;
                                                            }
                                                        }
                                                        else if (CheckdkFight.Item1.Contains("Gap"))
                                                        {
                                                            int cvgap = Convert.ToInt32(arraygapxe[intgap]);
                                                            Fight(deviceID, CheckdkFight.Item3, cvgap, "xe");
                                                            intgap++;
                                                        }
                                                        else if (CheckdkFight.Item1.Contains("BinhThuong"))
                                                        {
                                                            Fight(deviceID, CheckdkFight.Item3, 0, "xe");
                                                        }
                                                    }

                                                    if (CheckdkFight.Item1.Contains("FightPhanTram1") && !dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        dkFightPhanTram1 = false;
                                                    }
                                                    if (CheckdkFight.Item1.Contains("FightPhanTram") && dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        dkFightPhanTram = false;
                                                    }
                                                    if (!dkFightPhanTram1 && dkFighth1n3)
                                                    {
                                                        intFightPhanTram0++;
                                                        if (intFightPhanTram0 == 3)
                                                        {
                                                            Fight(deviceID, CheckdkFight.Item3, -1, "xe");
                                                            intFightPhanTram0 = 0;
                                                        }
                                                    }
                                                    else if (!dkFightPhanTram && dkFighth1n3)
                                                    {
                                                        Fight(deviceID, CheckdkFight.Item3, -1, "xe");
                                                        intFightPhanTram++;

                                                        if (intFightPhanTram == 6)
                                                        {
                                                            dkFightPhanTram = true;
                                                            intFightPhanTram = 0;
                                                        }
                                                    }
                                                    if (!CheckdkFight.Item1.Contains("Gap") || (arraygapxe.Length - 1) == intgap)
                                                    {
                                                        intgap = 0;
                                                    }
                                                }

                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Out = true;
                                        ADBHelper.TapByPercent(deviceID, 3.3, 4.9);
                                        delay(600);
                                        ADBHelper.TapByPercent(deviceID, 3.3, 38.9);
                                        delay(800);
                                        //ADBHelper.TapByPercent(deviceID, 78.0, 28.5);
                                        //delay(800);
                                        ADBHelper.SwipeByPercent(deviceID, 40, 50.9, 90, 50.9, 800);
                                        delay(6000);
                                    }
                                    break;
                                }
                            }
                            if (Out)
                            {
                                break;
                            }    
                        }

                    }

                }
            }


        }

    }
}
