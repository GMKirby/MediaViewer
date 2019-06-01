using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace MediaViewer
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
