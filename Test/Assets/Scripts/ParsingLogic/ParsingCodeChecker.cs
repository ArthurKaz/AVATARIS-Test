using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public class ParsingCodeChecker
{
    [SerializeField] private List<ParsingCode> _parsingCodes;
    
    public string GetMatchedParseCodeWithPriority(string sentence)
    {
        string matched = "None";
        int highestPriority = int.MaxValue;

        foreach (var parsingCode in GetOrderedByPriority())
        {
            if (IsMatchingParsingCode(sentence, parsingCode))
            {
                matched = parsingCode.Code;
                break;
            }
        }

        return matched;
    }

    public void OrderByPriority() => _parsingCodes = GetOrderedByPriority();

    private List<ParsingCode> GetOrderedByPriority() => _parsingCodes.OrderBy(code => code.Priority).ToList();

    private bool IsMatchingParsingCode(string sentence, ParsingCode parsingCode)
    {
        string pattern = parsingCode.GetPattern();
        return Regex.IsMatch(sentence, pattern, RegexOptions.IgnoreCase);
    }
}