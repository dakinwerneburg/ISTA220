using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cssbs_ex14_werneburg
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainText = Util.GetPlainText();
            string singleKey = Util.GetSingleKey();
            string multiKey = Util.GeMultiKey();
            Console.WriteLine();

            Console.WriteLine($"You entered [{plainText}] as plain text");
            Console.WriteLine($"You entered [{singleKey}] as your single key");
            Console.WriteLine($"You entered [{multiKey}] as your multi key");
            Console.WriteLine();

            int[] cleanText = Util.Clean(plainText);
            int[] cleanSingleKey = Util.Clean(singleKey);
            int[] cleanMultiKey = Util.Clean(multiKey);

            string encryptSingle = Util.SingleEncrypt(cleanText, cleanSingleKey);
            string encryptMulti = Util.MultiEncrypt(cleanText, cleanMultiKey);
            string encryptContinuous = Util.ContinuousEncrypt(cleanText, cleanMultiKey);

            Console.WriteLine($"Encrypted message with single key is [{encryptSingle}]");
            Console.WriteLine($"Encrypted message with multi-key is [{encryptMulti}]");
            Console.WriteLine($"Encryped message with continuoius key is [{encryptContinuous}]");
            Console.WriteLine();

            string decryptSingle = Util.SingleDecrypt(encryptSingle, cleanSingleKey);
            string decryptMulti = Util.MultiDecrypt(encryptMulti, cleanMultiKey);
            string decryptContinuous = Util.ContinuousDecrypt(encryptContinuous, cleanMultiKey);

            Console.WriteLine($"Decrypted message with single key is [{decryptSingle}]");
            Console.WriteLine($"Decrypted message with multi-key is [{decryptMulti}]");
            Console.WriteLine($"Decryped message with continuoius key is [{decryptContinuous}]");
            Console.WriteLine();

        }
    }

    static class Util
    {
        private readonly static Dictionary<int, char> Cipher = new Dictionary<int, char>();

        static Util()
        {
            char start = 'A';
            for (int i = 1; i < 27; i++)
            {
                Cipher.Add(i, start++);
            }
        }

        public static string GetPlainText()
        {

            Console.Write("Enter plain text: ");
            return Console.ReadLine();
        }

        public static string GetSingleKey()
        {
            string key;
            Console.Write("Enter your single key as an alpha charachter: ");
            while (true)
            {

                int xPos = Console.CursorLeft;
                key = Console.ReadLine();
                if (Regex.IsMatch(key, @"^[a-zA-Z]{1}$"))
                {
                    return key;
                }
                else
                {
                    Console.WriteLine("Invalid Key!  Press Any Key to Continue");
                    Console.ReadKey();
                    ClearInput(xPos);
                }
            }


        }

        public static string GeMultiKey()
        {
            string key;
            Console.Write("Enter your multi key as alpha charachters: ");
            while (true)
            {

                int xPos = Console.CursorLeft;
                key = Console.ReadLine();

                if (Regex.IsMatch(key, @"^[a-zA-Z]+$"))
                {

                    return key;
                }
                else
                {
                    Console.WriteLine("Invalid Key!  Press Any Key to Continue");
                    Console.ReadKey();
                    ClearInput(xPos);
                }
            }

        }

        public static int[] Clean(string plainText)
        {
            List<int> values = new List<int>();
            for (int i = 0; i < plainText.Length; i++)
            {
                int decVal = (int)plainText[i];
                if (decVal > 96 && decVal < 123)
                {
                    decVal -= 32;
                }
                if (decVal > 64 && decVal < 91)
                {
                    values.Add(decVal);
                }
            }
            return values.ToArray();
        }

        public static string SingleEncrypt(int[] cleanText, int[] cleanSingleKey)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int n in cleanText)
            {
                int key = cleanSingleKey[0] - 64;
                int encode = key + n;
                if (encode > 90) encode -= 26;
                stringBuilder.Append(Convert.ToChar(encode));
            }
            return stringBuilder.ToString();
        }

        public static string MultiEncrypt(int[] cleanText, int[] cleanMultiKey)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int keyPos = 0;
            foreach (int n in cleanText)
            {
                keyPos %= cleanMultiKey.Length;
                int key = cleanMultiKey[keyPos++] - 64;
                int encode = key + n;
                if (encode > 90) encode -= 26;
                stringBuilder.Append(Convert.ToChar(encode));

            }
            return stringBuilder.ToString();
        }

        public static string ContinuousEncrypt(int[] cleanText, int[] cleanMultiKey)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int keyPos = 0;
            int plainPos = 0;
            for (int i = 0; i < cleanText.Length; i++)
            {
                if (keyPos < cleanMultiKey.Length)
                {
                    keyPos %= cleanMultiKey.Length;
                    int key = cleanMultiKey[keyPos++] - 64;
                    int encode = key + cleanText[i];
                    if (encode > 90) encode -= 26;
                    stringBuilder.Append(Convert.ToChar(encode));
                }
                else
                {
                    int key = cleanText[plainPos++] - 64;
                    int encode = key + cleanText[i];
                    if (encode > 90) encode -= 26;
                    stringBuilder.Append(Convert.ToChar(encode));
                }
            }
            return stringBuilder.ToString();
        }

        public static string SingleDecrypt(string encryptSingle, int[] cleanSingleKey)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in encryptSingle)
            {
                int key = cleanSingleKey[0] - 64;
                int decode = c - key;
                if (decode < 65) decode += 26;
                stringBuilder.Append(Convert.ToChar(decode));

            }
            return stringBuilder.ToString();
        }

        internal static string MultiDecrypt(string encryptMulti, int[] cleanMultiKey)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int keyPos = 0;
            foreach (char c in encryptMulti)
            {
                keyPos %= cleanMultiKey.Length;
                int key = cleanMultiKey[keyPos++] - 64;
                int decode = c - key;
                if (decode < 65) decode += 26;
                stringBuilder.Append(Convert.ToChar(decode));

            }
            return stringBuilder.ToString();
        }

        internal static string ContinuousDecrypt(string encryptContinuous, int[] cleanMultiKey)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int keyPos = 0;
            
            for (int i = 0; i < encryptContinuous.Length; i++)
            {
                if (keyPos < cleanMultiKey.Length)
                {
                    keyPos %= cleanMultiKey.Length;
                    int key = cleanMultiKey[keyPos++] - 64;
                    int decode = encryptContinuous[i] - key;
                    if (decode < 65) decode += 26;
                    stringBuilder.Append(Convert.ToChar(decode));
                }
                else
                {
                    int key = stringBuilder[i-3] - 64;
                    int decode = encryptContinuous[i] - key;
                    if (decode < 65) decode += 26;
                    stringBuilder.Append(Convert.ToChar(decode));
                }
            }
            return stringBuilder.ToString();
        }
        //simple clears invalid respose
        public static void ClearInput(int cursorPos)
        {
            //Removes "Invalid Key!  Press Any Key to Continue"
            int y = Console.CursorTop - 1;
            Console.SetCursorPosition(0, y);
            Console.Write(new string(' ', Console.BufferWidth));

            //removes user input
            Console.SetCursorPosition(cursorPos, y - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(cursorPos, y - 1);
        }

    }
}
