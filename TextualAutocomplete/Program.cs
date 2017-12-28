using System;
using TextCollections.Standard;
using TextualAutocomplete.Output;

namespace TextualAutocomplete
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutoCompleteProvider provider = new AutoCompleteProvider(new Trie<string>()); // inject trie implementation

            IFormatter textFormatter = new TextFormatter();

            var processor = new CommandProcessor(provider, new CommandLineOutput(), textFormatter); // inject command-line output / formatters

            for (;;)
            {
                var input = Console.ReadLine();
                bool @continue = processor.Process(input);
                if (!@continue)
                    break;
            }

            Console.WriteLine("Have a nice day.");
        }
    }
}