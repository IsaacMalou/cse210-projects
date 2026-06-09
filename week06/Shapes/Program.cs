using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Build the list
        List<Shape> shapes = new List<Shape>();

        // 2. Create the shapes and add them to the list
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        // 3. Iterate through the list and display the color and area
        foreach (Shape s in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = s.GetColor();

            // Notice that all shapes have a GetArea method, but the behavior is different for each type of shape
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}