using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuraLightning
{
    public partial class NonGameMenu : Form
    {
        public NonGameMenu()
        {
            InitializeComponent();
        }

        public string colorValue;
        private RadioButton rb;
        private bool isClicked = false;
        TimeSpan ts;

        private void NonGameMenu_Load(object sender, EventArgs e)
        {
            updateLastLoginDate(1);
        }

        private void updateLastLoginDate(int code)
        {
            try
            {
                if (code == 1) // Eğer code 1ise veri tabanındaki son giriş tarihini güncelle.
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://auralightning.xyz/insert.php"); // Post atılacak web site sayfası.
                    Globals.postData = "";
                    Globals.postData = @"sorgu=update tblAura set lastActivity = 'Chill Mode "+Globals.lightMode+"',currentStatus = 1 ,lastLoginDate ='" + DateTime.Now.ToString("yyyy/MM/dd") + "' where softwareKey='" + Globals.softwareKey + "' ";  // Sorgu
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
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error to update last login date on NonGameMenu.");
            }
        }

        private void updateUsageTime()
        {
            try
            {
                ts = DateTime.Now - Globals.dt;
                Globals.dt = DateTime.Now;

                var request = (HttpWebRequest)WebRequest.Create("http://auralightning.xyz/insert.php"); // Post atılacak web site sayfası.
                Globals.postData = "";
                Globals.postData = @"sorgu=update tblAura set lastActivity = 'Chill Mode "+Globals.lightMode+"',currentStatus = 0 , usageTime = usageTime %2B" + ts.Seconds + " where softwareKey='" + Globals.softwareKey + "' ";  // Sorgu
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
                var response = (HttpWebResponse)request.GetResponse();
                var sonuc = new StreamReader(response.GetResponseStream()).ReadToEnd();
                MessageBox.Show(sonuc.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("There is an UsageTime Update Error.");
            }
        }


        private void checkRadioButton(Control rb)
        {
            switch (rb.Name)
            {
                case "rbRainbow":
                    {
                        this.Text = "Rainbow Mode ON";
                        Globals.port.Write("#rbRBON\n");
                    }
                    break;
                case "rbRandom":
                    {
                        this.Text = "Random Mode ON";
                        Globals.port.Write("#rbRAON\n");
                    }
                    break;
                case "rbBandW":
                    {
                        this.Text = "Black and White Mode ON";
                        Globals.port.Write("#rbBWON\n");
                    }
                    break;
                case "rbCloud":
                    {
                        this.Text = "Cloud Mode ON";
                        Globals.port.Write("#rbCLON\n");
                    }
                    break;
                case "rbParty":
                    {
                        this.Text = "Party Mode ON";
                        Globals.port.Write("#rbPCON\n");
                    }
                    break;
                case "rbOff":
                    {
                        this.Text = "Aura Lightning OFF";
                        Globals.port.Write("#rbXXON\n");
                    }
                    break;
            }
        }

        private void rbRainbow_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Rainbow";
            
        }
        private void rbRandom_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Random Colors";
            
        }
        private void rbBandW_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Black and White Stripe";
            
        }
        private void rbCloud_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Cloud Colors";
            
        }
        private void rbParty_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Party Colors";
           

        }        
        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            Globals.rb = sender as RadioButton;
            Globals.lightMode = "Lights Off";            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            rb = Globals.rb;           
            //updateLastLoginDate(1);
            System.Threading.Thread.Sleep(300);
            timer1.Start();           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (isClicked == false)
            //{
            //    isClicked = true;
            //    timer1.Start();
            //}
            //else
            //{
                checkRadioButton(rb);
            //}
        }    

        private void NonGameMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                updateUsageTime();
                System.Threading.Thread.Sleep(100);
                Globals.port.Write("#rbXXOF\n");
                Globals.port.Write("#rbXXOF\n");
                Globals.port.Write("#rbXXOF\n");
            }
            catch (Exception)
            {
                MessageBox.Show("Can not turn of the light when form closing.");
            }
        }
    }
}
