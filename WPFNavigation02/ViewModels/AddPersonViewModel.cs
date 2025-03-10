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
using WPFNavigation02.Persistence;

namespace WPFNavigation02.ViewModels
{
    public class AddPersonViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        private readonly PersonService personService;
        public ICommand NavigatePersonListViewCommand { get; }
        public ICommand AddPersonCommand { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public AddPersonViewModel(NavigationStore navigationStore, PersonService personService) 
        {
            this.navigationStore = navigationStore;
            this.personService = personService;
            NavigatePersonListViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new PersonListViewModel(navigationStore, personService)));
            AddPersonCommand = new NavigateCommand(new NavigationService(navigationStore, () =>
            {
                var personViewModel = new PersonListViewModel(navigationStore, personService)
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Age = Age
                }
            }
        }
    }
}
