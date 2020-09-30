using System;
using System.IO;
using Microsoft.Extensions.Options;

namespace Spoon.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SpoonOptions spoonOptions = new SpoonOptions();
            if (args.Length > 0)
            {
                spoonOptions.RepositoryPath = args[0];
            }
            else
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                spoonOptions.RepositoryPath = new DirectoryInfo(currentDirectory).Parent.Parent.FullName;
            }

            var gitService = new LibGit2SharpService(new OptionsWrapper<SpoonOptions>(spoonOptions));

            var branches = gitService.GetBranches();
            foreach (var branch in branches)
            {
                Console.WriteLine(branch);
            }
        }
    }
}
