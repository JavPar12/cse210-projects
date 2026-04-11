using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a list that can hold any object that "is a" Shape
        List<Shape> shapes = new List<Shape>();

        // 2. Create the specific instances
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        // 3. Iterate through the list and display the color and area
        Console.WriteLine("Displaying Shapes Information:");
        Console.WriteLine("------------------------------");

        foreach (Shape s in shapes)
        {
            // Even though 's' is of type Shape, it calls the specific 
            // GetArea() method for each object (Polymorphism)
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"Color: {color}, Area: {area:F2}");
        }
    }
}