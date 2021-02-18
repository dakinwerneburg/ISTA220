using System;

namespace Vehicles
{
    class Program
    {
        static void doWork()
        {
            Console.WriteLine("Test Vehicle");
            Vehicle v = new Vehicle();
            v.StartEngine("RUM RUM");
            v.Drive();
            v.StopEngine("GIN GIN");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Journey by airplane:"); 
            Airplane myPlane = new Airplane(); 
            myPlane.StartEngine("Contact"); 
            myPlane.TakeOff(); 
            myPlane.Drive(); 
            myPlane.Land(); 
            myPlane.StopEngine("Whirr");
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Journey by car:"); 
            Car annetta = new Car(); 
            annetta.StartEngine("Brm brm"); 
            annetta.Accelerate(); 
            annetta.Drive(); 
            annetta.Brake(); 
            annetta.StopEngine("Phut phut");

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("\nTesting polymorphism");
            Vehicle w = new Vehicle();
            w.Drive();
            w = annetta; 
            w.Drive(); 
            w = myPlane; 
            w.Drive();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Journey by motorcycle:");
            Motorcycle mc = new Motorcycle();
            mc.StartEngine("Hoooonnnnndaaaa");
            mc.Accelerate();
            mc.Drive();
            mc.Brake();
            mc.StopEngine("clunk");
            

        }

        static void Main()
        {
            try
            {
           
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
	
	class Airplane : Vehicle
    {
        public void TakeOff() 
        { 
            Console.WriteLine("Taking off"); 
        }
        public void Land() 
        { 
            Console.WriteLine("Landing");
        }

        public override void Drive() 
        { 
            Console.WriteLine("Flying"); 
        }
    }
	
	class Car : Vehicle
    {
        public void Accelerate() 
        { 
            Console.WriteLine("Accelerating"); 
        }
        public void Brake() 
        { 
            Console.WriteLine("Braking"); 
        }

        public override void Drive() 
        { 
            Console.WriteLine("Motoring"); 
        }
    }
	
	
	class Vehicle
    {
        public void StartEngine(string noiseToMakeWhenStarting) 
        { 
            Console.WriteLine($"Starting engine: {noiseToMakeWhenStarting}"); 
        }
        public void StopEngine(string noiseToMakeWhenStopping) 
        { 
            Console.WriteLine($"Stopping engine: {noiseToMakeWhenStopping}"); 
        }

        public virtual void Drive() 
        { 
            Console.WriteLine("Default implementation of the Drive method"); 
        }
    }
	
	class Motorcycle : Vehicle
    {
        internal void Accelerate()
        {
            Console.WriteLine("Motorcycle going fast");
        }

        internal void Brake()
        {
            Console.WriteLine("Motorcycle skidding tires on pavement");
        }

        public override void Drive()
        {
            Console.WriteLine("Motorcycling");
        }
    }
}




