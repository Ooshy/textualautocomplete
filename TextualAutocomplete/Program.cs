using System;
using TextCollections.ITrie;
using TextCollections.Standard;

namespace TextualAutocomplete
{
    class Program
    {
        static void Main(string[] args)
        {
            ITrie<string> autocomplete = new Trie<string>();
            autocomplete.GetByPrefix("blah");

            string input = "";
            for (;;)
            {
                input = Console.ReadLine();
                switch(input)
                {
                    default:
                        Console.WriteLine("Invalid command. Please enter a valid command.");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}