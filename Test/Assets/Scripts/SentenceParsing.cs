using System.Linq;
using UnityEngine;

public class SentenceParsing : MonoBehaviour
{
    [SerializeField] public ParsingCode[] parsingCodes;

    private void OnValidate()
    {
        parsingCodes = parsingCodes.OrderByDescending(code => code.Priority).ToArray();
        foreach (var parsingCode in parsingCodes)
        {
            parsingCode.GetWords();
        }
    }
}
