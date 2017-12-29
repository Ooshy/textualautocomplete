using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextCollections.ITrie;

namespace TextualAutocomplete
{
 

    public class AutoCompleteProvider : IAutoCompleteProvider
    {
        private readonly ITrie<string> _Storage;

        public AutoCompleteProvider(ITrie<string> trie = null)
        {
            if ((_Storage = trie) == null)
                throw new ArgumentNullException($"{nameof(trie)} is null.");
        }

        /// <summary>
        /// Returns a list of auto-complete matches and partial matches.
        /// </summary>
        /// <param name="fragment">the prefix of the word to search for. will be trimmed</param>
        /// <returns></returns>
        IList<Candidate> IAutoCompleteProvider.GetWords(string fragment)
        {
            return _Storage.GetByPrefix(fragment).Select(word => new Candidate(word.Value, word.Count)).ToList();
        }


        /// <summary>
        /// Words to train the auto-complete engine on.
        /// </summary>
        /// <param name="passage"></param>
        void IAutoCompleteProvider.Train(string passage)
        {
            var words = passage.Split(null /* whitespace */)
                               .Where(word => !string.IsNullOrWhiteSpace(word))
                               .Select(word =>
                               {
                                   var removedPunctuation = Regex.Replace(word, "\\p{P}+", ""); // remove punctuation from each word
                                   var trimmed = removedPunctuation.Trim();
                                   return (ITrieNode<string>)(new TrieNode<string>(trimmed, trimmed));
                               });

            _Storage.AddRange(words);
        }

    }
}
