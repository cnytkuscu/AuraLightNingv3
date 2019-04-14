using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuraLightning
{
    public class CheckDeviceConnection
    {
        //public String[] ports;
        public List<string> ports;

        int counter = 0;

        public CheckDeviceConnection()
        {
            getAvailableComPorts();
        }
        public CheckDeviceConnection(int code) // Burası timer1'in çalıştırdığı kısım.
        {
            //getAvailableComPorts();
            checkPorts();
        }
        public void checkPorts()
        {
            getAvailableComPorts();
            foreach (var item in ports)
            {
                if(item == "COM3")
                {
                    counter++;
                }
                if(counter ==0)
                {
                    Globals.tmr.Stop();
                    MessageBox.Show("Please Check your Arduino Connection !! ");
                }
            }
        }



        public void getAvailableComPorts()
        {
            //ports = SerialPort.GetPortNames();
            
            ports = SerialPort.GetPortNames().ToList();
            ports.Remove("COM1");

        }


    }
}
