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
            var modelManager = new BusinessModelManager();
            modelManager.StartServer();
            
        }   
    }
}
