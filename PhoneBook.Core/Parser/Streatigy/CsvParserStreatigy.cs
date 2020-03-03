namespace PhoneBook.Core.Parser
{
    // Streatigy Pattern child class
    public class CsvParserStreatigy : IStringParseStreatigy
    {
        public string StringToParse { get; private set; }
        public CsvParserStreatigy(string stringToParse)
        {
            StringToParse = stringToParse;
        }
    }
}
