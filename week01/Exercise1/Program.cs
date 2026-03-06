using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your Name? ");
        string firstname = Console.ReadLine();

        Console.Write("What is your Last name? ");
        string lastname = Console.ReadLine();

        Console.WriteLine($"Your Name is {lastname}, {firstname} {lastname}.");
    }
}