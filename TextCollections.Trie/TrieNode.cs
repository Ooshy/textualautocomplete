using System;
using System.Collections.Generic;
using System.Text;

namespace TextCollections.ITrie
{
    /// <summary>
    /// Defines a key/value pair that can be set or retrieved from <see cref="Trie{TValue}"/>.
    /// </summary>
    public struct TrieNode<TValue> : ITrieNode<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrieNode{TValue}"/> structure with the specified key and value.
        /// </summary>
        /// <param name="key">The <see cref="string"/> object defined in each key/value pair.</param>
        /// <param name="value">The definition associated with key.</param>
        public TrieNode(string key, TValue value, int count = 1)
            : this()
        {
            Key = key;
            Value = value;
            Count = count;
        }

        /// <summary>
        /// Gets the key in the key/value pair.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the value in the key/value pair.
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        /// Gets the number of occurences of the key/value pair.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Key, Value);
        }
    }
}
