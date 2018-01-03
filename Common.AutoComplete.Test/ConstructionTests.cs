using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextualAutocomplete;
using TextCollections.Standard;
using TextCollections.Trie;

namespace Common.AutoComplete.Test
{
    [TestClass]
    public class ConstructionTests
    {
        public AutoCompleteProvider _Provider { get; set; }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void NullTrie_WillThrow()
        {
            _Provider = new AutoCompleteProvider(null, new TrieNodeFactory<string>());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void NullTrieNodeFactory_WillThrow()
        {
            _Provider = new AutoCompleteProvider(new Trie<string>(), null);
        }
    }
}
