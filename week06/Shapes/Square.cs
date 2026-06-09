public class Square : Shape
{
    private double _side;

    // Constructor passes the color to the base Shape class
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Overriding the behavior to calculate the area of a square
    public override double GetArea()
    {
        return _side * _side;
    }
}