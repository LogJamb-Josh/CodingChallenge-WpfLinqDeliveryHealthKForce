using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeopleTracker
{
    partial class MainWindow
    {
        // This property is an complex object that tracks the state of the user interface
        public MainWindowViewModel ViewModel { get; }

        // This method controls whether the "Add" button is enabled
        private Boolean AllowAdd()
        {
            int lifespan = 120;
            var oldestPersonEver = DateTime.Now.AddYears(lifespan * -1);

            // TODO: Must return true ONLY if there are less than eight people already in the list.
            bool listCountTest = ViewModel.People.Count() < 8;

            // TODO: Must return true ONLY if the user has typed something in the name field.
            bool hasNameTest = ViewModel.AddName != null;

            // TODO: Must return true ONLY if the name is not already in the list.
            bool dupNameTest = ViewModel.People.ToList().Where(_ => _.Name == ViewModel.AddName).Count() == 0;

            // TODO: Must return true ONLY if the birthdate is for someone who could reasonably still be alive today.
            bool StillAliveTest = ViewModel.AddDate > oldestPersonEver;

            return listCountTest && hasNameTest && dupNameTest && StillAliveTest;
        }

        // This method adds a person to the list using the input from the "Add" section
        private void DoAdd()
        {
            // TODO: Must add a person to the list using the name and birthdate provided by the user
            //var foo = ViewModel.AddName;

            var p = new Person();

            p.Name = ViewModel.AddName;
            p.Birthdate = ViewModel.AddDate ?? DateTime.Now;

            ViewModel.People.Add(p);
        }

        // This method controls whether to show the "Edit" section
        private Boolean ShouldShowEditSection()
        {
            // TODO: Must return true ONLY if there is one person selected in the list
            return ViewModel.SelectedPeople.Count() == 1;
        }

        // This method loads information about a person when a person is selected from the list
        private void LoadPersonForEditing()
        {
            // TODO: Must load the selected person's data into the respective fields in the "Edit" section.
            ViewModel.EditName = ViewModel.SelectedPerson.Name;
            ViewModel.EditDate = ViewModel.SelectedPerson.Birthdate;
        }

        // This method controls whether the "Edit" button is enabled
        private Boolean AllowEdit()
        {
            // TODO: Must return true only if the name and birthdate has been provided by the user            
            return ViewModel.AddName != null && ViewModel.AddDate != null;
        }

        // This method changes the name and birthdate of the selected person
        private void DoEdit()
        {
            // TODO: Must modify the selected person's name and birthdate
            var p = ViewModel.SelectedPerson;

            p.Name = ViewModel.EditName;
            p.Birthdate = ViewModel.EditDate ?? DateTime.Now;
        }

        // This method controls whether the "Delete Selection" button is enabled
        private Boolean AllowDeleteSelection()
        {
            // TODO: You must decide when it is correct to allow the user to delete.
            //return false;
            return ViewModel.SelectedPeople.Any();
        }

        // This method deletes from the list
        private void DoDeleteSelection()
        {
            // TODO: Must delete the user's selection
            foreach (var person in ViewModel.SelectedPeople.ToList())
            {
                ViewModel.People.Remove(person);
            }
        }

        // This method controls whether the "Delete Friday Birthdays" button is enabled
        private Boolean AllowDeleteFridayBirthdays()
        {
            // TODO: You must decide when it is correct to allow the user to delete.            
            return ViewModel.SelectedPeople.Where(_ => _.Birthdate.DayOfWeek == DayOfWeek.Friday).Any();
        }

        // This method deletes everyone from the list with a Friday birthday
        private void DoDeleteFridayBirthdays()
        {
            // TODO: Must delete everyone from the list with a Friday birthday
            foreach (var person in ViewModel.SelectedPeople.Where(_ => _.Birthdate.DayOfWeek == DayOfWeek.Friday).ToList())
            {
                ViewModel.People.Remove(person);
            }
        }

        private String GetInfo()
        {
            var r = "";

            // TODO: Must return the following information, depending on people that are currently selected:

            // * Must always tell the user how many selections they have made.
            if (ViewModel.SelectedPeople.Count() == 1)
            {
                r = "You have made one selection";
            }

            // * If there IS NOT exactly one selection, instruct them to try selecting just one.
            if (ViewModel.SelectedPeople.Count() > 1)
            {
                r = "Please select just one";
            }

            // * If there IS exactly one selection, return their name and age in this format: "Aaron is 10 years old."
            if (ViewModel.SelectedPeople.Count() == 1)
            {
                var yearsOld = DateTime.Now.Year - ViewModel.SelectedPerson.Birthdate.Year;

                r = $"{ViewModel.SelectedPerson.Name} is {yearsOld} years old.";
            }

            // * If there are multiple selections, list their names in this format: "You selected Aaron, Blake, Carl, and Doug."
            r = "You selected ";
            foreach (var person in ViewModel.SelectedPeople.ToList())
            {
                if (person != ViewModel.SelectedPeople.ToList().LastOrDefault())
                {
                    r += $"{person.Name}, ";
                }
                else
                {
                    r += $" and {person.Name}.";
                }
            }

            return r;
        }

        // This method controls the text that is shown in the "Compare" box
        private String GetComparisons()
        {
            var r = "";

            // TODO: Must instruct user to make multiple selections if there are less than two
            if (ViewModel.SelectedPeople.Count() < 2)
            {
                r = "Please make multiple selections";

            } else
            {
                // TODO: Must return comparison between the oldest and youngest selected person in this format: "Aaron is older than Blake by 10 years."
                var y = ViewModel.SelectedPeople.OrderBy(_ => _.Birthdate).FirstOrDefault();
                var o = ViewModel.SelectedPeople.OrderByDescending(_ => _.Birthdate).FirstOrDefault();

                r += $"{o.Name} is older than {y.Name} by {o.Birthdate.Year - y.Birthdate.Year} years.";
            }

            return r;
        }

        // This method controls the text output for the person's birthdate in the list
        public static String GetBirthdateText(DateTime dateTime)
        {
            // TODO: Must return birthdate text in this format: "March 14th, 1879"
            var st = new List<int>() { 1, 21, 31 };
            var nd = new List<int>() { 2, 22, 32 };
            var rd = new List<int>() { 3, 23, 33 };

            var r = "";

            if (st.Contains(dateTime.Day))
            {
                r = dateTime.ToString("MMMM ddst, yyyy");
            }
            else if (nd.Contains(dateTime.Day))
            {
                r = dateTime.ToString("MMMM ddnd, yyyy");
            } else             if (rd.Contains(dateTime.Day))
            {
                r = dateTime.ToString("MMMM ddrd, yyyy");
            } else
            {
                r = dateTime.ToString("MMMM ddth, yyyy");
            }

            return r;
        }

        // This method controls whether the "Youngest" button in the "Navigate" section is enabled
        public Boolean AllowGotoYoungestPerson()
        {
            // TODO: Must return true only if it is possible to select the youngest person, and is not already selected
            //return false;
            var y = GetYoungestPerson();
            return ViewModel.People.Any(_=> _.Name == y.Name) && !ViewModel.SelectedPeople.Any(_=> _.Name == y.Name);
        }

        // This method finds the youngest person in the list
        public Person GetYoungestPerson()
        {
            // TODO: Must return the youngest person.
            return ViewModel.People.OrderBy(_ => _.Birthdate).FirstOrDefault();
        }

        // This method controls whether the "Next Oldest" button in the "Navigate" section is enabled
        public Boolean AllowGotoNextOldestPerson()
        {
            // TODO: Must return true only if it is possible to select the next oldest person, based on the current selection            
            return ViewModel.People.Where(_ => _.Birthdate > ViewModel.SelectedPerson?.Birthdate).Any();
        }

        // This method finds the next oldest person in list
        public Person GetNextOldestPerson()
        {
            // TODO: Must return the next oldest person.
            
            return ViewModel.People
                .Where(_ => _.Birthdate > (ViewModel.SelectedPerson.Birthdate))
                .OrderBy(_=> _.Birthdate)
                .FirstOrDefault();
        }


    }
}
