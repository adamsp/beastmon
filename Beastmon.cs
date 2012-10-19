using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.GUI;
using System.Threading.Tasks;

namespace Beastmon2
{
    public static class Beastmon
    {
        private static Server.ServerBase server;
        //static void Main(string[] args)
        //{
        //    Start();
        //}

        public static void Start()
        {
            if (null == server)
            {
                server = new Server.ServerBase();
                Task.Factory.StartNew(() =>
                    {
                        server.Listen();
                    });
            }
        }
    }
}
