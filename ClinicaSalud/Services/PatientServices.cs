

using ClinicaSalud.Models;
namespace ClinicaSalud.Services;

public class PatientServices
{
    //Request data through the console and add a new patient to the list.
    public static void PatientRegistration(List<Patient> list)
    {
        int id = InputValidator.ReadNonNegativeInt("Enter Patient ID: ");
        string name = InputValidator.ReadNonEmptyString("Enter Name: ");
        string lastname = InputValidator.ReadNonEmptyString("Enter Lastname: ");
        int age = InputValidator.ReadNonNegativeInt("Enter Age: ");
        string symptom = InputValidator.ReadNonEmptyString("Enter Symptom: ");

        Patient newPatient = new Patient
        {
            Id = id,
            Name = name,
            Lastname = lastname,
            Age = age,
            Symptom = symptom
        };

        list.Add(newPatient);
        Console.WriteLine("\nPatient registered successfully.");
    }


    //Display all patients in a formatted manner.
    public static void PatientList(List<Patient> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("\nNo patients registered.");
            return;
        }

        Console.WriteLine("\n--- Registered Patients ---\n");
        Console.WriteLine($"{"ID",-10} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Symptom",-30}");
        Console.WriteLine(new string('-', 75));
        foreach (var patient in list)
        {
            Console.WriteLine($"{patient.Id,-10} | {patient.Name,-15} | {patient.Lastname,-15} | {patient.Age,-5} | {patient.Symptom,-30}");
        }
    }

    //Search for patients by name and display their details.
    public static void PatientSearch(List<Patient> list, string name)
    {
        var found = list
               .Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
               .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }

        Console.WriteLine($"\n--- Patients named '{name}' ---\n");
        Console.WriteLine($"{"ID",-10} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Symptom",-30}");
        Console.WriteLine(new string('-', 75));
        foreach (var patient in found)
        {
            Console.WriteLine($"{patient.Id,-10} | {patient.Name,-15} | {patient.Lastname,-15} | {patient.Age,-5} | {patient.Symptom,-30}");
        }

    }

    //Delete a patient by name after confirmation.
    public static void DeletePatient(List<Patient> list, string name)
    {
        var found = list
               .Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
               .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }
        Console.WriteLine("\nDo you want to delete these patient(s)? (Y/N): ");
        string confirm = Console.ReadLine();

        if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var patient in found)
            {
                list.Remove(patient);
            }
            Console.WriteLine("\nPatient(s) deleted successfully.");
        }
        else
        {
            Console.WriteLine("\nDeletion cancelled.");
        }
    }

}
