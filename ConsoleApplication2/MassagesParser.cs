using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    public class MassagesParser
    {
        public event Action<String, String> AddMovie;
        public event Action<int, String, String> EditMovie;
        public event Action<int> DeleteMovie;

        public void RecognizeMessage(String message)
        {
            var com = message.Split('#');

            if (com.Length < 2) return;
            var cmd = com[0];

            if (cmd == "AddMovie")
            {
                AddMovie(com[1], com[2]);
            }
            else if (cmd == "EditMovie")
            {
                EditMovie(Convert.ToInt32(com[1]), com[2], com[3]);
            }
            else if (cmd == "DeleteMovie")
            {
                DeleteMovie(Convert.ToInt32(com[1]));
            }
        }
    }
}
