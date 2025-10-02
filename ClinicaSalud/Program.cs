
using ClinicaSalud.Models;
using ClinicaSalud.Services;
using ClinicaSalud.Utils;


Dictionary<int, Patient> patientDictionary = new Dictionary<int, Patient>();
List<Patient> patients = new List<Patient>();

var newPatient = new Patient("Juan", "Pérez", 30, "I have cancer");
var newPatient1 = new Patient("Juancho", "Pérez", 30, "I have cancer");
var newPatient2 = new Patient("Juancha", "Pérez", 30, "I have cancer");


patients.Add(newPatient);
patients.Add(newPatient1);
patients.Add(newPatient2);

patientDictionary[newPatient.Id] = newPatient;

bool exit = false;
//Use a while loop so the menu repeats until the user chooses to exit.
while (!exit)
{

    Menu.ShowMenu();
    var option = Console.ReadLine();

    //Use a switch statement to handle the user's choice.
    switch (option)
    {
        case "1":
            Console.WriteLine("\n-- Patient Registration --");
            PatientServices.PatientRegistration(patients);
            Menu.Pause();
            break;

        case "2":
            Console.WriteLine("\n-- Patient List --");
            PatientServices.PatientList(patients);
            Menu.Pause();
            break;

        case "3":
            Console.WriteLine("\n-- Patient Search--");
            Console.Write("Enter the name of the patient: ");
            string searchName = InputValidator.ReadNonEmptyString("Enter the name of the patient: ");
            PatientServices.PatientSearch(patients, searchName);
            Menu.Pause();
            break;

        case "4":
            Console.WriteLine("\n-- Delete Patient --");
            Console.Write("Enter the name of the patient to delete: ");
            string deleteName = InputValidator.ReadNonEmptyString("Enter the name of the patient to delete: ");
            PatientServices.DeletePatient(patients, deleteName);
            PatientServices.PatientList(patients);
            Menu.Pause();
            break;

        case "5":
            Console.WriteLine("\n-- Add Pet to Patient --");
            PatientServices.AddPetToPatient(patients);
            Menu.Pause();
            break;

        
        case "6":
            Console.WriteLine("\n-- Exit --");
            exit = true;
            break;

        default:
            Console.WriteLine("\nInvalid option. Please try again.");
            Menu.Pause();
            break;
    }
}
