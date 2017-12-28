using System;

namespace TextualAutocomplete
{
    class Program
    {
        static void Main(string[] args)
        {
            //IAutoCompleteProvider provider = new AutoCompleteProvider(new Trie<string>()); // is the default option for command processor, so is optional parameter
            //IOutput output = new CommandLineOutput();                                      // is the default option for command processor, so is optional parameter
            //IFormatter textFormatter = new TextFormatter();                                // is the default option for command processor, so is optional parameter

            var processor = new TextProcessor(); // inject command-line output / formatters

            //processor.Process("train: training data to train for training");
            //processor.Process("input: train");

            for (;;)
            {
                var input = Console.ReadLine();
                bool @continue = processor.Process(input);
                if (!@continue)
                    break;
            }

            Console.WriteLine("Have a nice day. Enter to close window.");
            Console.ReadKey();
        }
    }
}