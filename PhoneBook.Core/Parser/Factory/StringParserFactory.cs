using PhoneBook.Core.Parser.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PhoneBook.Core.Parser
{
    /// <summary>
    /// Factory Pattern Implementation
    /// </summary>
    public class StringParserFactory: IStringParseFactory
    {
        private Dictionary<string, Type> _parsers;
        public const string RemoveString = "Streatigy";
        public StringParserFactory(Assembly assembly)
        {
            _parsers = new Dictionary<string, Type>();
            _parsers =assembly.GetTypes()
                .Where(type => typeof(IParser).IsAssignableFrom(type))
                .ToDictionary(type => type.Name.ToLower(), type => type);
            if (!_parsers.Any()) throw new KeyNotFoundException("No Parser Found");
        }

        public IParser CreateInstance(IStringParseStreatigy streatigy)
        {
            var type = GetType(ParseName(streatigy));
            var ctor = type.GetConstructor(new[] { typeof(IStringParseStreatigy) });
            return ctor.Invoke(new object[] { streatigy }) as IParser;
        }
        private Type GetType(string parserName)
        {
            foreach (var parser in _parsers)
                if (parser.Key.Contains(parserName.ToLower())) return _parsers[parser.Key];
            throw new Exception($"Parser of Type: {parserName} not exist");
        }
        private string ParseName(IStringParseStreatigy streatigy)
        {
            var streatigyName = streatigy.GetType().Name;
            return streatigyName.Remove(streatigyName.IndexOf(RemoveString), RemoveString.Length);
        }
    }
}