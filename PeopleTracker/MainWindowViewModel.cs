using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleTracker
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Linked to the box that lists the people
        /// </summary>
        public ObservableCollection<Person> People { get => _People; set { if (_People == value) return; _People = value; OnPropertyChanged(nameof(People)); } }
        private ObservableCollection<Person> _People = new ObservableCollection<Person>() { new Person { Name = "Albert", Birthdate = new DateTime(1879, 3, 14) } };

        /// <summary>
        /// Linked to the selected items in the people list box
        /// </summary>
        public ObservableCollection<Person> SelectedPeople { get => _SelectedPeople; set { if (_SelectedPeople == value) return; _SelectedPeople = value; OnPropertyChanged(nameof(SelectedPeople)); } }
        private ObservableCollection<Person> _SelectedPeople = new ObservableCollection<Person>();

        public Person SelectedPerson { get => _SelectedPerson; set { if (_SelectedPerson == value) return; _SelectedPerson = value; OnPropertyChanged(nameof(SelectedPerson)); } }
        private Person _SelectedPerson;

        /// <summary>
        /// Linked to the text box in the "Add" section
        /// </summary>
        public String AddName
        {
            get => _AddName;
            set
            {
                if (_AddName == value) return;
                _AddName = value; 
                OnPropertyChanged(nameof(AddName));
            }
        }
        private String _AddName;

        /// <summary>
        /// Linked to the date selector in "Add" section
        /// </summary>
        public DateTime? AddDate { get => _AddDate; set { if (_AddDate == value) return; _AddDate = value; OnPropertyChanged(nameof(AddDate)); } }
        private DateTime? _AddDate;

        /// <summary>
        /// Linked to the text box in the "Edit" section
        /// </summary>
        public String EditName { get => _EditName; set { if (_EditName == value) return; _EditName = value; OnPropertyChanged(nameof(EditName)); } }
        private String _EditName;

        /// <summary>
        /// Linked to the date selector in the "Edit" section
        /// </summary>
        public DateTime? EditDate { get => _EditDate; set { if (_EditDate == value) return; _EditDate = value; OnPropertyChanged(nameof(EditDate)); } }
        private DateTime? _EditDate;

        public Boolean CanEdit { get => _CanEdit; set { if (_CanEdit == value) return; _CanEdit = value; OnPropertyChanged(nameof(CanEdit)); } }
        private Boolean _CanEdit;

        public String Comparison { get => _Comparison; set { if (_Comparison == value) return; _Comparison = value; OnPropertyChanged(nameof(Comparison)); } }
        private String _Comparison;

        /// <summary>
        /// Linked to the text in the "Info" section
        /// </summary>
        public String Info { get => _Info; set { if (_Info == value) return; _Info = value; OnPropertyChanged(nameof(Info)); } }
        private String _Info;


        #region Commands and INotifyPropertyChanged

        public ICommand Add { get => _Add; set { if (_Add == value) return; _Add = value; OnPropertyChanged(nameof(Add)); } }
        private ICommand _Add;

        public ICommand Edit { get => _Edit; set { if (_Edit == value) return; _Edit = value; OnPropertyChanged(nameof(Edit)); } }
        private ICommand _Edit;

        public ICommand DeleteSelection { get => _DeleteSelection; set { if (_DeleteSelection == value) return; _DeleteSelection = value; OnPropertyChanged(nameof(DeleteSelection)); } }
        private ICommand _DeleteSelection;

        public ICommand DeleteFriday { get => _DeleteFriday; set { if (_DeleteFriday == value) return; _DeleteFriday = value; OnPropertyChanged(nameof(DeleteFriday)); } }
        private ICommand _DeleteFriday;

        public ICommand Youngest { get => _Youngest; set { if (_Youngest == value) return; _Youngest = value; OnPropertyChanged(nameof(Youngest)); } }
        private ICommand _Youngest;

        public ICommand NextOldest { get => _NextOldest; set { if (_NextOldest == value) return; _NextOldest = value; OnPropertyChanged(nameof(NextOldest)); } }
        private ICommand _NextOldest;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
