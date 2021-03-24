/*
  Microsoft Software and Systems Academy
  C# Excersice 10
  Author: Dakin T. Werneburg
  Date: 3/24/201
  
  Purpose:  To mentally think of the algorithm
            invloved in converting from the basic 
            computer number systems
            base 2, 8, 10, 16.
*/


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace cssbs_ex10_werneburg
{
    class Program
    {
        static string[] hexValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        static void Main(string[] args)
        {

            while (true)
            {

                string number;
                int numberBase;
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("\n             Number Base Conversion Toool                   " +
                                  "\n\n--------------------------------------------------------------");

                while (true)
                {
                    Console.Write("Enter Number's Base [2,8,10,16]: ");
                    String input = Console.ReadLine();
                    if (int.TryParse(input, out numberBase))
                    {
                        if (numberBase == 2 || numberBase == 8 || numberBase == 10 || numberBase == 16)
                        {
                            Dictionary<string, string> results = new Dictionary<string, string>();

                            while (true)
                            {
                                Console.Write("Enter Number: ");
                                number = Console.ReadLine().ToUpper();

                                if (numberBase == 2 && Regex.IsMatch(number, "[01]+"))
                                {
                                    results.Add("Octal", BinaryToOctal(number));
                                    results.Add("Decimal", BinaryToDecimal(number).ToString());
                                    results.Add("HexaDecimal", BinaryToHexaDecimal(number));
                                    break;
                                }
                                else if (numberBase == 8 && Regex.IsMatch(number, "^[0-7]+$"))
                                {
                                    results.Add("Binary", OctalToBinary(number));
                                    results.Add("Decimal", OctalToDecimal(number).ToString());
                                    results.Add("HexaDecimal", OctalToHexaDecimal(number).ToString());
                                    break;
                                }
                                else if (numberBase == 10 && Regex.IsMatch(number, "^[0-9]+$"))
                                {
                                    results.Add("Binary", DecimalToBinary(int.Parse(number)));
                                    results.Add("Octal", DecimalToOctal(int.Parse(number)));
                                    results.Add("HexaDecimal", DecimalToHexaDecimal(int.Parse(number)));
                                    break;
                                }
                                else if (numberBase == 16 && Regex.IsMatch(number, "-?[0-9a-fA-F]+"))
                                {
                                    results.Add("Binary", HexaDecimalToBinary(number));
                                    results.Add("Octal", HexaDecimalToOctal(number));
                                    results.Add("Decimal", HexaDecimalToDecimal(number).ToString());
                                    break;
                                }
                                else
                                {
                                    ClearInput(input);
                                }
                            }
                            Console.WriteLine();
                            foreach (KeyValuePair<string, string> conversion in results)
                            {
                                Console.WriteLine($"\t{conversion.Key}: {conversion.Value}\n");
                            }
                            break;
                        }
                        else
                            ClearInput(input);
                    }
                    else
                        ClearInput(input);
                }

                while (true)
                {
                    Console.Write("Would you like to continue? ( Y or N ): ");
                    String input = Console.ReadLine();
                    if (input.ToUpper() == "N")
                        Environment.Exit(0);
                    else if (input.ToUpper() == "Y")
                        break;
                    else
                        ClearInput(input);
                }
            }
        }



        /// <summary>
        /// Conversion is based on following formula
        /// ( ax^n)+...(ax^2)+(ax^1)+(ax^0)
        /// a=constant x=base  n=exponent
        /// i.e 
        /// (1*2^n)+...(1*2^2)+(1*2^1)+(1*2^0)
        /// </summary>
        /// <param name="number">number to be converted</param>
        /// <returns>integer in base 10</returns>
        private static int BinaryToDecimal(string number)
        {
            int decimalNumber = 0;
            int exponent = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                int constant = int.Parse(number[i].ToString());   // looks up decimal representation of octalvalue
                int term = (int)(Math.Pow(2, exponent--));
                decimalNumber += constant * term;
            }
            return decimalNumber;
        }

        private static string BinaryToOctal(string number)
        {
            int toDecimal = BinaryToDecimal(number);
            return DecimalToOctal(toDecimal);
        }

        private static string BinaryToHexaDecimal(string number)
        {
            int toDecimal = BinaryToDecimal(number);
            return DecimalToHexaDecimal(toDecimal);
        }


        // Same algorithm but with base of 8
        private static int OctalToDecimal(string number)
        {
            int decimalNumber = 0;
            int exponent = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                int constant = int.Parse(number[i].ToString());   // looks up decimal representation of octalvalue
                int term = (int)(Math.Pow(8, exponent--));
                decimalNumber += constant * term;
            }
            return decimalNumber;
        }

        private static string OctalToBinary(string number)
        {
            int toDecimal = OctalToDecimal(number);
            return DecimalToBinary(toDecimal);
        }

        private static string OctalToHexaDecimal(string number)
        {
            int toDecimal = OctalToDecimal(number);
            return DecimalToHexaDecimal(toDecimal);
        }


        private static string DecimalToBinary(int number)
        {
            Stack<int> digits = new Stack<int>();
            string binary = "0b";
            while (number > 0)
            {
                digits.Push(number % 2);
                number /= 2;
            }
            while (digits.Count > 0)
            {
                binary += digits.Pop().ToString();
            }
            return binary;
        }

        private static string DecimalToOctal(int number)
        {
            Stack<int> digits = new Stack<int>();
            string octal = "0o";
            while (number > 0)
            {
                digits.Push(number % 8);
                number /= 8;
            }
            while (digits.Count > 0)
            {
                octal += digits.Pop().ToString();
            }
            return octal;
        }

        private static string DecimalToHexaDecimal(int number)
        {
            Stack<string> digits = new Stack<string>();
            string hexDecimal = "0x";
            while (number > 0)
            {
                digits.Push(hexValues[number%16]);
                number /= 16;
            }
            while (digits.Count > 0)
            {
                hexDecimal += digits.Pop().ToString();
            }
            return hexDecimal;
        }

        /// <summary>
        /// ( ax^n)+...(ax^2)+(ax^1)+(ax^0)
        /// a=constant x=base  n=exponent
        /// constant is the index value of looking up the hexvalue
        /// </summary>
        /// <param name="number">number to be converted</param>
        /// <returns>integer in base 10</returns>
        private static int HexaDecimalToDecimal(string number)
        {
            int decimalNumber = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int a = Array.IndexOf(hexValues, number[i].ToString());   // looks up decimal representation of hexvalue
                int b = (int)(Math.Pow(16, i));
                decimalNumber += (a) * (b);
            }
            return decimalNumber;
        }

        private static string HexaDecimalToOctal(string number)
        {
            int toDecimal = HexaDecimalToDecimal(number);
            return DecimalToOctal(toDecimal);
        }

        private static string HexaDecimalToBinary(string number)
        {
            int toDecimal = HexaDecimalToDecimal(number);
            return DecimalToBinary(toDecimal);
        }


        public static void ClearInput(string input)
        {
            int y = Console.CursorTop - 1;
            int x = Console.CursorLeft;
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(x, y);
        }
    }
}
