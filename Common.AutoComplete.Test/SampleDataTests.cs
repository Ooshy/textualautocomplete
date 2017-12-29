using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextualAutocomplete;
using TextCollections.Standard;
using TextCollections.Trie;

namespace Common.AutoComplete.Test
{
    [TestClass]
    public class SampleDataTests
    {
        public AutoCompleteProvider _Provider { get; set; }
        [TestInitialize]
        public void Setup()
        {
            _Provider = new AutoCompleteProvider(new Trie<string>(), new TrieNodeFactory<string>());
            _Provider.Train("The third thing that I need to tell you is that this thing does not think thoroughly.");
        }

        [TestMethod]
        public void FirstRoundTests()
        {
            var words = _Provider.GetWords("thi"); // Input: "thi"-- > "thing"(2), "think"(1), "third"(1), "this"(1)

            Assert.AreEqual(2, words.First(w => w.Word.ToLowerInvariant() == "thing").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "think").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "third").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "this").Confidence);

            Assert.AreEqual(4, words.Count);
        }

        [TestMethod]
        public void SecondRoundTests()
        {
            var words = _Provider.GetWords("nee"); // Input: "nee"-- > "need"(1)

            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "need").Confidence);
            Assert.AreEqual(1, words.Count);
        }

        [TestMethod]
        public void ThirdRoundTests()
        {
            var words = _Provider.GetWords("th"); // Input: "th"-- > "that"(2), "thing"(2), "think"(1), "this"(1), "third"(1), "the"(1), "thoroughly"(1).

            Assert.AreEqual(2, words.First(w => w.Word.ToLowerInvariant() == "that").Confidence);
            Assert.AreEqual(2, words.First(w => w.Word.ToLowerInvariant() == "thing").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "think").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "this").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "third").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "the").Confidence);
            Assert.AreEqual(1, words.First(w => w.Word.ToLowerInvariant() == "thoroughly").Confidence);

            Assert.AreEqual(7, words.Count);
        }
    }
}
