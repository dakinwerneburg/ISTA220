/*
  Microsoft Software and Systems Academy
  C# Excersice 13
  Author: Dakin T. Werneburg
  Date: 4/2/2021
  
  Purpose:  To take a list of question from a text file
            and create a History Test in which the user 
            selects the number of questions to answer.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace cssbs_ex13_werneburg
{
    class Program
    {
        const string URL = @"..\..\testbank.txt";
        static void Main(string[] args)
        {
            //Initialize test
            List<Problem> testBank = Util.Initialize(URL);
            Console.WriteLine($"Test bank intitialized, {testBank.Count} lines");

            //Get number of questions from user
            Console.Write("How many questions would you like to answer? [1-13]: ");
            int howMany = Util.GetInteger(1, 13);    

            //Create and issue test
            List<Problem> test = Util.MakeTest(testBank, howMany);
            Console.WriteLine($"\nTest created {test.Count} questions.");
            Console.WriteLine($"".PadLeft(50, '-'));
            Console.WriteLine("Press any key to start test");
            Console.WriteLine($"".PadLeft(50, '-'));

            //Display results
            Console.ReadKey();
            Console.Clear();
            int score = Util.GiveTest(test);
            Console.WriteLine($"You answered {score} out of {howMany} correctly and your grade is {(score/(howMany*1.0))*100:0.0#}%");

        }


        


        
        
    }
    
    /// <summary>
    /// Utilitiy class to get question text file and parses it into
    /// a problem that has a question, choices, and an answer.
    /// Text file is assumed to be csv file with each column containing
    /// double quotes, and each column may also contain double quotes and commas.
    /// My strategy was deliminating each field where a double quote, was
    /// followed by a comma for example: ",
    /// </summary>
    public static class Util
    {
        public static List<Problem> Initialize(string url)
        {
            List<Problem> problems = new List<Problem>();
            try
            {
                using (var sr = new StreamReader(url))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Problem problem = new Problem();
                        string[] columns = Regex.Split(line, "\",");      
                        for (int i = 0; i < columns.Length; i++)
                        {
                            columns[i] = columns[i].Replace("\"", string.Empty).Trim();
                        }
                        problem.Question = columns[0];
                        problem.Answer = columns[1];
                        problem.Choices = columns.Skip(1).ToList();
                        problems.Add(problem);
                        
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File Not Found");
            }
            return problems;

        }

        /// <summary>
        /// This method randomizes the question and postion of the choices 
        /// from the test bank.
        /// </summary>
        /// <param name="testbank">Complete list of Problems</param>
        /// <param name="number">Number of questions user wants to answer</param>
        /// <returns>List of Problems in random order</returns>
        public static List<Problem> MakeTest(List<Problem> testbank, int number)
        {
            //HashSet used for to ensure only unique values are added as it chooses random questions.
            HashSet<Problem> test = new HashSet<Problem>();
           
            Random rand = new Random();
            while (test.Count < number)
            {
                Problem problem = testbank.ElementAt(rand.Next(0, 13));

                //radomizes the choices by swapping indexes
                List<string> choices = new List<string>(problem.Choices.Count);
                int index = rand.Next(choices.Count + 1);
                string temp = problem.Choices[index];
                problem.Choices[index] = problem.Choices[choices.Count];
                problem.Choices[choices.Count] = temp;
                test.Add(problem);
            }
                return test.ToList();
        }

        /// <summary>
        /// Simple User interface to present the problems to the user and show thier results
        /// </summary>
        /// <param name="test">List of problems that will be presented</param>
        /// <returns>Number of correct responses</returns>
        public static int GiveTest(List<Problem> test)
        {
            int score = 0;
            
            for (int i = 0; i < test.Count; i++)
            {
                string answer = test[i].Answer;

                //Displays question
                Console.WriteLine($"{i+1}. {test[i].Question}");
                
                //Displays Choices
                for (int j = 0; j < test[i].Choices.Count; j++)
                {
                    Console.WriteLine($"\t{j+1}. {test[i].Choices[j]}");
                }
                Console.Write("Answer: ");

                //Gets User response
                int response = GetInteger(1, 4);

                //Validated their response and updates score
                if(answer  == test[i].Choices[response-1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect!\n\n");
                    Console.ResetColor();
                    score++;
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry, the correct answer is {answer}\n\n");
                    Console.ResetColor();
                }
            }
            return score;
        }

        /// <summary>
        /// Helper method that just validates user input is a number with a range
        /// </summary>
        /// <param name="min">min integer value allowed</param>
        /// <param name="max">max integer value allowed</param>
        /// <returns></returns>
        public static int GetInteger(int min, int max)
        {
            while (true)
            {
                int xPos = Console.CursorLeft;
                string input = Console.ReadLine();
                try
                {
                    if (int.TryParse(input, out int number))
                    {
                        if (number >= min && number <= max)
                        {
                            return number;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(input);
                        }
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

        //simple clears invalid respose
        public static void ClearInput(int cursorPos)
        {
            int y = Console.CursorTop - 1;
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', Console.BufferWidth));

            Console.SetCursorPosition(cursorPos, y - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(cursorPos, y - 1);
        }


        
    }
    
    /// <summary>
    /// Simple struct to represent a Problem
    /// </summary>
    public struct Problem
    {
        public string Answer { get; set; }
        public List<string> Choices { get; set; }
        public string Question { get; set; }
    }
}
