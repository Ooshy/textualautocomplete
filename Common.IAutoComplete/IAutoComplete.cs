using System.Collections.Generic;

namespace Common.IAutoComplete
{
    public interface IAutoCompleteProvider
    {
        IList<Candidate> GetWords(string fragment);
        void Train(string passage);
    }
}
