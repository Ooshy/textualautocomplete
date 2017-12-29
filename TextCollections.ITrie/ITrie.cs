using System.Collections.Generic;

namespace TextCollections.ITrie
{
    public interface ITrie<TValue> : IDictionary<string, TValue>
    {
        IEnumerable<INode<TValue>> GetByPrefix(string prefix);
        void AddRange(IEnumerable<INode<TValue>> collection);
    }
}