using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystemServer
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManagement dbm = new DatabaseManagement();
            dbm.InsertIntoMovies(2, "Gladiator", "bla");
            dbm.UpdateMovies(0,"Gladiator","lol");

            //foreach(var b in blabla)
            //{
            //    Console.WriteLine(b);
            //}

        }
    }
}
