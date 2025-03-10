using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation02.Services;
using WPFNavigation02.Stores;
using WPFNavigation02.Commands;

namespace WPFNavigation02.ViewModels
{
    public class PersonListViewModel : BaseViewModel
    {
        private readonly PersonService personService;
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        public ICommand NavigateAddPersonViewCommand { get; set; }

        public PersonListViewModel(NavigationStore navigationStore, PersonService personService)
        {
            this.personService = personService;
            NavigateAddPersonViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new AddPersonViewModel(navigationStore, personService, new PersonListViewModel(navigationStore, personService))));
        }
    }
}
