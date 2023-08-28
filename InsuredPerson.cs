using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuredPersonCollection
{
    class InsuredPerson
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private int Age { get; set; }
        private string PhoneNumber { get; set; }

        public InsuredPerson(string name, string surname, int age, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name,-15}{Surname,-15}{Age,-10}{PhoneNumber,-15}";
        }
    }
}
