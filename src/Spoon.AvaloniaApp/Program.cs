using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Options;

namespace Spoon.AvaloniaApp
{
    class Program
    {
        public static IGitService GitService;

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
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
            GitService = gitService;

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();
    }
}
