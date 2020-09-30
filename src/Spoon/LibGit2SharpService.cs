using LibGit2Sharp;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Spoon
{
    public class LibGit2SharpService : IGitService
    {
        private readonly SpoonOptions _spoonOptions;
        
        public LibGit2SharpService(IOptions<SpoonOptions> spoonOptions)
        {
            _spoonOptions = spoonOptions.Value;
        }
        
        public IEnumerable<string> GetBranches()
        {
            var repository = new Repository(_spoonOptions.RepositoryPath);
            foreach (var repositoryBranch in repository.Branches)
            {
                yield return repositoryBranch.FriendlyName;
            }
        }
    }
}
