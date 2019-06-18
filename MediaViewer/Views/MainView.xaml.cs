using MediaViewer.ViewModels;
using System.Windows;

namespace MediaViewer.Views
{
    public partial class MainView : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
