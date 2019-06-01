using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace MediaViewer.Infrastructure.Converters
{
	public class ErrorContentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var errors = value as ReadOnlyObservableCollection<ValidationError>;
			if (errors == null  ) return "";  

			return errors.Count > 0 ? errors[0].ErrorContent 
									: "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
