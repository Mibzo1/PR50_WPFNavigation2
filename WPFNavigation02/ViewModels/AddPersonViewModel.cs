using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation02.Stores;
using WPFNavigation02.Commands;
using WPFNavigation02.Services;
using WPFNavigation02.Models;

namespace WPFNavigation02.ViewModels
{
    public class AddPersonViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        private readonly PersonService _personService;
        public ICommand NavigatePersonListViewCommand { get; }
        public ICommand AddPersonCommand { get; }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }


        public AddPersonViewModel(NavigationStore navigationStore, PersonService personService)
        {
            _personService = personService;

            AddPersonCommand = new NavigateCommand(new NavigationService(navigationStore, () =>
            {

                Person newPerson;
                newPerson = new Person(FirstName, LastName, Age);
                _personService.Add(newPerson);


                return new PersonListViewModel(navigationStore, _personService);
            }));
        }
    }
}

