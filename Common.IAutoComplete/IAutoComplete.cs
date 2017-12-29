using System.Collections.Generic;

namespace Common.IAutoComplete
{
    public interface IAutoCompleteProvider
    {
        IList<ICandidate> GetWords(string fragment);
        void Train(string passage);
    }
}
