using System;

class Program
{
    static void Main(string[] args)
    {
        // Program.cs
// Prove 1: Base
Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
Console.WriteLine(a1.GetSummary());

// Prove 2: Math
MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
Console.WriteLine(a2.GetSummary());
Console.WriteLine(a2.GetHomeworkList());

// Prove 3: Writing
WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
Console.WriteLine(a3.GetSummary());
Console.WriteLine(a3.GetWritingInformation());
    }
}