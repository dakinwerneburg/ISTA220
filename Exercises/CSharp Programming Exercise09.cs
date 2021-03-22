/*
  Microsoft Software and Systems Academy
  C# Excersice 09
  Author: Dakin T. Werneburg
  Date: 3/21/201
  
  Purpose:  This class is demonstrate Collections and Hashing 
  by simulating a user authentication system.
*/



using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace cssbs_ex09_werneburg
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int userResponse = Util.printUI();
                    if (userResponse == 1)
                    {
                        Util.getNewUser();
                    }
                    else if (userResponse == 2)
                    {
                        Util.getUser();
                    }
                    else if (userResponse == 3)
                    {
                        Util.printUsers();
                    }
                    else if (userResponse == 4)
                    {
                        Environment.Exit(0);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\nSorry, I didn't understand what you wanted to do.  Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
    }

    /// <summary>
    /// This class provides utilities to display a user interface 
    /// to create and store username and passwords using hashing, 
    /// verify user credentials after created, and print all users i
    /// in the database.  In this example the database is a just a 
    /// Dictonary.
    /// </summary>
    public static class Util
    {
        public static Dictionary<string, string> Users = new Dictionary<string, string>();

        public static int printUI()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------\n");
            Console.WriteLine("                 PASSWORD AUTHENTICATION SYSTEM             \n");
            Console.WriteLine("                 Please select one option:                  \n");
            Console.WriteLine("                 1. Establish an account                    ");
            Console.WriteLine("                 2. Authenticate a user                     ");
            Console.WriteLine("                 3. Print Users                            \n");
            Console.WriteLine("                 4. Exit                                   \n");
            Console.WriteLine("------------------------------------------------------------");

            Console.Write("Enter selection: ");
            if (Int32.TryParse(Console.ReadLine(), out int response) && response > 0 && response < 5)
            {
                Console.WriteLine();
                return response;
            }

            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// TODO:  Add stricter rules for username and passwords
        /// TODO:  Hide Password as user inputs
        /// TODO:  Add and store a salt, that identifies user, to the hash function
        /// </summary>
        public static void getNewUser()
        {
            while (true)
            {
                Console.Write("Please enter Username: ");
                string username = Console.ReadLine();
                if (Users.ContainsKey(username))
                {
                    Console.WriteLine($"\tINFO: {username} That has already been taken.  Press any key to continue.");
                    continue;
                }
                Console.Write("Please enter Password: ");
                string password = Console.ReadLine();
                string passwordHash = ComputeSha256Hash(password);
                Users.Add(username, passwordHash);
                Console.WriteLine($"\nUser was successfully added.");
                Console.WriteLine($"\tUsername: {username,-25} Password Entered: {password,-25} PasswordHash: {passwordHash}");
                Console.WriteLine($"Press any key to continue");
                break;
            }
            Console.ReadKey();
        }

        public static void getUser()
        {
            Console.Write("Please enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter Password:");
            string password = Console.ReadLine();
            Console.WriteLine();

            string passwordHash = ComputeSha256Hash(password);
            if (Users.ContainsKey(username))
            {
                if (Users[username] == passwordHash)
                {
                    Console.WriteLine("\tINFO: You have been authenticated.  Press any key to continue.");
                }
                else
                {
                    Console.WriteLine("\tINFO: No match could be found.  Press any key to continue.");
                }
            }
            else
            {
                Console.WriteLine($"\tINFO: User does not exist.  Press any key to continue.");
            }
            Console.ReadKey();

        }

        public static void printUsers()
        {
            if (Users.Count < 1)
            {
                Console.WriteLine("\tINFO: No Users are in the database.  Press Any Key To Continue");
            }
            else
            {
                foreach (KeyValuePair<string, string> user in Users)
                {
                    Console.WriteLine($"Username: {user.Key,-25} Hashed Password: {user.Value,-25}");
                }
                Console.WriteLine("\nPress Any Key to Continue");
            }
            Console.ReadKey();

        }
        /// <summary>
        /// SHA 256 Hash function provided by: 
        /// https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        /// retireved 3/21/2021
        /// </summary>
        /// <param name="rawData">password to be hashed</param>
        /// <returns>hashed password</returns>
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
