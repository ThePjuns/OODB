using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage;
using Model;

namespace OODB
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(new ManageFacilities().GetFromId(1));

            new ManageFacilities().Create(new Facility(8,"Paintball")); //opretter en ny facilitet ved nr 8

            Console.WriteLine(new ManageFacilities().GetFromId(8));

            new ManageFacilities().Update(new Facility(8, "Swordfight"), 8 ); //opdatere facilitet nr 8 til en ny facilitet

            Console.WriteLine(new ManageFacilities().GetFromId(8));

            new ManageFacilities().Delete(8);

                List<Facility> list = new ManageFacilities().GetAll();
                foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }





        }



    }

}
