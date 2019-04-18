using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuraLightning
{
    public partial class MainMenu : Form
    {
        private bool isChecked = false; //Eğer false'sa gp1 kapalı. Değisle açık.
        private List<string> GameProcessNames = new List<string>();


        public MainMenu()
        {
            InitializeComponent();
        }


        private void MainMenu_Load(object sender, EventArgs e)
        {
            Globals.dt = DateTime.Now;
            fillPorts();

            Globals.tmr = new Timer();
            Globals.tmr.Interval = 500;
            Globals.tmr.Tick += new EventHandler(timer1_Tick);


            GameProcessNames.Add("NFS13"); // .exe is not necessary !!
            GameProcessNames.Add("hl2");

            DisableSections();
            GetProcessNames();
        }

        private void fillPorts()
        {
            Globals.checkDevice = new CheckDeviceConnection(); // Burada comboBox1'i doldurmak için obje oluşturdum.
            foreach (string port in Globals.checkDevice.ports)
            {
                if (Globals.checkDevice.ports[0] != null)
                {
                    comboBox1.SelectedItem = Globals.checkDevice.ports[0];
                }
            }

            foreach (var PortName in Globals.checkDevice.ports)
            {
                comboBox1.Items.Add(PortName);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckDeviceConnection cdc = new CheckDeviceConnection(1); // 1 kodunu gönderip diğer constructor'ı çalıştırıyorum.


            //Globals.checkDevice.getAvailableComPorts();
            //Globals.checkDevice.checkPorts();
        }


        private void DisableSections()
        {
            groupBox1.Enabled = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (isChecked == true) // Eğer gp1 Açıksa
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0) // Eğer cb1 ve cb2 seçiliyse
                {
                    Globals.selectedPort = comboBox1.SelectedItem.ToString();
                    Globals.selectedGame = comboBox2.SelectedItem.ToString();
                    Globals.isConnected = false;

                    if (comboBox2.SelectedItem.ToString() == "NFS13")
                    {
                        GameDetails frm1 = new GameDetails(); // From1 objesi oluşturdum. Yeni bir form ekranı açtım.
                        OpenWindowAndConnectArduino(frm1);
                    }
                    else if (comboBox2.SelectedItem.ToString() == "hl2")
                    {
                        GameDetails css = new GameDetails(); // css objesi oluşturdum. Yeni bir form ekranı açtım. Bu CS Source oyunu için.
                        OpenWindowAndConnectArduino(css);
                    }
                    else
                    {
                        MessageBox.Show("There is a connection Error. !!!");
                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Please Check the PORT and Select the Game !");
                }
            }
            else // If user doesn't select any game mode so I'll open only chill mode menu.
            { // her durumda nasıl olsa bağlanacak. bu yüzden tanımlamayı bu şekilde yaptım.  

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please Check the PORT !");
                }
                else
                {
                    Globals.selectedPort = comboBox1.SelectedItem.ToString();
                    NonGameMenu nonGameMenu1 = new NonGameMenu();
                    OpenWindowAndConnectArduino(nonGameMenu1);
                }
            }
        }

        public void OpenWindowAndConnectArduino(Form FormName)
        {
            try
            {
                if (Globals.isConnected == false)
                {
                    ArduinoConnection.connectToArduino();
                    this.Hide();
                    FormName.Closed += (s, args) => this.Close();
                    FormName.Show();
                }

            }
            catch
            {
                MessageBox.Show("BAĞLANTI HATASI VAR !!!");
            }


        }
        private void GetProcessNames()
        {
            foreach (Process pr in Process.GetProcesses())
            {
                try
                {
                    foreach (string process in GameProcessNames)
                    {
                        if (pr.ProcessName == process) // checking if game is running or not !
                        {
                            comboBox2.Items.Add(pr.ProcessName);  // Adding process name here 
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("There is A BIG ASS ERROR !");
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            isChecked = !isChecked;
            if (isChecked == true)
            {
                groupBox1.Enabled = true; // gp1'i açık hale getiriyorum.   
                label1.Text = "GAME MODE";
            }
            else
            {
                groupBox1.Enabled = false; // gp1'i kapalı hale getiriyorum.
                label1.Text = "COOL MODE";
                //comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
        }

        private void tmrCheckConnection_Tick(object sender, EventArgs e)
        {
            Globals.checkDevice.checkPorts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            fillPorts();
        }
    }
}
