/*
 * Microsoft Software and Systems Academy
 * LAB 15 : Properties
 * 
 * Name: Dakin T. Werneburg
 * File: LAB15-automatic-properties.cs
 * Date: 2/25/2021
 */



using System;


namespace AutomaticProperties
{
    class Program
    {
        static void doWork()
        {
            Polygon square = new Polygon();
            Console.WriteLine($"Square: number of sides is {square.NumSides}, length of each side is {square.SideLength}"); 
            
            Polygon triangle = new Polygon { NumSides = 3 };
            Console.WriteLine($"Triangle: number of sides is {triangle.NumSides}, length of each side is {triangle.SideLength}");
            
            Polygon pentagon = new Polygon { SideLength = 15.5, NumSides = 5 };
            Console.WriteLine($"Pentagon: number of sides is {pentagon.NumSides}, length of each side is {pentagon.SideLength}");
        }

        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Polygon
    {

        public int NumSides { get; set; }
        public double SideLength { get; set; }
        public Polygon()
        {
            this.NumSides = 4;
            this.SideLength = 10.0;
        }
    }
}
