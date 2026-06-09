using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Overriding the behavior to calculate the area of a circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}