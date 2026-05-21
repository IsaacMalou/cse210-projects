using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        // Words are visible by default when created
        _isHidden = false;
    }

    public void Hide()
    {
        // TODO: Set _isHidden to true
    }

    public void Show()
    {
        // TODO: Set _isHidden to false
    }

    public bool IsHidden()
    {
        // TODO: Return the _isHidden value
        return false;
    }

    public string GetDisplayText()
    {
        // TODO: If _isHidden is true, return underscores matching the length of _text.
        // Otherwise, return the actual _text.
        return "";
    }
}