/*
-- Author: Dakin Werneburg
 -- Date: 1/29/2021
 
This excerise is about working with exception handling.

It takes user input from console to calcuate geometric properties.
Validates it and throws different exceptions for the invalid responses.
Asks user again for input if incorrect.
.
*/

using System;

namespace cssbs.ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part I
            Console.WriteLine("\nPart 1, circumference and area of a circle.");
            int radius = 0;
            while(true)
            {
                try
                {
                    Console.Write("Enter an integer for the radius: ");
                    radius = checked(int.Parse(Console.ReadLine()));
                    if (radius <= 0) throw new NegativeNumberException();
                    break;
                }
                catch (NegativeNumberException)
                {
                    Console.WriteLine("Your number is out of range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            
            double circumference = 2 * Math.PI * radius;
            Console.WriteLine($"The circumference is {circumference}");
            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"The area is {area}");


            //Part II
            Console.WriteLine("\nPart 2, volume of a hemisphere.");
            double volume = (2 * Math.PI * Math.Pow(radius, 3)) / 3;   //4/3 divided by 2 = 2/3
            Console.WriteLine($"The volume is {volume}");


            //Part III
            Console.WriteLine("\nPart 3, area of triangle (Heron's formula).");
            int a = 0; 
            while(true)
            {
                try
                {
                    Console.Write("Enter an integer for the side A of triangle: ");
                    a = checked(int.Parse(Console.ReadLine()));
                    if (a <= 0) throw new NegativeNumberException();
                    break;
                }
                catch (NegativeNumberException)
                {
                    Console.WriteLine("Your number is out of range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            int b = 0;
            while(true)
            {
                try
                {
                    Console.Write("Enter an integer for the side B of triangle: ");
                    b = checked(int.Parse(Console.ReadLine()));
                    if (b <= 0) throw new NegativeNumberException();
                    break;
                }
                catch (NegativeNumberException)
                {
                    Console.WriteLine("Your number is out of range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            int c =0;
            while(true)
            {
                try
                {
                    Console.Write("Enter an integer for the side C of triangle: ");
                    c = checked(int.Parse(Console.ReadLine()));
                    if (c <= 0) throw new NegativeNumberException();
                    break;
                }
                catch (NegativeNumberException)
                {
                    Console.WriteLine("Your number is out of range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            } 
            

            double p = (a + b + c) / 2.0;
            area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"The area is {area}");

            Console.WriteLine("\nPart 4, solving a quadratic equation.");
            while (true)
            {
                try
                {
                    Console.Write("Enter a non-negative integer for coefficient a: ");
                    a = checked(int.Parse(Console.ReadLine()));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter a non-negative integer for coefficient b:  ");
                    b = checked(int.Parse(Console.ReadLine()));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter a non-negative integer for coefficient c:  ");
                    c = checked(int.Parse(Console.ReadLine()));
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
                finally
                {
                    Console.WriteLine("Okay");
                }
            }
            double positive_num = (-b) + (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)));
            double negative_num = (-b) - (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)));
            double denominator = 2 * a;
            Console.WriteLine($"The positive solution is {positive_num / denominator}");
            Console.WriteLine($"The negative solutiion is {negative_num / denominator}");

        }

        class NegativeNumberException : FormatException
        {
        }
    }
}