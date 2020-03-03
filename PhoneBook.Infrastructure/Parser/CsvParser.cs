using CsvHelper;
using PhoneBook.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PhoneBook.Infrastructure.Parser
{
    // Csv Parser implementation
    // Also make string fault tolerance,
    // Instead of passing string for validation, we pass this parser
    public class CsvParser : Core.Parser.IParser
    {
        private readonly CsvReader _csvReader;
        private readonly StreamReader _reader;
        public CsvParser(Core.Parser.IStringParseStreatigy streatigy)
        {
            if (streatigy.IsNull()) throw new Exception("No Streatigy provided");
            if (streatigy.StringToParse.IsNull()) throw new Exception("No string is provided to parse");

            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(streatigy.StringToParse);
            _reader = new StreamReader(new MemoryStream(byteArray));
            _csvReader = new CsvReader(_reader, CultureInfo.InvariantCulture);
            _csvReader.Configuration.BadDataFound = null;
            _csvReader.Configuration.HeaderValidated = null;
            _csvReader.Configuration.MissingFieldFound = null;

        }
        public List<T> ToObjectList<T>()
        {
            return _csvReader.GetRecords<T>().ToList();
        }

        public void Dispose()
        {
            _reader.Dispose();
            _csvReader.Dispose();
        }
    }
}
