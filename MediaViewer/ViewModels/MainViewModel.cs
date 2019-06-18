using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MediaViewer.Infrastructure.Helpers;
using CommonServiceLocator;

namespace MediaViewer.ViewModels
{
    public sealed class MainViewModel : MyBaseViewModel
    {
        public MainViewModel()
        {
            base.UpdateFiles();
        }

        #region Properties

        #endregion

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}