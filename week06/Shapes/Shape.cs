public class Shape
{
    private string _color;

    // Constructor that accepts the color
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Setter for color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method so derived classes can override it
    public virtual double GetArea()
    {
        return 0;
    }
}