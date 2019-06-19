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

        public void UpdateFiles()
        {
            MediaList.Clear();

            foreach (var filePath in Directory.GetFiles(SourcePath).Where(item => !item.Contains(".ini")))
            {
                MediaList.Add(new Media()
                {
                    Path = filePath
                }); ;
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