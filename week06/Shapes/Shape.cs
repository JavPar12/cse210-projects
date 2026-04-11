using System;

// We use 'abstract' because we don't want anyone creating a generic "Shape" object
public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // This is an abstract method. It has no body { } here.
    // Every child class MUST provide its own implementation of this.
    public abstract double GetArea();
}