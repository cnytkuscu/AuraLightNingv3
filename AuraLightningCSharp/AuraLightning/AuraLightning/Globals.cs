using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuraLightning
{
    class Globals
    {
        public static DateTime dt; // Programın açılma süresini tutacaktır.
        public static string postData = @"sorgu=update tblAura set lastLoginDate = '" + DateTime.Now.ToString("yyyy/M/d") + "' , currentStatus  = 1, usageTime = where softwareKey = '1111444477772222' ";
        public static long softwareKey = 1111444477772222;
        public static string DBkontrol = "&kontrol=2679";
        public static string lightMode = "";
        public static RadioButton rb;
        public static string selectedPort;
        public static string selectedGame;
        public static bool isConnected = false;
        public static SerialPort port = new SerialPort();
        public static CheckDeviceConnection checkDevice;
        public static string PortName = "COM3";
        public static Timer tmr;
        
    

    }
}
