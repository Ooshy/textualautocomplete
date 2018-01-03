using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextualAutocomplete;
using TextCollections.Standard;
using TextCollections.Trie;

namespace Common.AutoComplete.Test
{
    [TestClass]
    public class DataTests
    {
        public AutoCompleteProvider _Provider { get; set; }
        [TestInitialize]
        public void Setup()
        {
            _Provider = new AutoCompleteProvider(new Trie<string>(), new TrieNodeFactory<string>());
        }

        [TestMethod]
        public void GivenNoTraining_0WordsPredicted()
        {
            var words = _Provider.GetWords("");

            Assert.AreEqual(0, words.Count);
        }

        [TestMethod]
        public void AnotherLanguage_WorksCorrectly()
        {
            _Provider.Train("가 각 갂 갃 간 갅 갆 갇ad 갇fd 갈");
            
            Assert.AreEqual(1, _Provider.GetWords("가").Count);
            Assert.AreEqual(2, _Provider.GetWords("갇").Count);
        }

        // TODO Create new NuGet release with case sensitivity.
        // [TestMethod]
        // public void CaseSensitivity_IsInsensitive()
        // {
        //     _Provider.Train("hi");

        //     var words = _Provider.GetWords("");

        //     Assert.AreEqual(0, words.Count);
        // }        
    }
}
