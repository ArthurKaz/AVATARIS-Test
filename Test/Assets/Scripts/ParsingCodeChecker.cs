using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ParsingCodeChecker
{
    private readonly List<ParsingCode> _parsingCodes;

    public ParsingCodeChecker(List<ParsingCode> parsingCodes)
    {
        _parsingCodes = parsingCodes;
    }

    public string CheckSentence(string sentence)
    {
        string highestPriorityMatch = "nothing";
        int highestPriority = int.MaxValue;

        foreach (var parsingCode in _parsingCodes)
        {
            if (IsMatchingParsingCode(sentence, parsingCode))
            {
                highestPriorityMatch = parsingCode.GetPattern();
                break;
            }
        }

        return highestPriorityMatch;
    }

    private bool IsMatchingParsingCode(string sentence, ParsingCode parsingCode)
    {
        string pattern = parsingCode.GetPattern();//parsingCode.Replace("&", @"\b").Replace("[s]", "s?").Replace("[y/ies]", "(y|ies)?");
        Debug.Log(pattern);
        return Regex.IsMatch(sentence, pattern, RegexOptions.IgnoreCase);
    }
    private static string GetPattern(string parsingCode)
    {
        return parsingCode.Replace("&", @"\b").Replace("[s]", "s?").Replace("[y/ies]", "(y|ies)?");
    }
}