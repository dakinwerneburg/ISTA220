/*
 * Microsoft Software & Systems Academy
 * Cloud Application Developer
 * Embry Riddle
 * 
 * Author: Dakin T. Werneburg
 * 2/11/2021
 * 
 * Demonstrates Inheritance and Polymorphism  
 * Using Military Units
 */


using System;
using System.Collections.Generic;

namespace CSharp_Programming_Exercise06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Created 3 Marine Aviation Units
            MilitaryUnit FourthMAW = new MarineAircraftWing("FourthMAW", "Maj.Gen. Bradley S. James", "New Orleans");
            MilitaryUnit MAG49 = new MarineAircraftWing("MAG49", "Col. Llonie A. C. Cobb", "Pennsylvania");
            MilitaryUnit VMGR452 = new VMGR("MALS49", "Lieutenant Colonel Dax R. Mclendon", "New York");

            //Created 3 Marine Ground Units
            MilitaryUnit FirstMarineDiv = new MarineDivision("1st MARDIV", "MajGen Roger B. Turner", "California");
            MilitaryUnit FirstMarineReg = new MarineRegiment("1st MARREG", "Col Brandon Graham", "California");
            MilitaryUnit FirstBattalion = new MarineBattalion("1/1st Marines", "LtCol. Frank P. Mease", "California");

            
            List<MilitaryUnit> JointForce = new List<MilitaryUnit>();
            JointForce.Add(FourthMAW);
            JointForce.Add(MAG49);
            JointForce.Add(VMGR452);
            JointForce.Add(FirstMarineDiv);
            JointForce.Add(FirstMarineReg);
            JointForce.Add(FirstBattalion);


         foreach(MilitaryUnit mu in JointForce)
            {
                Console.WriteLine("\n\n-------------------------------------------------------------------------");
                Console.WriteLine(mu.Branch);
                Console.WriteLine(mu.Type);
                Console.WriteLine(mu.Commander);
                Console.WriteLine(mu.Location);
                mu.Deploy("Iraq");
                mu.Return();

                MarineBattalion mb;
                if (mu is MarineBattalion)
                {
                    mb = (MarineBattalion)mu;
                    mb.Attack("Fallujah");
                }
            }
            Console.ReadKey();
        }
    }

    interface MilitaryUnit
    {
        string Branch { get; }   
        string Type { get; }    //Air, Ground, etc.
        string Name { get; }
        string Commander { get; set; }
        string Location { get; set; }  //Home Base
        void Deploy(string location);
        void Return();

    }




    class MarineAircraftWing : MilitaryUnit
    {
        public string Branch => "USMC";

        public string Type => "Aviation";

        public string Name { get; }

        public string Commander { get; set; }
        public string Location { get; set; }

        public MarineAircraftWing(string name, string commander, string location)
        {
            Commander = commander;
            Name = name;
            Location = location;
        }

        public virtual void Return()
        {
            Console.WriteLine("Cancel room reservations"); ;
        }

        public virtual void Deploy(string location)
        {
            Console.WriteLine($"Booking hotel rooms near {location}");
        }
    }

    class MarineAircraftGroup : MarineAircraftWing
    {
        public MarineAircraftGroup(string name, string commander, string location) : base(name,commander,location)
        {
        }

        public override void Return()
        {
            Console.WriteLine("Turn in Laptops");
        }

        public override void Deploy(string location)
        {
            Console.WriteLine($"Establish network connection at {location}");
        }
    }

    class VMGR : MarineAircraftGroup
    {
        public VMGR(string name, string commander, string location) : base(name, commander, location)
        {
        }

        public override void Return()
        {
            Console.WriteLine("Conduct Long overdue Maintenance on Aircraft");
        }

        public override void Deploy(string location)
        {
            Console.WriteLine($"Airlift personnel Equipment to {location}");
        }
    }

    class MarineDivision : MilitaryUnit
    {
        public string Branch => "USMC";

        public string Type => "Ground";

        public string Name { get; }

        public string Commander { get; set; }
        public string Location { get; set; }

        public MarineDivision(string name, string commander, string location)
        {
            Commander = commander;
            Name = name;
            Location = location;
        }

        public virtual void Return()
        {
            Console.WriteLine("Thank Marines for job well done and get on the boat."); ;
        }

        public virtual void Deploy(string location)
        {
            Console.WriteLine($"Prepare plans and consolidate resources to {location}");
        }
    }

    class MarineRegiment : MarineDivision
    {

        public MarineRegiment(string name, string commander, string location) : base(name, commander, location)
        {
        }

        public override void Return()
        {
            Console.WriteLine("Check, double check everyone is accounted for"); 
        }

        public override void Deploy(string location)
        {
            Console.WriteLine($"Ensure all troops pack enough toliet paper for {location}");
        }
    }

    class MarineBattalion : MarineRegiment
    {

        public MarineBattalion(string name, string commander, string location) : base(name, commander, location)
        {
        }

        public override void Return()
        {
            Console.WriteLine("Preparing to mobilize in 6 months"); ;
        }

        public override void Deploy(string location)
        {
            Console.WriteLine($"Rehersal, Rehersal then get on ship to {location}");
        }

        public void Attack(string target)
        {
            Console.WriteLine($"Destroy everything in {target}");
        }

    }


}
