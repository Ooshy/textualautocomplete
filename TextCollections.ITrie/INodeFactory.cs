namespace TextCollections.ITrie
{
    public interface INodeFactory<TValue>
    {
        INode<TValue> CreateNode(string key, TValue value, int count = 1);
    }
}
