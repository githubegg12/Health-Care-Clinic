using ClinicaSalud.Models;
using ClinicaSalud.Services;
using ClinicaSalud.Utils;

Dictionary<int, Patient> patientDictionary = new Dictionary<int, Patient>();
List<Patient> patients = new List<Patient>();

// Agrega todos los pacientes a ambos contenedores
var newPatient = new Patient("Juan", "Pérez", 30, "I have cancer");
var newPatient1 = new Patient("Juancho", "Pérez", 30, "I have cancer");
var newPatient2 = new Patient("Juancha", "Pérez", 30, "I have cancer");

patients.Add(newPatient);
patients.Add(newPatient1);
patients.Add(newPatient2);

patientDictionary[newPatient.Id] = newPatient;
patientDictionary[newPatient1.Id] = newPatient1;
patientDictionary[newPatient2.Id] = newPatient2;

bool exit = false;

while (!exit)
{
    Menu.ShowMenu();
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("\n-- Patient Registration --");
            PatientServices.PatientRegistration(patientDictionary, patients); // Pasamos ambos
            Menu.Pause();
            break;

        case "2":
            Console.WriteLine("\n-- Patient List --");
            PatientServices.PatientList(patientDictionary); // Mostrar desde diccionario
            Menu.Pause();
            break;

        case "3":
            Console.WriteLine("\n-- Patient Search--");
            string searchName = InputValidator.ReadNonEmptyString("Enter the name of the patient: ");
            PatientServices.PatientSearch(patientDictionary, searchName); // Usar diccionario
            Menu.Pause();
            break;

        case "4":
            Console.WriteLine("\n-- Delete Patient --");
            string deleteName = InputValidator.ReadNonEmptyString("Enter the name of the patient to delete: ");
            PatientServices.DeletePatient(patientDictionary, patients, deleteName); // Pasar ambos para sincronizar
            PatientServices.PatientList(patientDictionary);
            Menu.Pause();
            break;

        case "5":
            Console.WriteLine("\n-- Add Pet to Patient --");
            PatientServices.AddPetToPatient(patientDictionary); // Buscar por Id en diccionario
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
