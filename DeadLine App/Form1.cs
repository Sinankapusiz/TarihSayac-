using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace DeadLine_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DateTime sonTarih = new DateTime(2020,03,01);
        DateTime bugunTarih = new DateTime();
        DateTime dgsSinavTarihi = new DateTime(2020,08,09);
        DateTime kpssSinavTarihi = new DateTime(2020,10,25);
        Label text;

        private void Form1_Load(object sender, EventArgs e)
        {
            string format = "d : MMMM : yyyy ";
            label6.Text += sonTarih.ToString(format);
            label10.Text += dgsSinavTarihi.ToString(format);
            label17.Text += kpssSinavTarihi.ToString(format);  
            text = label1;
            Zaman(sonTarih,text);
            text = label16;
            Zaman(kpssSinavTarihi, text);
            text = label9;
            Zaman(dgsSinavTarihi, text);
            this.DesktopLocation = new Point(Screen.PrimaryScreen.Bounds.Width-this.Width+2,0);

        }
        public DateTime Zaman(DateTime istenilenTarih, Label text)
        {
            bugunTarih = DateTime.Now;
            DateTime sonucTarih = new DateTime();
            TimeSpan kalanTarih = istenilenTarih.Subtract(bugunTarih);

            if (Convert.ToInt32(kalanTarih.Days) / 30 < 10)
                text.Text = "0" + (Convert.ToInt32(kalanTarih.Days) / 30).ToString() + ":";
            else
                text.Text = (Convert.ToInt32(kalanTarih.Days) / 30).ToString() + ":";

            if (Convert.ToInt32(kalanTarih.Days) % 30 < 10 )
                text.Text += "0" + Convert.ToInt32(kalanTarih.Days) % 30 + ":";
            else
                text.Text += Convert.ToInt32(kalanTarih.Days) % 30 + ":";

            if (Convert.ToInt32(kalanTarih.Hours) < 10)
                text.Text += "0" + kalanTarih.Hours.ToString() + ":";
            else
                text.Text += kalanTarih.Hours.ToString() + ":";
            if (Convert.ToInt32(kalanTarih.Minutes) < 10)
                text.Text += "0" + kalanTarih.Minutes.ToString();
            else
                text.Text += kalanTarih.Minutes.ToString();
            if (Convert.ToInt32(kalanTarih.Days) < 0)
            {
                if (Convert.ToInt32(kalanTarih.Hours) < 0)
                    text.Text = "Süre Doldu!";
            }
            return sonucTarih;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            text = label1;
            Zaman(sonTarih, text);
            text = label16;
            Zaman(kpssSinavTarihi, text);
            text = label9;
            Zaman(dgsSinavTarihi, text);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("DeadLine App", Application.ExecutablePath.ToString());
            MessageBox.Show("çalıştı");
        }
    }
}
