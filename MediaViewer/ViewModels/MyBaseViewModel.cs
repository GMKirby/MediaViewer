using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediaViewer.Models;
using MediaViewer.Properties;
using MediaViewer.Views;

namespace MediaViewer.ViewModels
{
    public class MyBaseViewModel : ViewModelBase
    {
        public MyBaseViewModel()
        {
            NavigateToMainPageCommand = new RelayCommand(NavigateToMainPage);
            NavigateToOptionsPageCommand = new RelayCommand(NavigateToOptionsPage);
        }

        public RelayCommand NavigateToMainPageCommand { get; set; }
        public RelayCommand NavigateToOptionsPageCommand { get; set; }

        [NotifyPropertyChangedInvocator]
        public override void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            base.RaisePropertyChanged(property);
        }

        public string SourcePath { get; set; } = @"E:\Users\georg\Pictures";

        public List<Media> MediaList { get; set; } = new List<Media>();

        public List<string> SupportedVideoExtensions
        {
            get
            {
                return new List<string>()
                {
                    "webm", "mp4"
                };
            }
        }

        public void UpdateFiles()
        {
            MediaList.Clear();

            foreach (var filePath in Directory.GetFiles(SourcePath).Where(item => !item.Contains(".ini")))
            {
                var fileName = filePath.Split('\\').LastOrDefault();
                var extension = filePath.Split('.').LastOrDefault();

                if (SupportedVideoExtensions.Contains(extension))
                {
                    var tempFolder = Path.GetTempPath();
                    var tempThumbnailPath = string.Format("{0}{1}.jpg", tempFolder, fileName);

                    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();

                    CreateThumbnailForVideo(filePath, tempThumbnailPath, ffMpeg);

                    ffMpeg.Stop();

                    if (extension.Contains("webm"))
                    {
                        var newFilePath = string.Format("{0}{1}.mp4", tempFolder, fileName);

                        if (!File.Exists(newFilePath))
                        {
                            var tempffMpeg = new NReco.VideoConverter.FFMpegConverter();

                            tempffMpeg.ConvertMedia(filePath, newFilePath, "mp4");

                            tempffMpeg.Stop();
                        }

                        AddMediaToList(extension, tempThumbnailPath, newFilePath);
                    }
                    else
                    {
                        AddMediaToList(extension, tempThumbnailPath, filePath);
                    }
                }
                else
                {
                    AddMediaToList(extension, filePath, filePath);
                }
            }
        }

        private void AddMediaToList(string extension, string thumbnailPath, string filePath)
        {
            MediaList.Add(new Media()
            {
                Path = filePath,
                ThumbnailPath = thumbnailPath,
                Extension = extension
            });
        }

        private static void CreateThumbnailForVideo(string filePath, string tempThumbnailPath, NReco.VideoConverter.FFMpegConverter ffMpeg)
        {
            try
            {
                ffMpeg.GetVideoThumbnail(filePath, tempThumbnailPath);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Console.Write("Thumbnail already exists in TEMP Folder");
            }
        }

        public void NavigateToMainPage(object obj)
        {
            throw new NotImplementedException();
        }

        private void NavigateToOptionsPage(object obj)
        {
            throw new NotImplementedException();
        }
    }
}