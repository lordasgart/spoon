using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;
using ReactiveUI;

namespace Spoon.AvaloniaApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IGitService _gitService;

        public MainWindowViewModel()
        {
            _gitService = Program.GitService;

            Branches = _gitService.GetBranches();
        }

        public string Greeting => "Hello World!";

        public IEnumerable<string> Branches {get;set;}

        private string _selectedBranch;
        public string SelectedBranch 
        {
            get => _selectedBranch;
            set => this.RaiseAndSetIfChanged(ref _selectedBranch, value);
        }
    }
}
