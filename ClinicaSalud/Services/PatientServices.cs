

using ClinicaSalud.Models;
namespace ClinicaSalud.Services;

public class PatientServices
{
    //Request data through the console and add a new patient to the list.
    public static void PatientRegistration(Dictionary<Guid, Patient> dict, List<Patient> list)
    {
        string name = InputValidator.ReadNonEmptyString("Enter Name: ");
        string lastname = InputValidator.ReadNonEmptyString("Enter Lastname: ");
        int age = InputValidator.ReadNonNegativeInt("Enter Age: ");
        string symptom = InputValidator.ReadNonEmptyString("Enter Symptom: ");

   
        var patient = new Patient( name, lastname, age, symptom);
        Console.Write("Do you want to add pets for this patient? (Y/N): ");
        string addPetsResponse = Console.ReadLine();
        if (!string.IsNullOrEmpty(addPetsResponse) && addPetsResponse.Equals("Y", StringComparison.OrdinalIgnoreCase)) 
        {
            Console.WriteLine("\n--- Add Pets ---");
            bool addMorePets = true;
            while (addMorePets)
            {
                string petName = InputValidator.ReadNonEmptyString("Enter Pet Name: ");
                string species = InputValidator.ReadNonEmptyString("Enter Species: ");
                int petAge = InputValidator.ReadNonNegativeInt("Enter Pet Age: ");
                string breed = InputValidator.ReadNonEmptyString("Enter Breed: ");
                
                patient.Pets.Add(new Pet(petName, species, petAge, breed));
                Console.Write("Add another pet? (Y/N): ");
                string addAnother = Console.ReadLine();
                addMorePets = addAnother != null && addAnother.Equals("Y", StringComparison.OrdinalIgnoreCase);
            }
        }
        dict[patient.PatientId] = patient;
       // list.Add(patient);
        Console.WriteLine("\nPatient registered successfully.");
    }


    //Display all patients in a formatted manner.
    public static void PatientList(Dictionary<Guid, Patient> dict)
    {
        if (dict.Count == 0)
        {
            Console.WriteLine("\nNo patients registered.");
            return;
        }

        Console.WriteLine("\n--- Registered Patients ---\n");
        Console.WriteLine($"{"ID",-36} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Symptom",-30}");
        Console.WriteLine(new string('-', 75));
        foreach (var patient in dict.Values)
        {
            Console.WriteLine($"{patient.PatientId,-15} | {patient.Name,-15} | {patient.Lastname,-15} | {patient.PatientAge,-5} | {patient.Symptom,-30}");
            if (patient.Pets.Count > 0)
            {
                Console.WriteLine($"  Pets:");
                foreach (var pet in patient.Pets)
                    Console.WriteLine($"    - {pet.NamePet,-15} | {pet.Species,-15} | {pet.Breed,-15} | {pet.AgePet,-15} ");
            }
        }
    }

    //Search for patients by name and display their details.
    public static void PatientSearch(Dictionary<Guid, Patient> dict, string name)
    {
        var found = dict.Values
            .Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }

        Console.WriteLine($"\n--- Patients named '{name}' ---\n");
        Console.WriteLine($"{"ID",-36} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Symptom",-30}");
        Console.WriteLine(new string('-', 75));
        foreach (var patient in found)
        {
            Console.WriteLine($"{patient.PatientId,-15} | {patient.Name,-15} | {patient.Lastname,-15} | {patient.PatientAge,-5} | {patient.Symptom,-30}");
        }

    }

    //Delete a patient by name after confirmation.
    public static void DeletePatient(Dictionary<Guid, Patient> dict, List<Patient> list, string name)
    {
        var found = dict.Values
            .Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }

        Console.WriteLine("\nDo you want to delete these patient(s)? (Y/N): ");
        string confirm = Console.ReadLine();

        if (confirm != null && confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var patient in found)
            {
                dict.Remove(patient.PatientId);
                list.Remove(patient);
            }
            Console.WriteLine("\nPatient(s) deleted successfully.");
        }
        else
        {
            Console.WriteLine("\nDeletion cancelled.");
        }
    }

    public static void AddPetToPatient(Dictionary<Guid, Patient> dict )
    {
        Guid id = InputValidator.ReadGuid("Enter Patient ID: ");
        if (!dict.TryGetValue(id, out Patient patient))
        {
            Console.WriteLine("Patient not found.");
            return;
        }
        string petName = InputValidator.ReadNonEmptyString("Enter Pet Name: ");
        string species = InputValidator.ReadNonEmptyString("Enter Species: ");
        int petAge = InputValidator.ReadNonNegativeInt("Enter Pet Age: ");
        string breed = InputValidator.ReadNonEmptyString("Enter Breed: ");
        patient.Pets.Add(new Pet(petName, species, petAge, breed));
        Console.WriteLine("Pet added successfully.");
    }

    public static void UpdatePatient(Dictionary<Guid, Patient> dict, Guid id)
    {
        if (!dict.TryGetValue(id, out Patient patient))
        {
            Console.WriteLine("\nPatient not found.");
            return;
        }

        Console.WriteLine($"\n--- Updating Patient: {patient.Name} {patient.Lastname} ---\n");

        Console.WriteLine("Leave input empty to keep current value.\n");

        Console.Write($"Current Name: {patient.Name} | New Name: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
            patient.Name = newName;

        Console.Write($"Current Lastname: {patient.Lastname} | New Lastname: ");
        string newLastname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLastname))
            patient.Lastname = newLastname;

        Console.Write($"Current Age: {patient.PatientAge} | New Age: ");
        string newAgeInput = Console.ReadLine();
        if (int.TryParse(newAgeInput, out int newAge))
            patient.PatientAge = newAge;

        Console.Write($"Current Symptom: {patient.Symptom} | New Symptom: ");
        string newSymptom = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newSymptom))
            patient.Symptom = newSymptom;

        Console.WriteLine("\nPatient updated successfully.");
    }
}
