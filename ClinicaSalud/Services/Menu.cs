using ClinicaSalud.Data;
using ClinicaSalud.Utils;

namespace ClinicaSalud.Services;

public class Menu
{
    public static void Run()
    {
        bool exit = false;

        while (!exit)
        {
            MenuRegistrationView.ShowMenu();

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("\n-- Patient Registration --");
                    PatientService.PatientRegistration();
                    MenuRegistrationView.Pause();
                    break;

                case "2":
                    Console.WriteLine("\n-- Patient List --");
                    PatientService.PatientList();
                    MenuRegistrationView.Pause();
                    break;

                case "3":
                    Console.WriteLine("\n-- Patient Search --");
                    string searchName = InputValidator.ReadNonEmptyString("Enter the name of the patient: ");
                    PatientService.PatientSearch(searchName);
                    MenuRegistrationView.Pause();
                    break;

                case "4":
                    Console.WriteLine("\n-- Update Patient --");
                    PatientService.PatientList();
                    Guid updateId = InputValidator.ReadGuid("Enter the ID of the patient to update: ");
                    PatientService.UpdatePatient(Database.PatientDictionary, updateId);
                    MenuRegistrationView.Pause();
                    break;

                case "5":
                    Console.WriteLine("\n-- Delete Patient --");
                    string deleteName = InputValidator.ReadNonEmptyString("Enter the name of the patient to delete: ");
                    PatientService.DeletePatient(deleteName);
                    PatientService.PatientList();
                    MenuRegistrationView.Pause();
                    break;

                case "6":
                    Console.WriteLine("\n-- Add Pet to Patient --");
                    PetService.AddPetToPatient();
                    MenuRegistrationView.Pause();
                    break;
                
                case "7":
                    Console.WriteLine("\n-- Update Pet --");
                    PetService.UpdatePetOfPatient();
                    MenuRegistrationView.Pause();
                    break;

                case "8":
                    Console.WriteLine("\n-- Delete Pet --");
                    PetService.DeletePet();
                    MenuRegistrationView.Pause();
                    break;

                case "9":
                    Console.WriteLine("\n-- List All Pets --");
                    PetService.ListAllPets();
                    MenuRegistrationView.Pause();
                    break;


                case "10":
                    Console.WriteLine("\n-- Exit --");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    MenuRegistrationView.Pause();
                    break;
            }
        }
    }
}
