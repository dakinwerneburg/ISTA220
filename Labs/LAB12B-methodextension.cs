using System;
using Extensions;

namespace ExtensionMethod
{
    class Program
    {
        static void doWork()
        {
            bool continued = true;
            while (continued)
            {
                Console.Write("Enter a number:");
                string inputString = Console.ReadLine();
                int x = int.Parse(inputString);
                if( x < 1)
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);

                }
                for (int i = 2; i <= 10; i++)
                {
                    Console.WriteLine($"{x} in base {i} is {x.ConvertToBase(i)}");
                }
            }
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


    static class Util
    {
        public static int ConvertToBase(this int i, int baseToConvertTo)
        {
            if (baseToConvertTo < 2 || baseToConvertTo > 10)
            {
                throw new ArgumentException("Value cannot be converted to base " +
                    baseToConvertTo.ToString());
            }

            int result = 0;
            int iterations = 0;

            do
            {
                int nextDigit = i % baseToConvertTo;
                i /= baseToConvertTo;
                result += nextDigit * (int)Math.Pow(10, iterations);
                iterations++;
            } while (i != 0);

            return result;
        }
    }
}
