using Common.IAutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextCollections.ITrie;

namespace TextualAutocomplete
{
    public class AutoCompleteProvider : IAutoCompleteProvider
    {
        private readonly ITrie<string> _Trie;
        private readonly INodeFactory<string> _NodeFactory;
        public AutoCompleteProvider(ITrie<string> trie, INodeFactory<string> nodeFactory)
        {
            if ((_Trie = trie) == null)
                throw new ArgumentNullException($"{nameof(trie)} is null.");
            if ((_NodeFactory = nodeFactory) == null)
                throw new ArgumentNullException($"{nameof(nodeFactory)} is null.");
        }

        /// <summary>
        /// Returns a list of auto-complete matches and partial matches.
        /// </summary>
        /// <param name="fragment">the prefix of the word to search for.</param>
        /// <returns></returns>
        public IList<ICandidate> GetWords(string fragment)
        {
            return _Trie.GetByPrefix(fragment).Select(word => (ICandidate)new Candidate(word.Value, word.Count)).ToList();
        }


        /// <summary>
        /// Words to train the auto-complete engine on.
        /// </summary>
        /// <param name="passage">text that is processed to enhance predictions.</param>
        public void Train(string passage)
        {
            Train(passage, true);
        }
        /// <summary>
        /// Words to train the auto-complete engine on.
        /// </summary>
        /// <param name="passage">text that is processed to enhance predictions.</param>
        /// <param name="removePunctuation">removes punctuation before processing</param>
        public void Train(string passage, bool removePunctuation = true)
        {
            if (removePunctuation)
                passage = _RemovePunctuation(passage);    

            var words = passage.Split(null /* whitespace */)
                               .Where(word => !string.IsNullOrWhiteSpace(word))
                               .Select(word =>
                               {
                                   var trimmed = word.Trim();
                                   var lowercased = trimmed.ToLowerInvariant();
                                   return _NodeFactory.CreateNode(lowercased, lowercased);
                               });

            _Trie.AddRange(words);
        }

        private static string _RemovePunctuation(string passage)
        {
            return Regex.Replace(passage, "\\p{P}+", "");
        }
    }
}
