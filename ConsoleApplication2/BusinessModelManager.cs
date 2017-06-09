using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    public class BusinessModelManager
    {
        public static ServerObject Server;
        public static Thread ListenThread;
        public MassagesParser Parser;
        public DatabaseManagement Database;

        public List<Movie> Movies;
        public List<Hall> Halls;
        public List<Show> Shows;
        public List<Ticket> Tickets;

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
        }

        public void LoadData()
        {
            Console.WriteLine("Загрузка базы данных");
            var line = Database.SelectAllMovies();
            foreach (var elem in line)
                Console.WriteLine(elem);
        }

        public void EventsInitialization()
        {
            Parser = new MassagesParser();
            //Server.ClientReciveMessage += (message) => Parser.RecognizeMessage(message);
        }

        public void StartServer()
        {
            Console.WriteLine("Запуск сервера");
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

        public void SendMoviesList()
        {
            String line = "MoviesList";
            foreach(var elem in Movies)
            {
                line += "#" + elem.ID + ":" + elem.Name + ":" + elem.Description;
            }
            Server.BroadcastMessage(line);
        }

        public void SendShowsList()
        {
            String line = "ShowsList";
            foreach (var elem in Shows)
            {
                line += "#" + elem.ID + ":" + elem.Date + ":" + elem.Movie_ID + ":" + elem.Hall_ID + ":" + elem.Price;
            }
            Server.BroadcastMessage(line);
        }

        public void SendTicketsList()
        {
            String line = "TiketsList";
            foreach (var elem in Tickets)
            {
                line += "#" + elem.ID + ":" + elem.Date + ":" + elem.Show_ID + ":" + elem.Place;
            }
            Server.BroadcastMessage(line);
        }

        public void SendHallsList()
        {
            String line = "HallsList";
            foreach (var elem in Halls)
            {
                line += "#" + elem.ID + ":" + elem.NumberOfPlaces;
            }
            Server.BroadcastMessage(line);
        }
    }
}
