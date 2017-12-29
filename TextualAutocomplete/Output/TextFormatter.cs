using System.Linq;

using Candidates = System.Collections.Generic.IEnumerable<Common.IAutoComplete.ICandidate>;

namespace TextualAutocomplete.Output
{
    internal interface IFormatter
    {
        string FormatGetWords(string fragment, Candidates collection);
        string FormatTraining(string passage);
    }

    /// <summary>
    /// Formats output for auto-complete results.
    /// </summary>
    internal class TextFormatter : IFormatter
    {
        string IFormatter.FormatGetWords(string fragment, Candidates collection) => $"Input: \"{fragment}\" --> {string.Join(", ", collection.OrderByDescending(c => c.Confidence).Select(item => $"\"{item.Word}\" ({item.Confidence})"))}";

        string IFormatter.FormatTraining(string passage) => $"Train: \"{passage}\"";
    }
}
