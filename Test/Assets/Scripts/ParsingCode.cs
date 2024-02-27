using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public class ParsingCode
{
    [SerializeField] private string _code;
    [SerializeField] private int _prioroty;
    private List<ParsingWord> _words;

    public int Priority => _prioroty;

    public void GetWords()
    {
        if (!string.IsNullOrEmpty(_code))
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

    public string GetPattern()
    {
        string pattern = "";
        foreach (var word in _words)
        {
            pattern += " " + word.GetPattern();
        }

        return pattern;
    }

    [Serializable]
    private class ParsingWord
    {
        [SerializeField] private string _value;
        [SerializeField] private string[] _ends;
        [SerializeField] private string _pattern;

        public ParsingWord(string word)
        {
            _value = GetWord(word);
            _ends = GetEnds(word);
            _pattern = GetPattern();
        }

        public string GetWord(string word)
        {

            int startIndex = 0;
            int endIndex = word.Contains("]") ? word.IndexOf("["): word.Length;
            return word.Substring(startIndex, endIndex);
        }

        public string[] GetEnds(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                foreach (string part in word.Split('&'))
                {
                    if (part.Contains("[") && part.Contains("]"))
                    {
                        int startIndex = part.IndexOf("[");
                        int endIndex = part.IndexOf("]");
                        string suffix = part.Substring(startIndex + 1, endIndex - startIndex - 1);
                        return suffix.Split('/');
                    }
                }
            }

            return null;

        }
        public string GetPattern()
        {
            // Initialize the pattern with the word
            string pattern = @"\b" + Regex.Escape(_value);

            // Append each possible ending to the pattern
            pattern += EndPattern();

            // Ensure word ends with a word boundary
            pattern += @"\b";

            return pattern;
        }

        private string EndPattern()
        {
            string endPattern = "";
            if (_ends != null)
            {
                if (_ends.Length == 1)
                {
                    return _ends[0] + '?';
                }

                endPattern += '(';
                for (var index = 0; index < _ends.Length; index++)
                {
                    var end = _ends[index];
                    endPattern += end;
                    if (index < _ends.Length - 1)
                    {
                        endPattern += '|';
                    }
                }
                endPattern += ')';
            }

            return endPattern;
        }
    }
}