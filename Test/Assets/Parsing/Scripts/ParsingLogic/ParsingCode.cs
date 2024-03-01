using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ParsingCode
{
    [SerializeField] private string _code;
    [SerializeField] private int _prioroty;
    private List<ParsingWord> _words;

    public int Priority => _prioroty;
    public string Code => _code;
    
    public string GetPattern()
    {
        GetWords();
        string pattern = "";
        foreach (var word in _words)
        {
            pattern += " " + word.Pattern;
        }

        return pattern;
    }
    private void GetWords()
    {
        if (string.IsNullOrEmpty(_code) == false)
        {
            _words = new List<ParsingWord>();
            string[] codeParts = _code.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in codeParts)
            {
                if (part.StartsWith("&"))
                {
                    var word = new ParsingWord(part.Trim('&'));
                    _words.Add(word);
                }
            }
        }
    }
    
}