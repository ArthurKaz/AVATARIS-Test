using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(SentenceParsing))]
public class SentenceParserEditor : Editor
{
    private string sentenceToParse;
    private SentenceParsing _sentenceParsing;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _sentenceParsing = (SentenceParsing)target;
        GUILayout.Space(10);

        GUILayout.Label("Enter Sentence to Parse:");
        sentenceToParse = EditorGUILayout.TextField(sentenceToParse);

        GUILayout.Space(10);

        if (GUILayout.Button("Parse Sentence"))
        {
            ParseSentence();
        }
    }

// Method to parse the sentence
    public void ParseSentence()
    {
        bool isSentenceValid = false;

        foreach (string code in _sentenceParsing.parsingCodes)
        {
            if (IsSentenceValidForParsingCode(sentenceToParse, code))
            {
                Debug.Log("The sentence matches parsing code: " + code);
                isSentenceValid = true;
            }
        }

        if (!isSentenceValid)
        {
            Debug.Log("The sentence does not match any parsing code.");
        }
    }

    // Method to check if the sentence matches the parsing code
    private bool IsSentenceValidForParsingCode(string sentence, string parsingCode)
    {
        string[] codeWords = parsingCode.Split(' ');

        foreach (string word in codeWords)
        {
            string modifiedWord = word.Trim('&');

            if (sentence.ToLower().Contains(modifiedWord.ToLower()) == false)
            {
                if (word.Contains("[s]") == false)
                {
                    return false;
                }

                string singularForm = modifiedWord.Remove(modifiedWord.Length - 3);
                if (sentence.ToLower().Contains(singularForm.ToLower()) == false)
                {
                    return false;
                }
            }
        }

        return true;

    }
}