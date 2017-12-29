using System;
//using TCandidates = System.Collections.Generic.IEnumerable<TextCollections.ITrie.ITrieNode<string>>;

namespace TextualAutocomplete
{
    public class Candidate
    {
        public string Word { get; }

        public int Confidence { get; }

        public Candidate(string word, int confidence)
        {
            if ((Word = word) == null)
                throw new ArgumentNullException($"{nameof(word)} is null.");

            Confidence = confidence; // value type, so no null check
        }
    }
}
