using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InsuredPersonCollection
{
    class UserInterface
    {
        // Creation private database of insured person
        private readonly Database database;

        /// <summary>
        /// Creation private database of insured person
        /// </summary>
        public UserInterface()
        {
            database = new Database();
        }

        // Clear console, draw logo representing this application, delay (time is editable) before continue
        private void Logo(int milliseconds)
        {
            Console.Clear();
            Console.WriteLine("\r\n\t\t _______  _____   _____  _______\r\n\t\t |______ |_____] |     | |______\r\n\t\t |______ |       |_____| ______|\r\n\t\t");
            Thread.Sleep(milliseconds);
        }

        /// <summary>
        /// Displays logo and welcome message. 
        /// </summary>
        public void WelcomeText()
        {
            Logo(500);
            Console.WriteLine("\tVítejte v aplikaci pro evidenci pojištěných osob.");
            Thread.Sleep(2500);
        }

        /// <summary>
        /// Displays logo and farewell message. 
        /// </summary>
        public void FarewellText()
        {
            Logo(250);
            Console.WriteLine("\nDěkujeme, že jste využili naší aplikaci EPOS.\nNyní, libovolnou klávesou ukončíte program.");
        }

        /// <summary>
        /// Displays logo and list of choices, which representing actions in application.
        /// </summary>
        public void ListOfChoice()
        {
            Logo(0);
            Console.WriteLine("\nVyberte si Vaší akci:\n");
            Console.WriteLine("1 - Přidat pojištěnou osobu");
            Console.WriteLine("2 - Vypsat všechny pojištěné osoby");
            Console.WriteLine("3 - Vyhledat pojištěnou osobu");
            Console.WriteLine("4 - Konec\n");
        }

        // Function for clear of row (number is editable) in console
        private void ClearConsoleLine(int numberOfRows)
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        /// <summary>
        /// Displays error message on invalid user input
        /// </summary>
        public void InvalidInput()
        {
            Console.WriteLine("\nNeplatný vstup. Prosím zkuste to znovu.");
            Thread.Sleep(1300);
            ClearConsoleLine(3);
        }

        // Read console, make it lower and trim
        private string ReadLine()
        {
            return Console.ReadLine().ToLower().Trim();
        }

        // Verify input if isn't null or empty
        private string VerifyInput(string input)
        {
            while (string.IsNullOrEmpty(input))
            {
                InvalidInput();
                input = ReadLine();
            }

            return input;
        }

        // Convert string to int
        private int StringToInteger(string input)
        {
            int result;

            while (!int.TryParse(input, out result))
            {
                InvalidInput();
                input = ReadLine();
            }

            return result;
        }

        // Verify user answer
        private bool VerifyAnswer(string input)
        {
            while (input != "ano" && input != "ne")
            {
                InvalidInput();
                input = VerifyInput(ReadLine());
            }

            return input == "ano";
        }

        // Method which make uppercase first letter
        private string UppercaseFirstLetter(string input)
        {
            char firstChar = char.ToUpper(input[0]);
            string restOfString = input[1..];

            return firstChar + restOfString;
        }

        // Method to get name of insured person
        private string GetName()
        {
            Console.WriteLine("\nZapiš jméno pojištěnce:");
            return UppercaseFirstLetter(VerifyInput(ReadLine()));
        }

        // Method to get surname of insured person
        private string GetSurname()
        {
            Console.WriteLine("Zapiš příjmení pojištěnce:");
            return UppercaseFirstLetter(VerifyInput(ReadLine()));
        }

        // Method to get age, validate age range of insured person
        private int GetAge()
        {
            int age;
            Console.WriteLine("Zapiš věk pojištěnce:");

            // Validate age range
            bool validAgeInput = false;
            do
            {
                age = StringToInteger(VerifyInput(ReadLine()));

                if (age >= 0 && age <= 100)
                {
                    validAgeInput = true;
                }
                else
                {
                    InvalidInput();
                }

            } while (!validAgeInput);

            return age;
        }

        // Method to get phone number of insured person
        private string GetPhoneNumber()
        {
            Console.WriteLine("Zapiš telefonní číslo pojištěnce:");
            return VerifyInput(ReadLine());
        }

        /// <summary>
        /// Displays all persons from the database of insured persons along their details information
        /// </summary>
        public void GetPersons()
        {
            Logo(250);

            List<InsuredPerson> foundPersons = database.GetPersons();

            if (foundPersons.Count > 0)
            {
                // Display result if something match
                Console.WriteLine("\nSeznam všech pojištěných osob.");
                Console.WriteLine("\nJméno          Příjmení       Věk       Telefonní číslo");
                Console.WriteLine("--------------------------------------------------------\n");
                
                // Print list
                foreach (InsuredPerson person in foundPersons)
                {
                    Console.WriteLine(person);
                }
            }
            else
            {
                // Inform user about result
                Console.WriteLine("\nNebyly nalezeny žádné záznamy.");
                Thread.Sleep(1300);
                ClearConsoleLine(3);
            }

            Console.WriteLine("\n\nVrať se zpět do nabídky, stisknutím libovolné klávesy.");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays specific person, which user defined (name, surname), from the database of insured persons along details information
        /// Allow continue find another person
        /// </summary>
        public void FindPerson()
        {
            do
            {
                Logo(250);

                // Search person in database
                List<InsuredPerson> foundPersons = database.FindPerson(GetName(), GetSurname());

                if (foundPersons.Count > 0)
                {
                    Logo(250);

                    // Display result if something match
                    Console.WriteLine("\nVašemu hledání, vyhovují následující záznamy:");
                    Console.WriteLine("\nJméno          Příjmení       Věk       Telefonní číslo");
                    Console.WriteLine("--------------------------------------------------------\n");

                    // Print list
                    foreach (InsuredPerson person in foundPersons)
                    {
                        Console.WriteLine(person);
                    }
                }
                else
                {
                    Logo(250);

                    // Inform user about result
                    Console.WriteLine("\nNebyly nalezeny žádné záznamy.");
                    Thread.Sleep(1300);
                    ClearConsoleLine(3);
                }

                // Ask to find another person, or end of loop
                Console.WriteLine("\n\nChcete vyhledat dalšího pojištěnce? (ano/ne)");

            } while (VerifyAnswer(VerifyInput(ReadLine())));
        }

        /// <summary>
        /// Displays provided person data, asks to confirm and returns response
        /// </summary>
        /// <param name="name">Fisrt name of person</param>
        /// <param name="surname">Last name od person</param>
        /// <param name="age">Age of person</param>
        /// <param name="phoneNumber">Phone number of person</param>
        /// <returns>Returns true, if user want save provided data, otherwise false</returns>
        public bool ConfirmPersonData(string name, string surname, int age, string phoneNumber)
        {
            Logo(250);

            // Print title
            Console.WriteLine("\nZkontrolujte zadané údaje:\n");

            // Display provided data
            Console.WriteLine($"Jméno: {name}");
            Console.WriteLine($"Příjmení: {surname}");
            Console.WriteLine($"Věk: {age}");
            Console.WriteLine($"Telefonní číslo: {phoneNumber}");

            // Ask to confirm the data
            Console.WriteLine("\nChcete potvrdit zápis těchto údajů? (ano/ne)");

            // Verify user input
            return VerifyAnswer(VerifyInput(ReadLine()));
        }


        /// <summary>
        /// Allow add person to database of insured persons
        /// </summary>
        public void AddPerson()
        {
            // Loop to adding person to database ends, when user doesn't want add another person
            do
            {
                Logo(250);

                // Get person name, surname, age, phone number
                string name = GetName();
                string surname = GetSurname();
                int age = GetAge();
                string phoneNumber = GetPhoneNumber();

                // Confirmation input data about new person, adding could be canceled by user
                if (ConfirmPersonData(name, surname, age, phoneNumber))
                {
                    // Add person to database
                    database.AddPerson(name, surname, age, phoneNumber);
                    Logo(250);
                    // Inform user about success
                    Console.WriteLine("\nPojištěnec byl úspěšně přidán.");
                }
                else
                {
                    // Inform user about canceling
                    Logo(250);
                    Console.WriteLine("\nPřidání pojištěnce bylo zrušeno.");
                }

                // Clear, ask to add another person, or end of loop
                Thread.Sleep(1300);
                ClearConsoleLine(2);
                Console.WriteLine("\nChcete přidat dalšího pojištěnce? (ano/ne)");

            } while (VerifyAnswer(VerifyInput(ReadLine())));
        }
    }
}
