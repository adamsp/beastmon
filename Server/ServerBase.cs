using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace Beastmon2.Server
{
    class ServerBase
    {
        Thread monitoringThread;
        private static bool running;

        private HttpListener listener;

        public ServerBase()
        {
           this.monitoringThread = new Thread(ComputerInfo.Monitor);
           this.monitoringThread.Start();
           this.listener = new HttpListener();
        }

        public void Listen()
        {
            running = true;
            listener.Prefixes.Add("http://*:5300/");
            listener.Start();
            try
            {
                while (running)
                {
                    HttpListenerContext context = listener.GetContext();
                    new Thread(new ServerResponder(context).ProcessRequest).Start();
                }
            }
            catch (Exception) { }
            
            listener.Close();
            ComputerInfo.Stop();
        }

        public void Stop()
        {
            running = false;
            listener.Stop();
        }
    }
}
