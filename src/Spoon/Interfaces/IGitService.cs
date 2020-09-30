using System.Collections.Generic;

namespace Spoon
{
    public interface IGitService
    {
        IEnumerable<string> GetBranches();
    }
}