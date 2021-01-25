using System;


namespace RecurrsionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            long sumOfNumbers = SumMethod(0, 0, 10);
            Console.WriteLine(sumOfNumbers);
            long factorial = CalcFactorial(1, 1, 10);
            Console.WriteLine(factorial);
        }

        private static long CalcFactorial(long fac, int start, int end)
        {
           Console.WriteLine($"Calling SumMethod({fac},{start},{end})");
           if (start == end) 
                return 0;
           else 
                return CalcFactorial(fac * start, start + 1, end);

        }

        private static long SumMethod(long sum, int start, int end)
        {
            Console.WriteLine($"Calling SumMethod({sum},{start},{end})");
            if (start > end) 
                return sum;
            else 
                return SumMethod(sum + start, start + 1, end);
               
        }
    }
}
