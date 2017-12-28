
using System;

namespace TextualAutocomplete.Output
{
    internal interface IOutput
    {
        void WriteLine(string output);
    }

    internal class CommandLineOutput : IOutput
    {
        void IOutput.WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
