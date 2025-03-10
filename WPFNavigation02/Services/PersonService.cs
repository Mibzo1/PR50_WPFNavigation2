using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Models;
using WPFNavigation02.Persistence;

namespace WPFNavigation02.Services
{
    public class PersonService
    {
        private readonly PersonRepo personRepo;

        private ObservableCollection<Person> persons;

        public PersonService(PersonRepo personRepo)
        {
            this.personRepo = personRepo;
        }

        public void Add(Person person)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(person.FirstName + person.LastName))
                {
                    throw new Exception("State name");
                }
                if (person.Age < 0)
                {
                    throw new Exception("Not born yet?");
                }
            }
            finally
            {
                persons.Add(person);
            }
        }

        public ObservableCollection<Person> GetAll()
        {
            return new ObservableCollection<Person>(personRepo.GetAll());
        }
    }
}
