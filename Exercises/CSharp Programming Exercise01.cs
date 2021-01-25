using System;

namespace progex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            Console.WriteLine("Enter an integer for the radius: ");
            string strradius = Console.ReadLine();
            int intradius = int.Parse(strradius);
            double circumference = 2 * Math.PI * intradius;
            Console.WriteLine($"The circumference is {circumference}");
            double area = Math.PI * Math.Pow(intradius,2);
            Console.WriteLine($"The area is {area}");

            Console.WriteLine("\nPart 2, volume of a hemisphere.");
            double volume = (2 * Math.PI * Math.Pow(intradius,3))/3;   //4/3 divided by 2 = 2/3
            Console.WriteLine($"The volume is {volume}");

            Console.WriteLine("\nPart 3, area of triangle (Heron's formula).");
            Console.WriteLine("Enter an integer for the side A of triangle: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter an integer for the side B of triangle: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter an integer for the side C of triangle: ");
            int c = Convert.ToInt32(Console.ReadLine());
            double p = (a + b + c) / 2.0;
            area = Math.Sqrt(p * (p-a) * (p-b) * (p-c) );
            Console.WriteLine($"The area is {area}");

            Console.WriteLine("\nPart 4, solving a quadratic equation.");
            Console.WriteLine("Enter a non-negative integer for coefficient a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a non-negative integer for coefficient b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a non-negative integer for coefficient c");
            c = Convert.ToInt32(Console.ReadLine());
            double positive_num = (-b) + (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)));
            double negative_num = (-b) - (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)));
            double denominator = 2 * a;
            Console.WriteLine($"The positive solution is {positive_num / denominator}");
            Console.WriteLine($"The negative solutiion is {negative_num / denominator}");
        }
    }
}
