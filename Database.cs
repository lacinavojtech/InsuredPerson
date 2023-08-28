using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuredPersonCollection
{
    class Database
    {
        // Creation private database of insured person
        private readonly List<InsuredPerson> persons;

        /// <summary>
        /// Creation private database of insured person
        /// </summary>
        public Database()
        {
            persons = new List<InsuredPerson>();
        }

        /// <summary>
        /// Adds person to the database of insured persons
        /// </summary>
        /// <param name="name">Fisrt name of person</param>
        /// <param name="surname">Last name od person</param>
        /// <param name="age">Age of person</param>
        /// <param name="phoneNumber">Phone number of person</param>
        public void AddPerson(string name, string surname, int age, string phoneNumber)
        {
            persons.Add(new InsuredPerson(name, surname, age, phoneNumber));
        }

        /// <summary>
        /// Getting all persons from the database of insured persons
        /// </summary>
        /// <returns>List of insured person</returns>
        public List<InsuredPerson> GetPersons()
        {
            List<InsuredPerson> found = new();

            // Iterate through list of persons
            foreach (InsuredPerson person in persons)
            {
                found.Add(person);
            }

            return found;
        }

        /// <summary>
        /// Finds specific person from the database of insured persons
        /// </summary>
        /// <param name="name">Name of searching person</param>
        /// <param name="surname">Surname of searching person</param>
        /// <returns>List of insured person matching to provide data</returns>
        public List<InsuredPerson> FindPerson (string name, string surname)
        {
            List<InsuredPerson> found = new();

            // Iterate through list of persons
            foreach (InsuredPerson person in persons)
            {
                if (person.Name == name && person.Surname == surname)
                    found.Add(person);
            }

            return found;
        }
    }
}
