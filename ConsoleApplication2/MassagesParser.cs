using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    public class MassagesParser
    {
        public DatabaseManagement Database;
        public BusinessModelManager ModelManager;

        public void RecognizeMessage(String message)
        {
            var com = message.Split('#');

            if (com.Length < 2) return;
            var cmd = com[0];

            if (cmd == "AddMovie")
            {
                var movie = new Movie( ModelManager.Movies.Count + 1, com[1], com[2]);
                ModelManager.Movies.Add(movie);
                ModelManager.SendMoviesList();
            }
            else if (cmd == "EditMovie")
            {
                ModelManager.SendMoviesList();
            }
            else if (cmd == "DeleteMovie")
            {
                ModelManager.SendMoviesList();
            }

        }
    }
}
