/*
 * Microsoft Software & Systems Academy
 * Cloud Application Developer
 * Embry Riddle
 * 
 * Author: Dakin T. Werneburg
 * 2/11/2021
 */



using System;

namespace ccsbs_ex05_werneburg
{
    /// <summary>
    /// Microsoft Software & Systems Academy
    /// Exercise to Demonstrate Arrays.
    /// </summary>
    /// <remarks>
    /// Part I: Count, sum, and compute the mean of an array
    /// Part II: Reverse an array
    /// Part III: Rotating arrays
    /// Part IV: Sorting arrays.
    ///     
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 2, 4, 6, 8, 10 };
            int[] B = { 1, 3, 5, 7, 9 };
            int[] C = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };

            Console.WriteLine("Array A: 0, 2, 4, 6, 8, 10");
            Console.WriteLine("Array B: 1, 3, 5, 7, 9");
            Console.WriteLine("Array C: 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9");


            Console.WriteLine("\n\n\nPart I: Counting, Summing, Computing The Mean");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"The average of Array A: {Average(A)}");
            Console.WriteLine($"The average of Array B: {Average(B)}");
            Console.WriteLine($"The average of Array C: {Average(C)}");

            Console.WriteLine("\n\n\nPart II: Reverse An Array");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Array A Reversed");
            printArrayReversed(A);
            Console.WriteLine("\n\nArray B Reversed");
            printArrayReversed(B);
            Console.WriteLine("\n\nArray C Reversed");
            printArrayReversed(C);

            Console.WriteLine("\n\n\nPart III: Rotating Arrays");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Array A Rotated 2 to The Left");
            printRotatedArray(Direction.Left, 2, A);
            Console.WriteLine("\nArray B Rotated 2 to The Right");
            printRotatedArray(Direction.Right, 2, B);
            Console.WriteLine("\nArray C Rotated 4 to The Left");
            printRotatedArray(Direction.Left, 4, C);

            Console.WriteLine("\n\n\nPart IV: Sorting Arrays");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Array C Sorted");
            printSortedArray(C);
            Console.ReadKey();
        }
        
        //Part I
        static double Average(int[] array)
        {
            int sum = 0;
            int count = 0;
            foreach (int n in array)
            {
                sum += n;
                count++;
            }
            return sum / (count * 1.0);
        }

        //Part II
        static void printArrayReversed(int [] array)
        {
            for(int i = array.Length-1; i > 0; i--)
            {
                Console.Write($"{array[i]} ");
            }
        }

        //Part III
        static void printRotatedArray(Direction direction, int places, int[] array )
        {

            if(places > array.Length || places < 0)
            {
                throw new ArgumentOutOfRangeException("The number of places is out of range");
            }
            
            else if (direction == Direction.Right)
            {

                
                
                for (int i = array.Length - places; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }
                for (int i = 0; i < array.Length - places; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }
            else
            {
               
                for (int i = places; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }
                for (int i = 0; i < places; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }
            Console.WriteLine(); 
        }

        //Part IV
        static void printSortedArray(int [] array)
        {
             
            for(int i = 0; i < array.Length; i++)
            {
                int index = i;
                for(int j = i+1; j < array.Length; j++)
                {
                    if(array[j] < array[index])
                    {
                        index = j;
                    }
                }

                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
                Console.Write($"{array[i]} ");

            }
            Console.WriteLine();
        }
        

       
    }

    enum Direction
    {
        Left,
        Right
    }
}
