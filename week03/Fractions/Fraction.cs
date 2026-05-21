using System;

public class Fraction
{
    // Private attributes for the top (numerator) and bottom (denominator)
    private int _top;
    private int _bottom;

    // 1. Constructor: No parameters, initializes to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Constructor: One parameter, initializes denominator to 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Constructor: Two parameters, initializes top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        // Cast the integers to doubles before dividing to ensure floating-point math
        return (double)_top / (double)_bottom;
    }
}