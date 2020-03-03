namespace PhoneBook.Core.Parser.Factory
{
    /// <summary>
    /// Factory Pattern interface
    /// </summary>
    public interface IStringParseFactory
    {
        IParser CreateInstance(IStringParseStreatigy streatigy);
    }
}
