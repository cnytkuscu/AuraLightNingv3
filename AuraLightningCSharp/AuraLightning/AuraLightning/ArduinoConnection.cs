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
    class ArduinoConnection
    {
             
        public static void connectToArduino()
        {
            
            Globals.port = new SerialPort(Globals.selectedPort, 9600, Parity.None, 8, StopBits.One);
            Globals.isConnected = true;
            Globals.port.Open();
            Globals.tmr.Enabled = true;
            


            MessageBox.Show("Baglandi");

        }
        

    }
}
