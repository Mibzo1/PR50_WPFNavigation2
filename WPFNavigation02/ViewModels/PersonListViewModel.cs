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
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        private readonly PersonService personService;

        public ICommand NavigateAddPersonViewCommand { get; set; }

        public PersonListViewModel(NavigationStore navigationStore, PersonService personService)
        {
            NavigateAddPersonViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new AddPersonViewModel(navigationStore)));
            this.personService = personService;
        }
    }
}
