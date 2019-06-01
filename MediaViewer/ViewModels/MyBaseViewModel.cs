using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using MediaViewer.Properties;

namespace MediaViewer.ViewModels
{
	public class MyBaseViewModel : ViewModelBase
	{
        [NotifyPropertyChangedInvocator]
        public override void RaisePropertyChanged([CallerMemberName]string property = "")
		{
			base.RaisePropertyChanged(property);
		}
    }
}