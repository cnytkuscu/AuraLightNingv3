using System;
using System.Diagnostics;
using System.Windows.Forms;
using Teknolider; // Adamın Classı
using System.Drawing;
using System.Text;
using System.Net;
using System.IO;

namespace AuraLightning
{
    public partial class GameDetails : Form
    {



        private int GameIndexRow, pointer, offset; // timer'da ve ReadPointer fonksiyonunda kullanılan değerler burada tutuluyor.



        public GameDetails()
        {
            InitializeComponent();

        }

        Bellek oku;
        Process[] prc = Process.GetProcessesByName(Globals.selectedGame);
        float valueMPH = 0;
        Int64 anaAdres = 0;
        TimeSpan ts;

        double valueKM;

        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.dt = DateTime.Now; // Form açıldığında başlangıç zamanını aldım.
            tmrDBUpdate.Start();


            switch (Globals.selectedGame)
            {
                case "NFS13": { GameIndexRow = 0; pointer = 0; offset = 1; break; }
                case "CSGO": { GameIndexRow = 1; pointer = 0; offset = 1; break; }
                case "diablo3": { GameIndexRow = 2; pointer = 0; offset = 1; break; }
                default:
                    {
                        MessageBox.Show("AURA Lightning Doesn't Support this Game...");
                        break;
                    }
            }
            oku = new Bellek(prc[0]);
            foreach (ProcessModule modul in prc[0].Modules)

                if (modul.ModuleName == Globals.selectedGame + ".exe")
                {
                    anaAdres = modul.BaseAddress.ToInt64();

                    timer1.Enabled = true;
                }
        }
        //"NFS13.exe"+0043D508
        //154+65c+778+160+4+a0


        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadPointerValue(GameIndexRow, pointer, offset);
            SendInputToArduino();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.isConnected = false;
            Globals.port.Write("#rbXXON\n");
            Globals.port.Close();

