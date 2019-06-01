using System;
using System.Windows.Data;
using System.Globalization;
using MediaViewer.Infrastructure.Helpers;

namespace MediaViewer.Infrastructure.Converters
{
	class CommentsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var input_string = value as string;

			if (input_string.IsNullOrEmpty()) 
				return "The cake is a lie.";

			if (input_string.Contains("unicorn"))
				return "Warning: Wild Unicorns found on premise.";
			
			return "This following text is Unicorn free: [" + input_string + "]";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}