using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MediaViewer.Infrastructure.Helpers;
using CommonServiceLocator;
using MediaViewer.Models;
using System.Windows;

namespace MediaViewer.ViewModels
{
    public sealed class MainViewModel : MyBaseViewModel
    {
        public MainViewModel()
        {
            base.UpdateFiles();

            SelectedFileCommand = new RelayCommand(SelectedFile);
        }

        #region Properties

        public ICommand SelectedFileCommand { get; set; }

        public string SelectedPhotoPath { get; set; }
        public string SelectedGIFPath { get; set; }
        public string SelectedVideoPath { get; set; }

        public Visibility ImageVisibility
        {
            get
            {
                return SelectedPhotoPath.IsNullOrEmpty() ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility GIFVisibility
        {
            get
            {
                return SelectedGIFPath.IsNullOrEmpty() ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility VideoVisibility
        {
            get
            {
                return SelectedVideoPath.IsNullOrEmpty() ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        #endregion

        private void SelectedFile(object obj)
        {
            SelectedPhotoPath = null;
            SelectedGIFPath = null;
            SelectedVideoPath = null;

            var selectedFile = obj as Media;

            if (selectedFile.Path.Contains(".jpg"))
            {
                SelectedPhotoPath = selectedFile.Path;
            }
            else if (selectedFile.Path.Contains(".gif"))
            {
                SelectedGIFPath = selectedFile.Path;
            }
            else if (SupportedVideoExtensions.Contains(selectedFile.Path.Split('.')[1]))
            {
                SelectedVideoPath = selectedFile.Path;
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}