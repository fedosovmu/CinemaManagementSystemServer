using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    public class Hall
    {
        public int ID;
        public int NumberOfPlaces;
        
        public Hall(int ID, int NumberOfPlaces)
        {
            this.ID = ID;
            this.NumberOfPlaces = NumberOfPlaces;
        } 
    }
}
