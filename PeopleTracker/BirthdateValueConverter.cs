using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PeopleTracker
{
	public class BirthdateValueConverter : IValueConverter
	{
		public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			DateTime dateTime = (DateTime)value;

			return MainWindow.GetBirthdateText(dateTime);
		}

		public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
