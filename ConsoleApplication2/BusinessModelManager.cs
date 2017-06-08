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
        public MassagesParser Parser;
        public DatabaseManagement Database;

        List<Movie> Movies;
        // Shows
        // Tickets
        List<Hall> Halls;

        public BusinessModelManager()
        {
            DataInitialization();
            LoadData();
            EventsInitialization();
            StartServer();
        }

        public void DataInitialization()
        {
            Console.WriteLine("Подключение базы данных");
            Database = new DatabaseManagement();

            //Database.InsertIntoMovies(0, "lolko", "ololo");
        }

        public void LoadData()
        {

        }

        public void EventsInitialization()
        {
            Parser = new MassagesParser();
            //Server.ClientReciveMessage += (message) => Parser.RecognizeMessage(message);
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
