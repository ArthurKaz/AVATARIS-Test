using UnityEngine;

public class SentenceParsing : MonoBehaviour, IParser
{
/*
&like &banana[s]
&prefer &strawberr[y/ies]
&enjoy[s] &apple[s/]
&eat[s] &orange[s/]

I like bananas, but I prefer strawberries!,
She enjoys apples and eats oranges.
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