using System.Linq;
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
            ParseSentence(sentenceToParse);
        }
    }
    
    public void ParseSentence(string sentence)
    {
        ParsingCodeChecker checker = new ParsingCodeChecker(_sentenceParsing.parsingCodes.ToList());

        string[] sentences = {
            "I like bananas, but I prefer strawberries!",
            "I like bananas and apples.",
            "I don't like bananas, but I prefer strawberries!"
        };
       string result = checker.CheckSentence(sentence);
        Debug.Log($"Sentence: \"{sentence}\" - Parsing code: \"{result}\"");
    }
}