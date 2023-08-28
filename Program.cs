using System.Security.Cryptography.X509Certificates;

namespace InsuredPersonCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new();

            ui.WelcomeText();

            char choice;
            do
            {
                ui.ListOfChoice();
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        ui.AddPerson();
                        break;
                    case '2':
                        ui.GetPersons();
                        break;
                    case '3':
                        ui.FindPerson();
                        break;
                    case '4':
                        ui.FarewellText();
                        break;
                    default:
                        ui.InvalidInput();
                        break;
                }
            } while (choice != '4');
        }
    }
}