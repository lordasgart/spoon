using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Spoon.AvaloniaApp.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}