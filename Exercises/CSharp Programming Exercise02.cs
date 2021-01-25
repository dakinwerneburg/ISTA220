using System;

namespace progex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("part1, sum 10 numbers.");
            int sum = SumTenInts(0, 0);
            char letterGrade = 'X';
            Console.WriteLine($"the sum of ten integers is {sum}");


            Console.WriteLine("\npart 2, average 10 numbers");
            double avg = AvgTenInts(0, 0);
            char lettergrade = ConvertNumericToLetterGrade(avg);
            Console.WriteLine($"the average of ten integers is {avg} and the letter " +
                $"grade is {lettergrade}");


            Console.WriteLine("\npart 3, average user predetermined number of scores.\n" +
                "how many scores do you wish to enter?");
            string noscores = Console.ReadLine();
            int numscores = int.Parse(noscores);
            double avg1 = AvgUnkInts(0, 0, numscores);
            lettergrade = ConvertNumericToLetterGrade(avg1);
            Console.WriteLine($"the average of {numscores} integers is {avg1} " +
                $"and the letter grade is {lettergrade}");

            Console.WriteLine("\nPart 4, average non-predetermined number of scores.");
            var avg2 = AvgAnyInts(0, 0);
            letterGrade = ConvertNumericToLetterGrade(avg2.Item1);
            Console.WriteLine($"the average of {avg2.Item2} integers is {avg2.Item1} " +
                $"and the letter grade is {lettergrade}");
        }
        
     
        private static int SumTenInts(int sum, int count)
        {
            int n = 0;
            if (count == 10)
                return sum;
            else
            {
                n = getNumber();
                return SumTenInts(n + sum, ++count);
            }
        }

        private static double AvgTenInts(int sum, int count)
        {
            int n = 0;
            if (count == 10)
                return (double)sum / 10;
            else
            {
                n = getNumber();
                return AvgTenInts(n + sum, ++count);
            }
        }

        private static double AvgUnkInts(int sum, int count, int numscores)
        {
            int n = 0;
            if (count == numscores)
                return (double)sum / numscores;
            else
            {
                n = getNumber();
                return AvgUnkInts(n + sum, ++count, numscores);
            }
        }
        /*In order to get the sum and 
         * the number of intergers inputed,
         * I used a tuple <double,int>
         * To loop unitl exit, I passed the auto 
         * parameter in getNumber method.
         */
        private static (double,int) AvgAnyInts(int sum, int count)
        {
            bool exit = false;
            do
            {
                try
                {             
                    int n = getNumber(true);  //auto is set to true
                    return AvgAnyInts(n + sum, ++count);
                }
                catch (ArgumentException e)
                {
                    if (e.Message == "q")
                        exit = true;
                }
            }while (!exit);
            double avg = (double) sum / count;
            return (avg,count);

        }

        private static char ConvertNumericToLetterGrade(double grade)
        {
            if (grade >= 90)
            {
                return 'A';
            }
            else if (grade >= 80)
            {
                return 'B';
            }
            else if (grade >= 70)
            {
                return 'C';
            }
            else if (grade >= 60)
            {
                return 'D';
            }
            else
                return 'F';
        }
        /*
         * Helper Method that ask user for input and 
         * validates it based on the requirements.
         * Paramter of auto is used to identify that 
         * AvgAnyInts method was called, this will 
         * change the prompt and throw an
         * ArgumentException to single to caller 
         * to exit the method if "q" is entered.
         */
        private static int getNumber(bool auto = false)
        {
            int n = 0;
            if (auto)
                Console.Write($"Enter a score, q to quit:  ");        
            else
                Console.Write("Enter a score:  ");
            string number = Console.ReadLine();
                if (int.TryParse(number, out n))
                {
                    if (n >= 0 && n <= 100)
                    {
                        return n;
                    }                       
                    else
                    {
                        Console.WriteLine($"Number is out of Range [0-100].  Try Again");
                        return getNumber(auto);
                    }
                }
                else if(number.Equals("q") && auto == true)
                {
                    throw new ArgumentException(number);
                }
                else
                {
                Console.WriteLine($"Sorry Not Valid.  Try again") ;
                    return getNumber(auto);
                }            
        }
    }
}

