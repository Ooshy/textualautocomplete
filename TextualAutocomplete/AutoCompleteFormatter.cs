using System;
using System.Collections.Generic;
using System.Linq;
using TextCollections.ITrie;

namespace TextualAutocomplete
{
    internal interface IFormatter
    {
        string FormatGetWords(string fragment, IEnumerable<Candidate> collection);
        string FormatTraining(string passage);
    }

    /// <summary>
    /// Formats output for auto-complete results.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    internal class TextFormatter : IFormatter
    {
        string IFormatter.FormatGetWords(string fragment, IEnumerable<Candidate> collection) => $"Input: \"{fragment}\" --> {string.Join(",", collection.Select(item => $"\"{item.Word}\" ({item.Confidence})"))}";

        string IFormatter.FormatTraining(string passage) => $"Train: {passage}";
    }
}
