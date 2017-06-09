using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    public class Ticket
    {
        public int ID;
        public int Show_ID;
        public string Date;
        public int Place;

        public Ticket(int ID, int Show_ID, string Date, int Place)
        {
            this.ID = ID;
            this.Show_ID = Show_ID;
            this.Date = Date;
            this.Place = Place;
        }
    }
}
