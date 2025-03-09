using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation02.Stores;
using WPFNavigation02.Commands;
using WPFNavigation02.Services;

namespace WPFNavigation02.ViewModels
{
    public class AddPersonViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        public ICommand NavigatePersonListViewCommand { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public AddPersonViewModel(NavigationStore navigationStore, PersonService personService) 
        {
            this.navigationStore = navigationStore;
            NavigatePersonListViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new PersonListViewModel(navigationStore)));
        }
    }
}
