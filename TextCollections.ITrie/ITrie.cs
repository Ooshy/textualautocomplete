using System.Collections.Generic;

namespace TextCollections.ITrie
{
    public interface ITrie<TValue> : IDictionary<string, TValue>
    {
        IEnumerable<ITrieNode<TValue>> GetByPrefix(string prefix);
        void AddRange(IEnumerable<ITrieNode<TValue>> collection);
    }
}