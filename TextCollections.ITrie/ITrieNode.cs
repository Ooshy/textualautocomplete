
namespace TextCollections.ITrie
{
    /// <summary>
    /// Defines a key/value pair that can be set or retrieved from <see cref="Trie{TValue}"/>.
    /// </summary>
    public interface ITrieNode<TValue>
    {
        /// <summary>
        /// Gets the key in the key/value pair.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the value in the key/value pair.
        /// </summary>
        TValue Value { get; }
    }
}
