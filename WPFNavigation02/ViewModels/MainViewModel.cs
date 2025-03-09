using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Services;
using WPFNavigation02.Stores;

namespace WPFNavigation02.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;
        private readonly PersonService personService;
        public BaseViewModel CurrentViewModel { get => navigationStore.CurrentViewModel; }

        public MainViewModel(NavigationStore navigationStore, PersonService personService)
        {
            this.navigationStore = navigationStore;
            this.personService = personService;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
