using System;

public class Square : Shape
{
    private double _side;

    // We pass the color to the base class (Shape) and save the side locally
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // We use 'override' to provide the specific formula for a square
    public override double GetArea()
    {
        return _side * _side;
    }
}