using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleTracker
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.ViewModel = new MainWindowViewModel();
			this.ViewModel.Add = new ActionCommand(() => { DoAdd(); RefreshVM(null); }, this.AllowAdd);
			this.ViewModel.Edit = new ActionCommand(() => { DoEdit(); RefreshVM(null); }, this.AllowEdit);
			this.ViewModel.DeleteSelection = new ActionCommand(() => { DoDeleteSelection(); RefreshVM(null); }, this.AllowDeleteSelection);
			this.ViewModel.DeleteFriday = new ActionCommand(() => { DoDeleteFridayBirthdays(); RefreshVM(null); }, this.AllowDeleteFridayBirthdays);
			this.ViewModel.Youngest = new ActionCommand(() => { var x = this.GetYoungestPerson(); this.ViewModel.SelectedPerson = null; this.ViewModel.SelectedPerson = x; RefreshVM(null); }, this.AllowGotoYoungestPerson);
			this.ViewModel.NextOldest = new ActionCommand(() => { var x = this.GetNextOldestPerson(); this.ViewModel.SelectedPerson = null; this.ViewModel.SelectedPerson = x; RefreshVM(null); }, this.AllowGotoNextOldestPerson);
			this.ViewModel.PropertyChanged += (sender, args) => RefreshVM(args.PropertyName);
			this.ViewModel.AddDate = DateTime.Now;
			this.ViewModel.EditDate = DateTime.Now;
		}

		private void ListView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
		{
			foreach (Person person in e.AddedItems) { this.ViewModel.SelectedPeople.Add(person); }
			foreach (Person person in e.RemovedItems) { this.ViewModel.SelectedPeople.Remove(person); }
			RefreshVM(null);
		}

		private async void RefreshVM(String propertyName)
		{
			await Task.Delay(100);
			RefreshAfterDelay(propertyName);
		}

		private void RefreshAfterDelay(String propertyName)
		{
			this.ViewModel.CanEdit = this.ShouldShowEditSection();
			this.ViewModel.Info = this.GetInfo();
			this.ViewModel.Comparison = this.GetComparisons();
			if (propertyName == nameof(this.ViewModel.CanEdit))
			{
				if (this.ViewModel.CanEdit)
				{
					LoadPersonForEditing();
				}
			}
			((ActionCommand)this.ViewModel.Add).OnCanExecuteChanged();
			((ActionCommand)this.ViewModel.Edit).OnCanExecuteChanged();
			((ActionCommand)this.ViewModel.DeleteSelection).OnCanExecuteChanged();
			((ActionCommand)this.ViewModel.DeleteFriday).OnCanExecuteChanged();
			((ActionCommand)this.ViewModel.Youngest).OnCanExecuteChanged();
			((ActionCommand)this.ViewModel.NextOldest).OnCanExecuteChanged();
		}
	}
}