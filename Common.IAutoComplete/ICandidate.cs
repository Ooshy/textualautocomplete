namespace Common.IAutoComplete
{
    public interface ICandidate
    {
        string Word { get; }
        int Confidence { get; }
    }
}
