using System;
using System.Security.Cryptography;
using System.Text;



using System.Threading.Tasks;

namespace ccsbs_ex15_werneburg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter password: ");
            string password = Console.ReadLine();

                      MultiThread(password);
            SingleThread(password);
        }


        /// <summary>
        /// Brute force password cracker using a single thread.  It iterates
        /// through every possible permutation and checks to see if it 
        /// matches provided password.
        /// </summary>
        /// <param name="password"></param>
        static void MultiThread(string password)
        {
            //Easier to use array - zero base indexing
            char[] chars = new char[95];
            long index = 0;
            for (int i = 32; i < 127; i++)
            {
                chars[index++] = (char)i;
            }


            //P=n^r   where P=permutations, n=number of characters, r=length of password
            long permutations = (long)Math.Pow(chars.Length, password.Length);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            string crackedPassword = "";
            Parallel.For(0, permutations, (i, search) =>
            {
                //This builds the permutated word
                string permutatedWord = "";
                for (int j = 0; j < password.Length; j++)
                {
                    permutatedWord = chars[i % chars.Length] + permutatedWord; //assigns a character from chars array to the permutated word so far
                    i = i / chars.Length; // sets the character position of the permutated word
                    
                }
                if (password == permutatedWord)
                {
                    crackedPassword = permutatedWord;
                    search.Stop();     
                }
            });
            Console.WriteLine($"{crackedPassword} was found in {stopwatch.ElapsedMilliseconds} ms using multiple threads");
        }

        /// <summary>
        /// Brute force password cracker using a single thread.  It iterates
        /// through every possible permutation and checks to see if it 
        /// matches provided password.
        /// </summary>
        /// <param name="password"></param>
        static void SingleThread(string password)
        {
            //Easier to use array - zero base indexing
            char[] chars = new char[95];
            long index = 0;
            for (int i = 32; i < 127; i++)
            {
                chars[index++] = (char)i;
            }

            //P=n^r   where P=permutations, n=number of characters, r=length of password
            long permutations = (long)Math.Pow(chars.Length, password.Length);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            string crackedPassword = "";
            for (long i = 0; i < permutations; i++)
            {
                //This builds the permutated word
                string permutatedWord = "";
                index = i;
                for (int j = 0; j < password.Length; j++)
                {
                    permutatedWord = chars[index % chars.Length] + permutatedWord; //assigns a character from chars array to the permutated word so far
                    index = index / chars.Length; //sets the character position of the permutated word
                    Console.Write($"({index} - {permutatedWord})");
                    Console.ReadKey();
                }
                Console.WriteLine();
                //if (password == permutatedWord)
                //{
                //    crackedPassword = permutatedWord;
                //    break;
                //}
            }
            Console.WriteLine($"{crackedPassword} was found in {stopwatch.ElapsedMilliseconds} ms using single a thread");
        }
    }
}
