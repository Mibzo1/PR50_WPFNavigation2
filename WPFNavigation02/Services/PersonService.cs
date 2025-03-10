using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Persistence;
using WPFNavigation02.Models;
using System.Collections.ObjectModel;
using System.Windows;

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
                if (person == null)
                {
                    throw new ArgumentNullException();
                }

                if (string.IsNullOrWhiteSpace(person.FirstName))
                {
                    MessageBox.Show("First and lastname must be alphabetical characters and not empty.");
                }

                if (string.IsNullOrWhiteSpace(person.LastName))
                {
                    MessageBox.Show("First and lastname must be alphabetical characters and not empty.");
                }

                if (person.Age < 0)
                {
                    MessageBox.Show("Age must be greater than zero and numerical characters.");
                }   
            }
            finally
            {
                personRepo.Add(person);
            }
            


        }

        public ObservableCollection<Person> GetAll()
        {
            return new ObservableCollection<Person>(personRepo.GetAll());
        }
    }
}
