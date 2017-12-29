using TextCollections.ITrie;

namespace TextCollections.Trie
{
    public class TrieNodeFactory<TValue> : INodeFactory<TValue>
    {
        public INode<TValue> CreateNode(string key, TValue value, int count = 0)
        {
            return new TrieNode<TValue>(key, value, count);
        }
    }
}
