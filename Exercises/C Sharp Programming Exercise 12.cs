/*
  Microsoft Software and Systems Academy
  C# Excersice 12
  Author: Dakin T. Werneburg
  Date: 4/7/2021
  
  Purpose:  To simulate flash cards for basic 
            math expressions.
*/

using System;

namespace cssbs_ex12_werneburg
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int probType = 0;
            int numbProb = 0;
            int score = 0;
            while (true)
            {
                (probType, numbProb) = FlashCardSimulator.Initialize();
                switch (probType)
                {
                    case 1:
                        score = FlashCardSimulator.Add(numbProb);
                        break;
                    case 2:
                        score = FlashCardSimulator.Subtract(numbProb);
                        break;
                    case 3:
                        score = FlashCardSimulator.Multiply(numbProb);
                        break;
                    case 4:
                        score = FlashCardSimulator.Divide(numbProb);
                        break;

                }
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nYou scored {score} out of {numbProb} with an average of {(score / (double)numbProb)*100:0.0#}%");
                Console.Write("Would you like to Continue? [Y or N]: ");
                Console.ResetColor();
                string toContinue = Console.ReadLine();
                if (toContinue.ToUpper() == "N" || toContinue.ToUpper() == "Y")
                {
                    if (toContinue.ToUpper() == "N") Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Sorry I didn't understand.");
                }
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
                Console.Clear();
                score = 0;
            }
        }
    }

    /// <summary>
    /// Creates practice math problems.  User provides the type of 
    /// math problem and the number of questions they would like to 
    /// attempt.  Division uses eplison of .01 to compare floating point values.
    /// </summary>
    static class FlashCardSimulator
    {
        //sets the max range random number for the problems will be generated
        const int MAX_RANGE = 12;

        const double EPSILON = .01;
        public static (int type, int count) Initialize()
        {
                //Menu
                Console.WriteLine($"".PadLeft(50, '-'));
                Console.WriteLine($"{"",15}Welcome to Math Games");
                Console.WriteLine($"{"",25}Menu");
                Console.WriteLine($"".PadLeft(50, '-'));
                Console.WriteLine($"{"",15}[1] Addition Problems");
                Console.WriteLine($"{"",15}[2] Subtraction Problems");
                Console.WriteLine($"{"",15}[3] Multiplication Problems");
                Console.WriteLine($"{"",15}[4] Division Problems");
                Console.WriteLine($"".PadLeft(50, '-'));

                //Echo User input
                Console.Write("Selection: ");
                int selection = Util.GetIntegerUI(1, 4);
                Console.Write("How many questions: ");
                int numQuestions = Util.GetIntegerUI(1, int.MaxValue);

                return (selection, numQuestions);
        }

        public static int Add(int count)
        {
            var rand = new Random();
            int operand1 = 0;
            int operand2 = 0;
            int correct = 0;

            for (int i = 0; i < count; i++)
            {
                operand1 = rand.Next(1, MAX_RANGE);
                operand2 = rand.Next(1, MAX_RANGE);

                Console.Write($"{"",10}{operand1,2}  + {operand2,2} = ");
                int response = Util.GetIntegerUI(int.MinValue, int.MaxValue);
                int answer = operand1 + operand2;
                if (response == answer)
                {
                    Util.PrintAnswer(response, answer);
                    correct++;
                }
                else
                {
                    Util.PrintAnswer(response, answer);
                }
            }
            return correct;
        }

        public static int Subtract(int count)
        {
            var rand = new Random();
            int operand1 = 0;
            int operand2 = 0;
            int correct = 0;

            for (int i = 0; i < count; i++)
            {
                operand1 = rand.Next(1, 12);
                operand2 = rand.Next(1, 12);

                Console.Write($"{"",10}{Math.Max(operand1, operand2),2}  - {Math.Min(operand1, operand2),2} = ");
                int response = Util.GetIntegerUI(int.MinValue, int.MaxValue);
                int answer = Math.Max(operand1,operand2) - Math.Min(operand1,operand2);
                if (response == answer)
                {
                    Util.PrintAnswer(response, answer);
                    correct++;
                }
                else
                {
                    Util.PrintAnswer(response, answer);
                }
            }
            return correct;
        }

        public static int Multiply(int count)
        {
            var rand = new Random();
            int operand1 = 0;
            int operand2 = 0;
            int correct = 0;
            
            for (int i = 0; i < count; i++)
            {
                operand1 = rand.Next(1, 12);
                operand2 = rand.Next(1, 12);

                Console.Write($"{"",10}{operand1,2}  * {operand2,2} = ");
                int response = Util.GetIntegerUI(int.MinValue, int.MaxValue);
                int answer = operand1 * operand2;
                if (response == answer)
                {
                    Util.PrintAnswer(response, answer);
                    correct++;
                }
                else
                {
                    Util.PrintAnswer(response, answer);
                }
            }
            return correct;
        }

        public  static int Divide(int count)
        {
            var rand = new Random();
            int operand1 = 0;
            int operand2 = 0;
            int correct = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlease answer you problem to two decimal places.  \n");
            Console.ResetColor();
            for (int i = 0; i < count; i++)
            {
                operand1 = rand.Next(1, 12);
                operand2 = rand.Next(1, 12);

                Console.Write($"{"",10}{operand1,2}  / {operand2,2} = ");
                double response = Util.GetDoubleUI(double.MinValue, double.MaxValue);
                double answer = operand1 / (double)operand2;

                if (response == answer || Math.Abs(answer - response) < EPSILON )
                {
                    response = answer;
                    Util.PrintAnswer(response, answer);
                    correct++;
                }
                else
                {
                    Util.PrintAnswer(response, answer);
                }
            }
            return correct;
        }


    }

    /// <summary>
    /// Utility Class that validates user input and prints
    /// and formats question answers
    /// </summary>
    class Util
    {
        /// <summary>
        /// Validates user input
        /// </summary>
        /// <param name="min">largest number allowed</param>
        /// <param name="max">smallest number allowed</param>
        public static int GetIntegerUI(int min, int max)
        {
            
            while (true)
            {
                int xPos = Console.CursorLeft;
                string input = Console.ReadLine();
                try
                {
                    if (int.TryParse(input, out int number) && number >= min && number <= max)
                    {
                        return number;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(input);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Error: {input} is not a valid selection.  Press any key to continue.");
                    Console.ReadKey();
                    ClearInput(xPos);
                }
            }
        }

        public static double GetDoubleUI(double min, double max)
        {

            while (true)
            {
                int xPos = Console.CursorLeft;
                string input = Console.ReadLine();
                try
                {
                    if (double.TryParse(input, out double number) && number >= min && number <= max)
                    {
                        return number;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(input);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Error: {input} is not a valid selection.  Press any key to continue.");
                    Console.ReadKey();
                    ClearInput(xPos);
                }
            }
        }

        /// <summary>
        /// This clears user entered input
        /// </summary>
        /// <param name="cursorPos">last place where the cursor was</param>
        public static void ClearInput(int cursorPos)
        {
            int y = Console.CursorTop - 1;
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', Console.BufferWidth));

            Console.SetCursorPosition(cursorPos, y - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(cursorPos, y - 1);
        }

        public static void PrintAnswer(double response,double answer)
        {
            if (response == answer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(25, Console.CursorTop - 1);
                Console.WriteLine($"{" ",5}Correct!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(25, Console.CursorTop - 1);
                Console.WriteLine($"{" ",5}Incorrect!  Answer: {answer}");
                Console.ResetColor();
            }
        }
    }


}
