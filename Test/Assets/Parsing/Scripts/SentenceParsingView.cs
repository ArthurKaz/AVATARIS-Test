using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IParser))]
public class SentenceParsingView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _resultText;
    private IParser _parser;

    private void Start()
    {
        _parser = GetComponent<IParser>();
        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        var sentence = _inputField.text;
        var result = _parser.ParseSentence(sentence);
        _resultText.text = $"Sentence: \"{sentence}\" - Parsing code: \"{result}\"";
    }

    private void OnValidate()
    {
        if (_inputField == null)
        {
            _inputField = GetComponentInChildren<TMP_InputField>();
        }
    }
}