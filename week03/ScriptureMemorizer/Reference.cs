public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Constructor for a range of verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        // If the start and end verse are the same, format as "John 3:16"
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        // Otherwise, format as "Proverbs 3:5-6"
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}