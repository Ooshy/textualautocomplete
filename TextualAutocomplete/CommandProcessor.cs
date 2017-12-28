using System;
using TextualAutocomplete.Output;

namespace TextualAutocomplete
{
    internal class CommandProcessor
    {
        private readonly IOutput _Output;
        private readonly IAutoCompleteProvider _Provider;
        private readonly IFormatter _Formatter;

        /// <summary>
        /// Processes commands for auto-completion.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="output"></param>
        /// <param name="formatter"></param>
        public CommandProcessor(IAutoCompleteProvider provider, IOutput output, IFormatter formatter = null)
        {
            if ((_Provider = provider) == null)
                throw new ArgumentNullException($"{nameof(provider)} is null.");
            if ((_Output = output) == null)
                throw new ArgumentNullException($"{nameof(output)} is null.");

            if (formatter == null) /* default implementation */
                formatter = new TextFormatter();

            _Formatter = formatter;
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
                var passage = input.Substring(TextCommands.Train.Length).ToLowerInvariant();
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
