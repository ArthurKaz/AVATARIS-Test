using System.Text.RegularExpressions;

namespace ParsingLogic
{
    public class PatternCreator : IPatterCreator
    {
        public string GetPattern(ParsingWord word)
        {
            string pattern = @"\b" + Regex.Escape(word.Word);
        
            pattern += EndPattern(word);
            pattern += @"\b";

            return pattern;
        }

        private string EndPattern(ParsingWord word)
        {
            string endPattern = "";
            if (word.Ends != null)
            {
                if (word.Ends.Length == 1)
                {
                    return word.Ends[0] + '?';
                }

                endPattern += '(';
                for (var index = 0; index < word.Ends.Length; index++)
                {
                    var end = word.Ends[index];
                    endPattern += end;
                    if (index < word.Ends.Length - 1)
                    {
                        endPattern += '|';
                    }
                }

                endPattern += ')';
            }

            return endPattern;
        }
    }
}