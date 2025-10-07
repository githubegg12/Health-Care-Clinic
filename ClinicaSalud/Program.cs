using ClinicaSalud.Models;
using ClinicaSalud.Services;
using ClinicaSalud.Utils;


// List<Animal> mascotas = new List<Animal>
// {
//     new Pet("Firulais", "Perro", 5, "Labrador", "Tos"),
//     new Pet("Michi", "Gato", 3, "Siames", "Estornudo"),
//     new Pet("Piolín", "Pajaro", 2, "Canario", "Cansancio"),
//     new Animal("AnimalX", "Desconocido", 4)
// };
//
// foreach (var animal in mascotas)
// {
//     animal.MakeNoice(); // Polimorfismo: se ejecuta el método correspondiente
// }

Dictionary<Guid, Patient> patientDictionary = new Dictionary<Guid, Patient>();
List<Patient> patients = new List<Patient>();

// Add all patients to both containers
var newPatient = new Patient("Juan", "Pérez", 30, "Calle Helm","juan@email.com");
var newPatient1 = new Patient("Juancho", "Pérez", 30, "Calle Helm","juancho@email.com");
var newPatient2 = new Patient("Juancha", "Pérez", 30, "Calle Helm","juancha@email.com");

patients.Add(newPatient);
patients.Add(newPatient1);
patients.Add(newPatient2);

patientDictionary[newPatient.PatientId] = newPatient;
patientDictionary[newPatient1.PatientId] = newPatient1;
patientDictionary[newPatient2.PatientId] = newPatient2;

bool exit = false;

while (!exit)
{
    Menu.ShowMenu();
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine("\n-- Patient Registration --");
            PatientService.PatientRegistration(patientDictionary, patients); // Pass both collections
            Menu.Pause();
            break;

        case "2":
            Console.WriteLine("\n-- Patient List --");
            PatientService.PatientList(patientDictionary); // Show from dictionary
            Menu.Pause();
            break;

        case "3":
            Console.WriteLine("\n-- Patient Search--");
            string searchName = InputValidator.ReadNonEmptyString("Enter the name of the patient: ");
            PatientService.PatientSearch(patientDictionary, searchName); // Use dictionary
            Menu.Pause();
            break;
        
        case "4":
            Console.WriteLine("\n-- Update Patient --");
            PatientService.PatientList(patientDictionary);
            Guid updateId = InputValidator.ReadGuid("Enter the ID of the patient to update: ");
            PatientService.UpdatePatient(patientDictionary, updateId);
            Menu.Pause();
            break;
        
        case "5":
            Console.WriteLine("\n-- Delete Patient --");
            string deleteName = InputValidator.ReadNonEmptyString("Enter the name of the patient to delete: ");
            PatientService.DeletePatient(patientDictionary, patients, deleteName); // Pass both to keep in sync
            PatientService.PatientList(patientDictionary);
            Menu.Pause();
            break;

        case "6":
            Console.WriteLine("\n-- Add Pet to Patient --");
            PatientService.AddPetToPatient(patientDictionary); // Search by Id in dictionary
            Menu.Pause();
            break;

        case "7":
            Console.WriteLine("\n-- Exit --");
            exit = true;
            break;

        default:
            Console.WriteLine("\nInvalid option. Please try again.");
            Menu.Pause();
            break;
    }
}
