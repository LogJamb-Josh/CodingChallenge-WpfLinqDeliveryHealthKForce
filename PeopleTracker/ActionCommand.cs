using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleTracker
{
	public class ActionCommand : ICommand
	{
		private readonly Action action;
		private readonly Func<Boolean> canExecute;

		public ActionCommand(Action action, Func<Boolean> canExecute)
		{
			this.action = action;
			this.canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public void OnCanExecuteChanged()
		{
			this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public Boolean CanExecute(Object parameter)
		{
			return this.canExecute();
		}

		public void Execute(Object parameter)
		{
			this.action();
		}
	}
}
