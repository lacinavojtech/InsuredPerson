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
        private readonly List<InsuredPerson> persons = new();

        public Database()
        {
            persons = new List<InsuredPerson>();
        }

        // Adding person to the database of insured persons
        public void AddPerson(string name, string surname, int age, string phoneNumber)
        {
            persons.Add(new InsuredPerson(name, surname, age, phoneNumber));
        }

        // Getting all persons from the database of insured persons
        public string GetPersons()
        {
            string textOut = "";
            foreach (InsuredPerson person in persons)
            {
                textOut += string.Format("\n" + person.ToString());
            }
            return textOut;
        }

        // Finding specific person from the database of insured persons
        public List<InsuredPerson> FindPerson (string name, string surname)
        {
            List<InsuredPerson> found = new List<InsuredPerson>();
            foreach (InsuredPerson person in persons)
            {
                if (((person.Name == name)) && (person.Surname == surname))
                    found.Add(person);
            }
            return found;
        }
    }
}