            updateUsageTime();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            TerminateFunc(1, null);
        }

        private void ReadPointerValue(int GameIndexRow, int pointer, int offset)
        {
            //valueMPH = (float)Math.Round(Convert.ToDouble((float)oku.Float_Oku_Offset(anaAdres +0xD0FD88, "8+50+36c+40+110+17c")), 2);  // this is the value that comes as MPH(mile per hour)3

            //I've to convert the value which comes from GameMenu.cs to long. Cuz it's hexadecimal. So I used ,16 on cenverting. EZ ! 25 minutes...
            valueMPH = (float)Math.Round(Convert.ToDouble((float)oku.Float_Oku_Offset(anaAdres + Convert.ToInt64(GameValue.pointer_offset[GameIndexRow, pointer], 16), GameValue.pointer_offset[GameIndexRow, offset])), 2);
            valueKM = Math.Round(Math.Round(valueMPH, 2) * (1.609344), 2); // I'm changing the MPH value to KM metric.  

            if (valueMPH < 0 || valueKM < 0)  // If the velocity is less than 0 so I change the color of texts.
            {
                lblValueMPH.ForeColor = Color.Maroon;
                lblValueMPH.Text = (valueMPH * (-1)).ToString();

                lblValueKM.ForeColor = Color.Maroon;
                lblValueKM.Text = (valueKM * (-1)).ToString();

                progressBar1.Value = Convert.ToInt32(valueKM * (-1)); // Adapting the progressbar as the negative result.

            }
            else
            {
                lblValueMPH.ForeColor = Color.Black;
                lblValueMPH.Text = valueMPH.ToString();

                lblValueKM.ForeColor = Color.Black;
                lblValueKM.Text = valueKM.ToString();

                progressBar1.Value = Convert.ToInt32(valueKM); // Adapting the progressbar to speed result.

            }
        }

        //Buradaki olay şu. DB'den toplam oynanama süresini çekicem. Sonra Oradan gelen veriyi kullanarak üzerine ekleme yapıcam.
        private void tmrDBUpdate_Tick(object sender, EventArgs e)
        {
            updateLastLoginDate(1);

        }
        /// <summary>
        /// Bu fonksiyon program açıldığında kullanıcının son giriş yaptığı tarihi güncellemek amaçlıdır.
        /// </summary>
        private void updateLastLoginDate(int code)
        {
            if (code == 1) // Eğer code 1ise veri tabanındaki son giriş tarihini güncelle.
            {
                var request = (HttpWebRequest)WebRequest.Create("http://auralightning.xyz/insert.php"); // Post atılacak web site sayfası.
                Globals.postData = "";
                Globals.postData = @"sorgu=update tblAura set lastActivity = 'Need For Speed Most Wanted Limited Edition',currentStatus = 1 ,lastLoginDate ='" + DateTime.Now.ToString("yyyy/MM/dd") + "' where softwareKey='" + Globals.softwareKey + "' ";  // Sorgu
                Globals.postData += Globals.DBkontrol; // kontrol değişkeni. websitesinde bu kod ile kontrol ediliyor. Eğer farklı bir kodla gönderilmişse hata verir.
                var data = Encoding.ASCII.GetBytes(Globals.postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            tmrDBUpdate.Stop();
            MessageBox.Show("tmrUpdateDB has stopped.");            
        }        

        //Form ekranı kapanırken db'yi güncelleyecek.
        private void updateUsageTime()
        {            
            try
            {
                ts = DateTime.Now - Globals.dt;
                Globals.dt = DateTime.Now;
                //MessageBox.Show(ts.Seconds.ToString());
                var request = (HttpWebRequest)WebRequest.Create("http://auralightning.xyz/insert.php"); // Post atılacak web site sayfası.
                Globals.postData = "";
                Globals.postData = @"sorgu=update tblAura set currentStatus =0 , usageTime = usageTime %2B"+ts.Seconds+" where softwareKey='" + Globals.softwareKey + "' ";  // Sorgu
                Globals.postData += Globals.DBkontrol; // kontrol değişkeni. websitesinde bu kod ile kontrol ediliyor. Eğer farklı bir kodla gönderilmişse hata verir.
                var data = Encoding.ASCII.GetBytes(Globals.postData);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Veri Okuma kodları.
                //var response = (HttpWebResponse)request.GetResponse();
                //var sonuc = new StreamReader(response.GetResponseStream()).ReadToEnd();               
            }
            catch (Exception)
            {
                MessageBox.Show("There is an UsageTime Update Error.");
            }
            
        }



        private void SendInputToArduino()
        {
            if (Globals.isConnected == true)
            {
                //In the arduino code section I've a formula.  
                //'#' means that new command is coming.
                //'LEDX' number of LED that I'll light on or off.
                //'ON' or 'OF' is the position of LED.
                // '\n' is the definition of end of the command.              

                try
                {
                    if (valueKM < 2)
                    {
                        Globals.port.Write("#LEDAOF\n");
                    }
                    else if (valueKM > 10 && valueKM < 45)
                    {
                        Globals.port.Write("#LED0ON\n");
                        Globals.port.Write("#LED1OF\n");
                    }
                    else if (valueKM >= 45 && valueKM < 90)
                    {
                        Globals.port.Write("#LED1ON\n");

                        Globals.port.Write("#LED2OF\n");
                    }
                    else if (valueKM >= 90 && valueKM < 135)
                    {
                        Globals.port.Write("#LED2ON\n");

                        Globals.port.Write("#LED3OF\n");
                    }
                    else if (valueKM >= 135 && valueKM < 180)
                    {
                        Globals.port.Write("#LED3ON\n");

                        Globals.port.Write("#LED4OF\n");
                    }
                    else if (valueKM >= 180 && valueKM < 225)
                    {
                        Globals.port.Write("#LED4ON\n");

                        Globals.port.Write("#LED5OF\n");
                    }
                    else if (valueKM >= 225 && valueKM < 270)
                    {
                        Globals.port.Write("#LED5ON\n");

                        Globals.port.Write("#LED6OF\n");
                    }
                    else if (valueKM >= 270 && valueKM < 315)
                    {
                        Globals.port.Write("#LED6ON\n");

                        Globals.port.Write("#LED7OF\n");
                    }
                    else if (valueKM >= 315 && valueKM < 360)
                    {
                        Globals.port.Write("#LED7ON\n");

                        Globals.port.Write("#LED8OF\n");
                    }
                    else if (valueKM >= 360 && valueKM < 405)
                    {
                        Globals.port.Write("#LED8ON\n");

                        Globals.port.Write("#LED9OF\n");
                    }
                    else if (valueKM >= 405)
                    {
                        Globals.port.Write("#LED9ON\n");
                    }
                }
                catch (Exception e)
                {
                    TerminateFunc(0, e);
                }

            }
        }
        /// <summary>
        /// This function is for terminating the object and returning to main menu.
        /// </summary>
        /// <param name="code">0 code for connection error of Arduino device.</param>
        /// <param name="code">1 code for clicking MENU button.</param>
        private void TerminateFunc(int code, Exception e)
        {
            if (code == 0)
            {
                timer1.Stop();
                MessageBox.Show("Close error: " + e.Message + "\n");
                Globals.port.Close();
                MainMenu menu = new MainMenu(); // From1 objesi oluşturdum. Yeni bir form ekranı açtım.
                this.Hide();
                menu.Closed += (s, args) => this.Close();
                menu.Show();
            }
            else if (code == 1)
            {
                MainMenu menu = new MainMenu(); // From1 objesi oluşturdum. Yeni bir form ekranı açtım.
                this.Hide();
                menu.Closed += (s, args) => this.Close();
                menu.Show();
            }
            else
            {
                MessageBox.Show("There is a fatal error. Code 404.");
            }
        }
    }
}
