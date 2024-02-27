using System;
using UnityEngine;

public class SentenceParsing : MonoBehaviour, IParser
{
/*
 &like &banana[s]
 &prefer &strawberr[y/ies]

"I like bananas, but I prefer strawberries!",
"I like bananas and apples.",
"I don't like bananas, but I prefer strawberries!"
*/
    [SerializeField] public ParsingCodeChecker _parsingCodeChecker;

    public string ParseSentence(string sentence)
    {
        string result = _parsingCodeChecker.GetMatchedParseCodeWithPriority(sentence);
        
        return result;
    }

    private void OnValidate()
    {
        _parsingCodeChecker.OrderByPriority();
    }
}