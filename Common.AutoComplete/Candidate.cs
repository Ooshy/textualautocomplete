using Common.IAutoComplete;
using System;

namespace TextualAutocomplete
{
    public class Candidate : ICandidate
    {
        /// <summary>
        /// A word within a given text.
        /// </summary>
        public string Word { get; }

        /// <summary>
        /// The likelihood that the word occurs within a given text. Useful when compared against other Candidate's confidence values.
        /// </summary>
        public int Confidence { get; }

        /// <summary>
        /// A word and its likelihood to appear in a given text.
        /// </summary>
        public Candidate(string word, int confidence)
        {
            if ((Word = word) == null)
                throw new ArgumentNullException($"{nameof(word)} is null.");
            if (confidence < 0)
                throw new InvalidOperationException($"{nameof(confidence)} is below 0.");
            Confidence = confidence; // value type, so no null check
        }
    }
}
