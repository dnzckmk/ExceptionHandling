// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("To close the app type 'exit'.");
            string input;
            do
            {
                Console.WriteLine("Enter text:");
                input = Console.ReadLine();
                if (input == "exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    PrintTheFirstCharacter(input);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            while (string.IsNullOrWhiteSpace(input) || input != "exit");

            static void PrintTheFirstCharacter(string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException($"{nameof(text)} can't be empty.");
                }

                Console.WriteLine(text.First());
            }
        }
    }
}