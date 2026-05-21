using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // TODO: Split the 'text' string by spaces and create a new Word object for each piece,
        // then add it to the _words list.
    }

    public void HideRandomWords(int numberToHide)
    {
        // TODO: Randomly select words from the _words list and call their Hide() method.
    }

    public string GetDisplayText()
    {
        // TODO: Combine the reference display text and all the word display texts into one string.
        return "";
    }

    public bool IsCompletelyHidden()
    {
        // TODO: Check if every word in the _words list is hidden.
        return false;
    }
}