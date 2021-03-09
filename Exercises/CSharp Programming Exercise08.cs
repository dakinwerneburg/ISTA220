using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace Exercise08
{
    class Program
    {
        static readonly Random rand = new Random();



        static void Main()
        {
            Console.WriteLine("************************************************\n" +
                               "*    Microsoft Software & Systems Academy      *\n" +
                               "*          ISTA 220 Exercise 08                *\n" +
                               "*--------------------------------------------- *\n" +
                               "*                                              *\n" +
                               "*            Bisection Search Algorith         *\n" +
                               "*                  Demonstration               *\n" +
                               "*                                              *\n" +
                               "*             Press Any Key To Continue        *\n" +
                               "************************************************\n");
            Console.ReadKey();
            Console.Clear();

            //Bisection Search Algorithm - searches user input 1-10
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int number = GetInputNumber(1, 10);
            BiSectionSearch(list, number);
            Console.WriteLine("\nPress any key to go to the game");
            Console.ReadKey();
            Console.Clear();


            //Guessing Game Intro
            Console.WriteLine("**************************************************\n" +
                               "*          Mr. Roboto's Guessing Game           *\n" +
                               "*                                               *\n" +
                               "*  Instructions:                                *\n" +
                               "*                                               *\n" +
                               "*  First you will guess a number between        *\n" +
                               "*  1 and 1000 until you quit. The the computer  *\n" +
                               "*  will go, and at the end of each round        *\n" +
                               "*  it will show what the average number         *\n" +
                               "*  of guess it took to answer.                  *\n" +
                               "*                                               *\n" +
                               "*             Press Any Key To Continue         *\n" +
                               "************************************************\n");
            ComputerSays("Hello I am Mr Roboto and Welcome to my Guessing Game");
            ComputerSays("When you are ready press any key to continue");
            Console.ReadKey();
            Console.Clear();


            //Player guesses
            List<int> HumanGuesses;
            HumanGuesses = PlayHumanGuess();


            //Having the Computer Guess
            ComputerSays("How about I try now");
            ComputerSays("When your ready to begin press any key");
            Console.ReadKey();
            Console.Clear();
            List<int> ComputerGuesses;
            ComputerGuesses = PlayComputerGuess();

            Console.Clear();
            Console.WriteLine("                 Game Results                   ");
            int count = 1;
            double avg = 0;
            Console.WriteLine("------------------------------------------------\n" +
                              "|  Player  |  Game#  |  # Guesses | Avg Guesses|");
            Console.WriteLine("------------------------------------------------");
            foreach (int guesses in HumanGuesses)
            {
                avg += guesses;

                Console.WriteLine($"| Human    |   {count,-3}   |  {guesses,-9} |   {(avg / count),-5:0.#}    |");
                Console.WriteLine("------------------------------------------------");
                count++;
            }

            count = 1;
            avg = 0;
            foreach (int guesses in ComputerGuesses)
            {
                avg += guesses;
                Console.WriteLine($"| Computer |   {count,-3}   |  {guesses,-9} |   {(avg / count),-5:0.#}    |");
                Console.WriteLine("------------------------------------------------");
                count++;
            }
            ComputerSays("Thanks for playing.  Hit any key to exit. Goodbye");
            Console.ReadKey();

        }



        /// <summary>
        /// Bundles all the logic to allow the Computer to guess the number until user decides to quit.
        /// </summary>
        public static List<int> PlayComputerGuess()
        {

            List<int> numberOfGuesses = new List<int>();
            int turns = 0;

            int[] list = new int[100];
            for (int i = 0; i < 100; i++)
            {
                list[i] = i + 1;
            }

            //Allows mulitple iteration of the computer guess game and get average guesses.
            while (true)
            {

                ComputerSays("You think of a number in your head and tell me if I am too low or too high");
                Console.WriteLine("Please respond to the computer with one of the three commands:\n" +
                    "\t1. Computer guessed correctly\n" +
                                  "\t2.The computer's guess was too low\n" +
                                  "\t3. The computer's guess was too high.\n");


                int number = GetInputNumber(1, 100);
                int count = ComputerGuessNumber(list, number);

                //Error check before adding to list
                if (count < 0) continue;


                turns += count;
                numberOfGuesses.Add(count);
                if (IsStillGuessing())
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            return numberOfGuesses;
        }

        /// <summary>
        /// Bundles all the logic to allow the User to guess a number unitl they quit.
        /// </summary>
        public static List<int> PlayHumanGuess()
        {
            List<int> numberOfGuesses = new List<int>();

            while (true)
            {
                ComputerSays("I am thinking of a number between 1 and 1000");
                int number = rand.Next(1, 1000);
                ComputerSays("please guess what that is");
                int count = HumanGuessNumber(number);
                numberOfGuesses.Add(count);
                if (IsStillGuessing())
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }

            }
            return numberOfGuesses;
        }
        /// <summary>
        /// Ask user to continue guessing and validates input
        /// </summary>
        /// <returns>Result of user wanting to continue guessing or not.</returns>
        public static bool IsStillGuessing()
        {
            while (true)
            {

                Console.Write("Continue Guessing? (Y or N):  ");
                try
                {
                    string response = Console.ReadLine();
                    Console.WriteLine();
                    if (response == "Y" || response == "y")
                    {
                        return true;
                    }
                    else if (response == "N" || response == "n")
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Sorry, Not a valid response");

                }
            }

        }
        /// <summary>
        /// Utility that ask user to input a integer and validates it 
        /// is within range.
        /// </summary>
        /// <param name="low">Lowest number user can enter.</param>
        /// <param name="high">Highest number user can enter.</param>
        /// <returns></returns>
        public static int GetInputNumber(int low, int high)
        {
            while (true)
            {

                Console.Write($"Please enter a number between {low} and {high}: ");
                try
                {
                    if (Int32.TryParse(Console.ReadLine(), out int number))
                    {
                        if (number >= low && number <= high)
                        {
                            return number;
                        }
                        throw new ArgumentOutOfRangeException("Number was not within range");
                    }
                    throw new FormatException("Not an integer");
                }
                catch (ArgumentOutOfRangeException e1)
                {
                    Console.WriteLine($"Sorry, try again. {e1.ParamName}.  Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();

                }
                catch (FormatException e2)
                {
                    Console.WriteLine($"Sorry, try again. {e2.Message}.  Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Provides computer voice
        /// </summary>
        /// <param name="message">Message to be spoken by computer</param>
        public static void ComputerSays(string message)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.SetOutputToDefaultAudioDevice();
                synth.Speak(message);
            }
        }




        /// <summary>
        /// This Has the computer guess using either random values within the range or
        /// if optimized is passed, the it will grab the middle element.
        /// </summary>
        /// <param name="list">Sorted array to search</param>
        /// <param name="value">The actual value to be found.</param>
        /// <returns>Number of guess it took to answer correctly</returns>
        public static int ComputerGuessNumber(int[] list, int value, bool optimized = false)
        {
            int turns = 1;
            int guess;
            if (optimized)
            {
                guess = (list.Length - 1) / 2;
            }
            else
            {
                guess = rand.Next(0, list.Length - 1);
            }


            ComputerSays($"is    the    number {list[guess]}");
            Console.WriteLine($"\n--------------------------------------------------------------------\n");
            Console.WriteLine($"Is the number {list[guess]}\n");
            Console.Write($"Value: {value,-10} Guess: {list[guess],-10} \n{PrintArray(list)}\n");


            int response = GetInputNumber(1, 3);

            try
            {
                switch (response)
                {
                    case 1:
                        break;
                    case 2:
                        int[] high = new int[(list.Length - 1) - guess];
                        Array.Copy(list, (guess + 1), high, 0, high.Length);
                        turns += ComputerGuessNumber(high, value);
                        break;
                    case 3:
                        int[] low = new int[guess];
                        Array.Copy(list, 0, low, 0, low.Length);
                        turns += ComputerGuessNumber(low, value);
                        break;
                }
            }
            catch (Exception)
            {
                ComputerSays("You must of made a mistake in saying high or low");
                ComputerSays("Press Any Key To start this round over");
                Console.ReadKey();
                Console.Clear();
                return turns -= 1000;   //Ensures that this round will result in negative value for invalid state
            }
            return turns;
        }

        /// <summary>
        /// This method just lets user know if their guess 
        /// was too high or too low
        /// </summary>
        /// <param name="value">The actual value to be found/</param>
        /// <returns>Number of guesses it took to answer correctly</returns>
        public static int HumanGuessNumber(int value)
        {
            int turns = 1;
            int guess;
            while (true)
            {
                guess = GetInputNumber(1, 1000);

                if (guess == value)
                {
                    ComputerSays($"That was correct and it only took you {turns} guesses");
                    Console.WriteLine($"-------------------------------------------------------------------\n");
                    break;
                }
                else if (guess < value)
                {
                    ComputerSays("Thats Too Low");
                    Console.WriteLine($"\tToo low");
                }
                else
                {
                    ComputerSays("Thats Too High");
                    Console.WriteLine($"\tToo high");
                }
                turns++;
            }
            return turns;
        }

        /// <summary>
        /// Binary Search Algorith with added print statements
        /// To walk through the algorithm
        /// </summary>
        /// <param name="list">Sorted Array of Integers</param>
        /// <param name="value">The value to be searched</param>
        public static void BiSectionSearch(int[] list, int value)
        {

            Console.WriteLine($"The list is now set to {PrintArray(list)}\n");

            int middle = (list.Length - 1) / 2;


            if (list[middle] == value)
            {
                Console.WriteLine($"{value} was found!");
            }
            else if (list[middle] < value)
            {

                Console.Write($"{value} was higher than {list[middle]}.\t");
                int[] high = new int[(list.Length - 1) - middle];
                Array.Copy(list, (middle + 1), high, 0, high.Length);

                BiSectionSearch(high, value);
            }
            else if (list[middle] > value)
            {
                Console.Write($"{value} was lower than {list[middle]}.\t");
                int[] low = new int[middle];
                Array.Copy(list, 0, low, 0, low.Length);
                BiSectionSearch(low, value);
            }
            else
            {
                Console.WriteLine($"\t{value} was not found.  ");
            }
        }

        /// <summary>
        /// Utility Method that Prints array in array format.
        /// </summary>
        /// <param name="array">Array to be printed.</param>
        /// <returns>String representation of the array</returns>
        public static string PrintArray(int[] array)
        {
            string arrayToString = "{";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                    arrayToString += array[i];
                else
                    arrayToString += array[i] + ", ";
            }
            return arrayToString + "}";
        }
    }
}
