using Common.IAutoComplete;
using System;
using TextCollections.Standard;
using TextCollections.Trie;
using TextualAutocomplete.Output;

namespace TextualAutocomplete
{
    internal class TextProcessor
    {
        private readonly IOutput _Output;
        private readonly IAutoCompleteProvider _Provider;
        private readonly IFormatter _Formatter;

        /// <summary>
        /// Processes text-commands for auto-completion.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="output"></param>
        /// <param name="formatter"></param>
        public TextProcessor(IAutoCompleteProvider provider = null, IOutput output = null, IFormatter formatter = null)
        {
            _Provider = provider ?? new AutoCompleteProvider(new Trie<string>(), new TrieNodeFactory<string>());
            _Output = output ?? new CommandLineOutput();
            _Formatter = formatter ?? new TextFormatter();
        }



        /// <summary>
        /// Processes input for the auto-completer.
        /// </summary>
        /// <param name="input">the command to process</param>
        /// <returns>true when program should continue to receive input; false to terminate</returns>
        internal bool Process(string input)
        {
            if (input == null)
                return false; // error

            if (input.StartsWith(TextCommands.Train, StringComparison.CurrentCultureIgnoreCase))
            {
                var passage = input.Substring(TextCommands.Train.Length).Trim().ToLowerInvariant();
                _Provider.Train(passage);
                _Output.WriteLine(_Formatter.FormatTraining(passage));
            }
            else if (input.StartsWith(TextCommands.Input, StringComparison.CurrentCultureIgnoreCase))
            {
                var fragment = input.Substring(TextCommands.Input.Length).Trim().ToLowerInvariant();
                _Output.WriteLine(_Formatter.FormatGetWords(fragment, _Provider.GetWords(fragment)));
            }
            else if (input == "Quit")
            {
                return false;
            }
            else
            {
                _Output.WriteLine("Invalid command. Please enter a valid command. Type Quit to exit.");
            }

            return true;
        }
    }
}
