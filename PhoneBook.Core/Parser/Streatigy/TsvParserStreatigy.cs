namespace PhoneBook.Core.Parser
{
    // Streatigy Pattern child class
    public class TsvParserStreatigy : IStringParseStreatigy
    {
        public string StringToParse { get; private set; }
        public TsvParserStreatigy(string stringToParse)
        {
            StringToParse = stringToParse;
        }
    }
}
