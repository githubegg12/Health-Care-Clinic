using ClinicaSalud.Utils;

namespace ClinicaSalud.Services;

public class MenuService
{
    public static void Run()
    {
        bool exit = false;

        while (!exit)
        {
            MenuServiceView.ShowClinicMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Menu for patient/pet registration
                    MenuRegistrationView.ShowMenu();
                    Menu.Run();
                    break;

                case "2":
                    Console.WriteLine("\n-- General Consultation --");
                    VetService generalConsult = new GeneralConsultation();
                    generalConsult.Atender();
                    MenuServiceView.Pause();
                    break;

                case "3":
                    Console.WriteLine("\n-- Vaccination Service --");
                    VetService vaccination = new Vaccination(); 
                    vaccination.Atender(); 
                    MenuServiceView.Pause();
                    break;

                case "4":
                    Console.WriteLine("\nExiting system...");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    MenuServiceView.Pause();
                    break;
            }
        }
    }
}