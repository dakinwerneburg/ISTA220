/**
 *  Microsoft Software and Systems Academy 
 *  Cloud Applications Certification
 *  Embry Riddle
 *  
 *  Excercise 7 
 *  Author: Dakin T. Werneburg
 *  Date: 2/27/2021
 * 
 */ 


using System;
using System.Collections.Generic;
using System.Threading;

namespace ccsbs_ex07_werneburg
{
    class Program
    {
        static void Main()
        {

            RouletteTable rouletteTable = new RouletteTable();

            //Presents Information Related to the game
            rouletteTable.DrawGameIntroduction();
            rouletteTable.ShowBetInformation();
            Console.ResetColor();


           


            //Spins the Roulette Wheel and will simulate the ball and bin
            string BinSlot = rouletteTable.RouletteWheel.SpinWheel();

            Console.Clear();
            rouletteTable.GetOdds();
            rouletteTable.RouletteWheel.DrawWheel();
            Console.ResetColor();

            //Iterates through all the bets placed and prints results to console.
            foreach (Bet bet in rouletteTable.Bets)
            {
                if (bet.IsWinner(BinSlot))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"The bet was called: {bet.Name,-10}  You selected: {bet.Selection,-15} and the bin landed on: {BinSlot}");
                    Console.WriteLine($"   -  WINNER!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"The bet was called: {bet.Name,-10}  You selected: {bet.Selection,-15} and the bin landed on: {BinSlot}");
                }
            }


        }

 

 


    }

    /// <summary>
    /// Roulette Wheel is composed of three bins.  It will 
    /// then rotate the wheel from right to left only showing 
    /// the previous, current, and next number.  Simple animation
    /// is created using the Console and Thread classes.
    /// </summary>
    class RouletteWheel
    {
        public Bin Bin { get; }
        public string PreviousNumber { get; set; }
        public string CurrentNumber { get; set; }
        public string NextNumber { get; set; }

        public RouletteWheel()
        {
            Bin = new Bin();
        }

        public void DrawWheel()
        {
            //Draws Two Rows of Current Color for each bin for room above number
            for (int k = 0; k < 2; k++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("               ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.BackgroundColor = Bin.NumberColor[PreviousNumber.Trim()];
                Console.Write("     ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.BackgroundColor = Bin.NumberColor[CurrentNumber.Trim()];
                Console.Write("     ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.BackgroundColor = Bin.NumberColor[NextNumber.Trim()];
                Console.Write("     ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" \n");
            }

            //Draws a border and the ball in the bin
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("               ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("|     |  @  |     |\n");
            Console.ForegroundColor = ConsoleColor.White;

            //Displays a row of the associated color bin to give space above number
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("               ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[PreviousNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[CurrentNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[NextNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" \n");

            //Draws number and color of bin
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("               ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[PreviousNumber.Trim()];
            Console.Write($" {PreviousNumber}  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[CurrentNumber.Trim()];
            Console.Write($" {CurrentNumber}  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[NextNumber.Trim()];
            Console.Write($" {NextNumber}  ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" \n");

            //Provides some space below the number
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("               ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[PreviousNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[CurrentNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.BackgroundColor = Bin.NumberColor[NextNumber.Trim()];
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" \n");
        }

        public string SpinWheel()
        {


            Console.ForegroundColor = ConsoleColor.White;
            int timer = 1;
            Random rand = new Random();
            int winningNumber = rand.Next(0, 37);

            /*
             * Will run go around all numbers at least 3 times 
             * and on the last iteration will stop at the 
             * winning ball.
             */
            for (int i = 0; i < 3
                ; i++)
            {
                for (int j = 1; j < Bin.Numbers.Length - 1; j++)
                {
                    PreviousNumber = Bin.Numbers[j - 1];
                    CurrentNumber = Bin.Numbers[j];
                    NextNumber = Bin.Numbers[j + 1];

                    int binNumber = Int32.Parse(CurrentNumber);

                    DrawWheel();

                    if (binNumber == winningNumber && i == 2)
                    {
                        Console.ResetColor();
                        break;
                    }
                    //provides for the animation by refreshing every 30 miliseconds
                    Thread.Sleep(timer++);
                    Console.ResetColor();
                    Console.Clear();
                }
            }
            return CurrentNumber;
        }
    }

    class RouletteTable
    {
        public List<Bet> Bets { get; }

        public RouletteWheel RouletteWheel { get; }
        public RouletteTable()
        {
            RouletteWheel = new RouletteWheel();
            Bets = new List<Bet>();
        }

        public void ShowBetInformation()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("**************************************************************************\n" +
                              "*                     Bets                                               *\n" +
                              "*                                                                        *\n" +
                              "*  1. Numbers:  Pick a Number 0-36                                       *\n" +
                              "*  2. Evens / Odds: even or odd numbers                                  *\n" +
                              "*  3. Reds / Blacks: red or black colored numbers                        *\n" +
                              "*  4. Lows / Highs: low(1 – 18) or high(19 – 38) numbers.                *\n" +
                              "*  5. Dozens: row thirds, 1 – 12, 13 – 24, 25 – 36                       *\n" +
                              "*  6. Columns: first, second, or third columns                           *\n" +
                              "*  7. Street: rows, e.g., 1 / 2 / 3 or 22 / 23 / 24                      *\n" +
                              "*  8. 6 Numbers: double rows, e.g., 1 / 2 / 3 / 4 / 5 / 6                *\n" +
                              "*  9. Split: at the edge of any two contiguous numbers,                  *\n" +
                              "*             e.g., 1 / 2,    11 / 14,   and 35 / 36                     *\n" +
                              "*  10.Corner: at the intersection of any four contiguous numbers,        *\n" +
                              "*             e.g., 1 / 2 / 4 / 5, or 23 / 24 / 26 / 27                  *\n" +
                              "*                                                                        *\n" +
                              "*                    Press Any Key To Continue                           *\n" +
                              "**************************************************************************\n");
            Console.ResetColor();
            Console.ReadKey();
            Console.Write("Would you like Place Random Bets Automatically? (Y or N):  ");
            string auto = Console.ReadLine();
            if (auto == "Y" || auto == "y")
            {
                MakeAutoBets();
            }
            else if (auto == "N" || auto == "n")
            {
                MakeManualBets();
            }
            Console.Clear();
        }
        public void GetOdds()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("*****************************************************************\n" +
                          "*                        Odds                                   *\n" +
                          "*                                                               *\n" +
                          "*       Numbers   - 35:1              Probility - 2.6%          *\n" +
                          "*       Even/Odds -  1:1              Probility - 47.3%         *\n" +
                          "*       Red/Black -  1:1              Probility - 47.3%         *\n" +
                          "*       Low/High  -  1:1              Probility - 47.3%         *\n" +
                          "*       Dozens    -  2:1              Probility - 31.6%         *\n" +
                          "*       Columns   -  2:1              Probility - 31.6%         *\n" +
                          "*       Street    - 11:1              Probility -  7.9%         *\n" +
                          "*       6 Number  -  5:1              Probility - 15.8%         *\n" +
                          "*       Split     - 17:1              Probility -  5.3%         *\n" +
                          "*       Corner    -  8:1              Probility - 10.5%         *\n" +
                          "*                                                               *\n" +
                          "*                Press Any Key To Continue                      *\n" +
                          "*****************************************************************");
            Console.ResetColor();
        }

        public void DrawGameIntroduction()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("*****************************************************************\n" +
                              "*                  Welcome To Microsoft                         *\n" +
                              "*                Software & Systems Academy                     *\n" +
                              "*                       Roulette                                *\n" +
                              "*                                                               *\n" +
                              "*      Simulates Roulette.  Player can enter each selection     *\n" +
                              "*      for each of the required bets, or can just spin with     *\n" +
                              "*      random picks.  Good Luck.                                *\n" +
                              "*                  Press Any key to Continue                    *\n" +
                              "*                                                               *\n" +
                              "*****************************************************************");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Uses the Random class to get random integers and simulate Bets
        /// </summary>
        public void MakeAutoBets()
        {
            Bin bin = new Bin();

            Random rand = new Random();

            //NUMBER AUTO
            int selection = rand.Next(0, 38);
            Bets.Add(new Number(bin.Numbers[selection]));

            //EVEN ODD AUTO
            selection = rand.Next(0, 38);
            if (selection % 2 == 0)
            {
                Bets.Add(new EvenOdd("Even"));
            }
            else
            {
                Bets.Add(new EvenOdd("Odd"));
            }


            //RED BLACK AUTO
            selection = rand.Next(0, 37);
            if (ConsoleColor.Red == bin.NumberColor[selection.ToString()])
            {
                Bets.Add(new RedBlack("Red"));
            }
            else if (ConsoleColor.Black == bin.NumberColor[selection.ToString()])
            {
                Bets.Add(new RedBlack("Black"));
            }
            else
            {
                Bets.Add(new RedBlack("Green"));
            }

            //LOW HIGH AUTO
            selection = rand.Next(0, 36);
            if (selection > 18)
            {
                Bets.Add(new LowHigh("High"));
            }
            else
            {
                Bets.Add(new LowHigh("Low"));
            }

            //DOZEN AUTO
            selection = rand.Next(1, 3);
            Bets.Add(new Dozen(selection.ToString()));

            //COLUMN AUTO
            selection = rand.Next(1, 3);
            Bets.Add(new Column(selection.ToString()));

            //STREET AUTO
            selection = rand.Next(1, 12);
            Bets.Add(new Street(selection.ToString()));

            //SIX NUMBER AUTO
            selection = rand.Next(1, 11);
            Bets.Add(new SixNumber(selection.ToString() + "," + (selection + 1).ToString()));

 

            //SPLIT AUTO
            while (true)
            {
                selection = rand.Next(1, 36);
                if (selection % 3 != 0)
                {
                    Bets.Add(new Split(selection.ToString() + "," + (selection + 1).ToString()));
                    break;
                }
            }

            //CORNER
            selection = rand.Next(0, 21);
            Bets.Add(new Corner(bin.Corner[selection]));
        }

        /// <summary>
        /// Prompts user for input and Adds to the list of Bets
        /// </summary>
        public void MakeManualBets()
        {
            //TODO: Need Validation of Input implemented

            Console.Write("Please pick a number 1-36, 0 or 00:    ");
            Bets.Add(new Number(Console.ReadLine()));

            Console.Write("Please Enter \"Even\" or \"Odd\":   ");
            Bets.Add(new EvenOdd(Console.ReadLine()));

            Console.Write("Please Enter \"Red\" or \"Black\":   ");
            Bets.Add(new RedBlack(Console.ReadLine()));

            Console.Write("Please Enter \"Low\" or \"High\":   ");
            Bets.Add(new LowHigh(Console.ReadLine()));

            Console.Write("Please Enter Dozen Number  1, 2, or 3:   ");
            Bets.Add(new Dozen(Console.ReadLine()));

            Console.Write("Please Enter Column Number  1, 2, or 3:   ");
            Bets.Add(new Column(Console.ReadLine()));

            Console.Write("Please Enter Row Number  1-12:   ");
            Bets.Add(new Street(Console.ReadLine()));

            Console.Write("Please Enter two consecutive rows i.e  1,2:   ");
            Bets.Add(new SixNumber(Console.ReadLine()));

            Console.Write("Please Enter two consecutive number i.e  11,14:   ");
            Bets.Add(new Split(Console.ReadLine()));

            Console.Write("Please Enter four numbers for a corner i.e  1/2/3/4:   ");
            Bets.Add(new Number(Console.ReadLine()));
        }

 

    }

    /// <summary>
    /// Defines the various number and bet cobminations that are available on 
    /// a table
    /// </summary>
    class Bin
    {
        public Dictionary<string, ConsoleColor> NumberColor { get; }
        public Dictionary<int, string> Corner { get; }
        public string[] Numbers { get; }

        public Bin()
        {
            //Defins What Numbers and the order they are in the bin
            Numbers = new string[] {"0 ", "28", "9 ", "26", "30", "11", "7 ", "20",
                                     "32", "17", "5 ", "22", "34", "15", "3 ", "24",
                                     "36", "31", "1 ", "00", "27", "10", "25", "29",
                                     "12", "8 ", "19", "31", "18", "6 ", "21", "33",
                                     "16", "4 ", "23", "35", "14", "2 " };

            
            //Defines the color associated with a number
            NumberColor = new Dictionary<string, ConsoleColor>();
            NumberColor.Add("0", ConsoleColor.Green);
            NumberColor.Add("00", ConsoleColor.Green);
            for (int i = 1; i <= 36; i++)
            {
                if (i > 0 && i < 11 || i > 18 && i < 29)
                {
                    if (i % 2 == 0)
                    {
                        NumberColor.Add(i.ToString(), ConsoleColor.Black);
                    }
                    else
                    {
                        NumberColor.Add(i.ToString(), ConsoleColor.Red);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        NumberColor.Add(i.ToString(), ConsoleColor.Red);
                    }
                    else
                    {
                        NumberColor.Add(i.ToString(), ConsoleColor.Black);
                    }
                }
            }

            //Defines what numbers are associated with a corner
            Corner = new Dictionary<int, string>();
            Corner.Add(0, "1/2/4/5");
            Corner.Add(1, "2/3/5/6");
            Corner.Add(2, "4/5/7/8");
            Corner.Add(3, "5/6/8/9");
            Corner.Add(4, "7/8/10/11");
            Corner.Add(5, "8/9/11/12");
            Corner.Add(6, "10/11/13/14");
            Corner.Add(7, "11/12/14/15");
            Corner.Add(8, "13/14/16/17");
            Corner.Add(9, "14/15/17/18");
            Corner.Add(10, "16/17/19/20");
            Corner.Add(11, "17/18/20/21");
            Corner.Add(12, "19/20/22/23");
            Corner.Add(13, "20/21/23/24");
            Corner.Add(14, "22/23/25/26");
            Corner.Add(15, "23/24/25/27");
            Corner.Add(16, "25/26/28/29");
            Corner.Add(17, "26/27/29/30");
            Corner.Add(18, "28/29/31/32");
            Corner.Add(19, "29/30/32/33");
            Corner.Add(20, "31/32/34/35");
            Corner.Add(21, "32/33/35/36");
        }
    }

    class Corner : Bet
    {
        public Corner(string selection) : base(selection) { Name = "Corner"; }

        public override bool IsWinner(string winningNumber)
        {
            int number = Int32.Parse(winningNumber);
            string[] corner = Selection.Split('/');
            int[] split = { Int32.Parse(corner[0].ToString()),
                            Int32.Parse(corner[1].ToString()),
                            Int32.Parse(corner[2].ToString()),
                            Int32.Parse(corner[3].ToString()) };

            for (int i = 0; i < 4; i++)
            {
                if (number == split[i])
                {
                    return true;
                }
            }
            return false;
        }
    }


    class Split : Bet
    {
        public Split(string selection) : base(selection) { Name = "Split"; }
        public override bool IsWinner(string bin)
        {

            int number = Int32.Parse(bin);
            string[] split = Selection.Split(',');
            int first = Int32.Parse(split[0]);
            int second = Int32.Parse(split[1]);

            if (number == first && number == second)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class SixNumber : Bet
    {
        public SixNumber(string selection) : base(selection) { Name = "SixNumber"; }
        public override bool IsWinner(string bin)
        {

            int number = Int32.Parse(bin);
            string[] doubleRow = Selection.Split(',');

            int[] rows = { Int32.Parse(doubleRow[0].ToString()), Int32.Parse(doubleRow[1].ToString()) };

            int High = rows[1] * 3;
            int Low = High - 5;

            if (number >= Low && number < High)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Street : Bet
    {
        public Street(string selection) : base(selection) { Name = "Street"; }
        public override bool IsWinner(string bin)
        {
            int row = (int)Math.Ceiling(Double.Parse(bin) / 3);
            if (row == Int32.Parse(Selection))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Column : Bet
    {
        public Column(string selection) : base(selection) { Name = "Column"; }
        public override bool IsWinner(string bin)
        {
            int number = Int32.Parse(bin);

            if (number % 3 == Int32.Parse(Selection))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Dozen : Bet
    {
        public Dozen(string selection) : base(selection) { Name = "Dozen"; }
        public override bool IsWinner(string bin)
        {
            int number = Int32.Parse(bin);
            if (number > 0 && number < 13 && Selection == "1")
            {
                return true;
            }
            else if (number > 12 && number < 25 && Selection == "2")
            {
                return true;
            }
            else if (number > 24 && number < 37 && Selection == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class LowHigh : Bet
    {
        public LowHigh(string selection) : base(selection) { Name = "LowHigh"; }
        public override bool IsWinner(string bin)
        {
            int number = Int32.Parse(bin);
            if (number > 0 && number < 19 && Selection == "Low")
            {
                return true;
            }
            else if (number > 18 && number < 36 && Selection == "High")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class RedBlack : Bet
    {
        private readonly Bin _Bin;
        public RedBlack(string selection) : base(selection)
        {
            _Bin = new Bin();
            Name = "RedBlack";
        }
        public override bool IsWinner(string winningNumber)
        {
            if (_Bin.NumberColor[winningNumber.Trim()] == ConsoleColor.Red && Selection == "Red")
            {
                return true;
            }
            else if (_Bin.NumberColor[winningNumber.Trim()] == ConsoleColor.Black && Selection == "Black")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class EvenOdd : Bet
    {
        public EvenOdd(string selection) : base(selection) { Name = "EvenOdd"; }
        public override bool IsWinner(string winningNumber)
        {

            int number = Int32.Parse(winningNumber);

            if (number % 2 == 0 && Selection == "Even")
            {
                return true;
            }
            else if (number % 2 != 0 && Selection == "Odd")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Number : Bet
    {
        public Number(string selection) : base(selection) { Name = "Number"; }
        public override bool IsWinner(string winningNumber)
        {
            if (winningNumber == Selection)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    abstract class Bet
    {
        public string Name { get; set; }
        public string Selection { get; }

        public Bet(string selection)
        {
            Selection = selection;
        }
        public abstract bool IsWinner(string winningNumber);


    }


}

 