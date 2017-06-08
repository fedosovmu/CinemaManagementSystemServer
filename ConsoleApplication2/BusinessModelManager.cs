using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    class BusinessModelManager
    {
        static ServerObject Server;
        static Thread ListenThread;

        public BusinessModelManager()
        {

        }

        public void StartServer()
        {
            try
            {
                Server = new ServerObject();
                ListenThread = new Thread(new ThreadStart(Server.Listen));
                ListenThread.Start();
            }
            catch (Exception ex)
            {
                Server.Disconnect();
                Console.WriteLine(ex.Message);
            }         
        }   
        

    }
}
