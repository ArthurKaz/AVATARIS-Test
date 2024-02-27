This set of scripts implements the functionality of parsing sentences based on specific templates and displaying the results in the Unity interface. Here's a brief description of each:

IParser (Interface):

Defines the ParseSentence method, which takes a sentence as input and returns a string.
This interface serves as a template for classes that implement sentence analysis functionality.
ParsingCode (Class):

Represents information about a specific parsing code, consisting of a code string and priority.
Contains the GetPattern method, which generates a pattern based on the specified word or phrase.
ParsingCodeChecker (Scriptable Object):

A ScriptableObject used for checking sentences against predefined parsing code templates.
Contains the GetMatchedParseCodeWithPriority method, which checks sentences against all templates and returns the parsing code with the highest priority.
PatternCreator (Class):

Implements the IPatterCreator interface for generating patterns based on words or phrases.
Used to create regular expressions based on words and their optional endings.
SentenceParsing (Script):

A class that implements the IParser interface and performs sentence analysis.
Utilizes the ParsingCodeChecker object to find the matching parsing code with the highest priority.
SentenceParserEditor (Custom Editor):

A custom editor for the SentenceParsing component, allowing the input of sentences and checking them against defined parsing code templates.
SentenceParsingView (Script):

Handles user input and displays parsing results in the Unity user interface.
Uses an object implementing the IParser interface to perform sentence analysis based on user input.
