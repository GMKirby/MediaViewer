using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MediaViewer.Infrastructure.Helpers;
using CommonServiceLocator;
using System.Collections.ObjectModel;
using System;

namespace MediaViewer.ViewModels
{
    public sealed class OptionsViewModel : MyBaseViewModel
    {
        public OptionsViewModel()
        {
            AddPathCommand = new RelayCommand(AddPath);
        }

        #region Properties

        public ICommand AddPathCommand { get; set; }

        public string NewPath { get; set; }
        #endregion

        private void AddPath(object obj)
        {
            if (!string.IsNullOrEmpty(NewPath))
            {
                SourcePath = NewPath;
                UpdateFiles();
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}