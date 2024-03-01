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
            var sentence = sentenceToParse;
            var result = _sentenceParsing.ParseSentence(sentence);
            Debug.Log($"Sentence: \"{sentence}\" - Parsing code: \"{result}\"");
        }
    }
}