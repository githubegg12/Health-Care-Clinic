using System.Text.RegularExpressions;
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;
using ClinicaSalud.Repositories;

namespace ClinicaSalud.Services;

public class PatientService 
{   
    private static readonly IRegistrable<Patient> _registrable = new PatientRepository();
    //Request data through the console and add a new patient to the list.
    public static void PatientRegistration()
    {
        string name = InputValidator.ReadNonEmptyString("Enter Name: ");
        string lastname = InputValidator.ReadNonEmptyString("Enter Lastname: ");
        int age = InputValidator.ReadNonNegativeInt("Enter Age: ");
        string address = InputValidator.ReadAlphanumericString("Enter address: ");
        string email = InputValidator.ReadEmail("Enter email: ");

   
        var patient = new Patient( name, lastname, age, address, email);
        if (InputValidator.ReadYesOrNo("Do you want to add pets for this patient? (Y/N): "))
        {
            Console.WriteLine("\n--- Add Pets ---");
            bool addMorePets = true;
            while (addMorePets)
            {
                string petName = InputValidator.ReadNonEmptyString("Enter Pet Name: ");
                string species = InputValidator.ReadNonEmptyString("Enter Species: ");
                int petAge = InputValidator.ReadNonNegativeInt("Enter Pet Age: ");
                string breed = InputValidator.ReadNonEmptyString("Enter Breed: ");
                string symptom = InputValidator.ReadNonEmptyString("Enter Symptom: ");
                
                
                var newPet = new Pet(petName, species, petAge, breed, symptom);
                patient.Pets.Add(newPet);
                newPet.MakeNoice();
                addMorePets = InputValidator.ReadYesOrNo("Add another pet? (Y/N): ");
            }
        }

        _registrable.Register(patient);
        //PatientRepository.AddPatient(patient);        
        //dict[patient.PatientId] = patient;
        //list.Add(patient);
        Console.WriteLine("\nPatient registered successfully.");
    }


    //Display all patients in a formatted manner.
    public static void PatientList()
    {
        var dict = PatientRepository.GetPatientDictionary();

        if (dict.Count == 0)
        {
            Console.WriteLine("\nNo patients registered.");
            return;
        }

        Console.WriteLine("\n--- Registered Patients ---\n");
        Console.WriteLine($"{"ID",-36} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Address",-25} | {"Email",-25}");
        Console.WriteLine(new string('-', 140));
        foreach (var patient in dict.Values)
        {
            Console.WriteLine($"{patient.PatientId,-15} | {patient.PatientName,-15} | {patient.LastnamePatient,-15} | {patient.AgePatient,-5} | {patient.Address,-25} | {patient.Email,-25}");
            if (patient.Pets.Count > 0)
            {
                Console.WriteLine($"  Pets:");
                foreach (var pet in patient.Pets)
                    Console.WriteLine($"    - {pet.PetName,-15} | {pet.Species,-15} | {pet.Breed,-15} | {pet.AgePet,-15} | {pet.Symptom,-15}");
            }
        }
    }

    //Search for patients by name and display their details.
    public static void PatientSearch(string name)
    {
        var found = PatientRepository.SearchByName(name).ToList();
        // var found = dict.Values
        //     .Where(p => p.PatientName.Equals(name, StringComparison.OrdinalIgnoreCase))
        //     .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }

        Console.WriteLine($"\n--- Patients named '{name}' ---\n");
        Console.WriteLine($"{"ID",-36} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Symptom",-30}");
        Console.WriteLine(new string('-', 140));
        foreach (var patient in found)
        {
            Console.WriteLine($"{patient.PatientId,-15} | {patient.PatientName,-15} | {patient.LastnamePatient,-15} | {patient.AgePatient,-5} | {patient.Address,-30} | {patient.Email,-30}");
        }

    }

    //Delete a patient by name after confirmation.
    public static void DeletePatient(string name)
    {
        var found = PatientRepository.SearchByName(name).ToList();
        // var found = dict.Values
        //     .Where(p => p.PatientName.Equals(name, StringComparison.OrdinalIgnoreCase))
        //     .ToList();

        if (found.Count == 0)
        {
            Console.WriteLine($"\nNo patient found with name '{name}'.");
            return;
        }

        if (InputValidator.ReadYesOrNo("Do you want to delete these patient(s)? (Y/N): "))
        {
            foreach (var patient in found)
            {
                PatientRepository.RemovePatient(patient);
                // dict.Remove(patient.PatientId);
                // list.Remove(patient);
            }
            Console.WriteLine("\nPatient deleted successfully.");
        }
        else
        {
            Console.WriteLine("\nDeletion cancelled.");
        }
    }
   //To add a pet into a specific patient

    //To update Patient information
    public static void UpdatePatient(Dictionary<Guid, Patient> dict, Guid id)
    {
        var patient = PatientRepository.GetById(id);
        if (patient == null)
        {
            Console.WriteLine("\nPatient not found.");
            return;
        }

        Console.WriteLine($"\n--- Updating Patient: {patient.PatientName} {patient.LastnamePatient} ---\n");

        Console.WriteLine("Leave input empty to keep current value.\n");
        
        string? newName = InputValidator.ReadOptionalValidatedString(
            $"Current Name: {patient.PatientName} | New Name: ",
                input => input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)),
                "Invalid name. Name not updated."
            );
        if (newName != null)
            patient.PatientName = newName;

        Console.Write($"Current Lastname: {patient.LastnamePatient} | New Lastname: ");
        string newLastname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLastname))
            patient.LastnamePatient = newLastname;

        Console.Write($"Current Age: {patient.AgePatient} | New Age: ");
        string newAgeInput = Console.ReadLine();
        if (int.TryParse(newAgeInput, out int newAge))
            patient.AgePatient = newAge;

        Console.Write($"Current Address: {patient.Address} | New Address: ");
        string newAddress = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAddress))
            patient.Address = newAddress;
        
        string? newEmail = InputValidator.ReadOptionalValidatedString(
            $"Current Email: {patient.Email} | New Email: ",
            input => Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
            "Invalid email format. Email not updated."
        );
        if (newEmail != null)
            patient.Email = newEmail;

        Console.WriteLine("\nPatient updated successfully.");
    }
    
}
