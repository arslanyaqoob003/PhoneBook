using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Parser;
using PhoneBook.Core.Parser.Factory;
using System.Reflection;

namespace PhoneBook.Application.Extensions
{
    /// <summary>
    /// Singleton Pattern for StringParseFactory
    /// Extension methods to register in IOC
    /// </summary>
    public static class StringParserFactoryExtension
    {
        public static void RegisterStringParseFactory(this IServiceCollection serviceProvider, string assemblyName)
        {
            // Singleton Pattern
            serviceProvider.AddSingleton<IStringParseFactory>(new StringParserFactory(Assembly.Load(assemblyName)));
        }
    }
}
