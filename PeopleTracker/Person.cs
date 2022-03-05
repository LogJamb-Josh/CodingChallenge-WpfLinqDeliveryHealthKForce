using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTracker
{
	public class Person : INotifyPropertyChanged
	{
		public String Name { get => _Name; set { if (_Name == value) return; _Name = value; OnPropertyChanged(nameof(Name)); } }
		private String _Name;

		public DateTime Birthdate { get => _Birthdate; set { if (_Birthdate == value) return; _Birthdate = value; OnPropertyChanged(nameof(Birthdate)); } }
		private DateTime _Birthdate;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(String propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
