using System;
using ParsingLogic;
using UnityEngine;

[Serializable]
public class ParsingWord
{
    [SerializeField] private string _word;
    [SerializeField] private string[] _ends;
    
    private IPatterCreator _patterCreator = new PatternCreator();
    public string Word => _word;
    public string[] Ends => _ends;
    public string Pattern => _patterCreator.GetPattern(this);

    public ParsingWord(string word)
    {
        _word = GetWord(word);
        _ends = GetEnds(word);
    }
    public ParsingWord(string word, IPatterCreator patterCreator)
    {
        _word = GetWord(word);
        _ends = GetEnds(word);
        _patterCreator = patterCreator;
    }

    private string GetWord(string word)
    {
        int startIndex = 0;
        int endIndex = word.Contains("]") ? word.IndexOf("[") : word.Length;
        return word.Substring(startIndex, endIndex);
    }

    private string[] GetEnds(string word)
    {
        if (!string.IsNullOrEmpty(word))
        {
            foreach (string part in word.Split('&'))
            {
                if (part.Contains("[") && part.Contains("]"))
                {
                    int startIndex = part.IndexOf("[", StringComparison.Ordinal);
                    int endIndex = part.IndexOf("]", StringComparison.Ordinal);
                    string suffix = part.Substring(startIndex + 1, endIndex - startIndex - 1);
                    return suffix.Split('/');
                }
            }
        }

        return null;

    }
}
