using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PeopleTracker
{
	public class BooleanVisibilityValueConverter : IValueConverter
	{
		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			Boolean boolValue = (Boolean)value;
			if (boolValue)
			{
				return Visibility.Visible;
			}
			else
			{
				return Visibility.Collapsed;
			}
		}

		public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
