using System;
//using TCandidates = System.Collections.Generic.IEnumerable<TextCollections.ITrie.ITrieNode<string>>;

namespace TextualAutocomplete
{
    internal class Candidate
    {
        internal string Word => _Word;
        private readonly string _Word;
        internal int Confidence => _Confidence;
        private readonly int _Confidence;

        internal Candidate(string word, int confidence)
        {
            if ((_Word = word) == null)
                throw new ArgumentNullException($"{nameof(word)} is null.");

            _Confidence = confidence; // value type, so no null check
        }

        #region Implementation Does Not Fit Requirements / Arguably Better 
        //private readonly TCandidates _Candidates;
        //public Candidate(TCandidates candidates)
        //{
        //    if ((_Candidates = candidates) == null)
        //        throw new ArgumentNullException($"{nameof(candidates)} is null.");
        //    if (_Candidates.Count() == 0)
        //        throw new InvalidOperationException($"No prediction can be made: {nameof(candidates)} has 0 length.");
        //}

        //private ITrieNode<string> __CachedCandidate;
        //private ITrieNode<string> _CachedCandidate => (__CachedCandidate ?? (__CachedCandidate = _Candidates.OrderByDescending(c => c.Count).FirstOrDefault()));

        //internal string PredictedWord => _CachedCandidate.Value;
        //internal int Confidence => _CachedCandidate.Count;
        #endregion
    }
}
