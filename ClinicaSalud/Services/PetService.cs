using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;
using ClinicaSalud.Repositories;

namespace ClinicaSalud.Services;

public class PetService
{
    // Adding Pet to a patient
    public static void AddPetToPatient()
    {
        Guid patientId = InputValidator.ReadGuid("Enter Patient ID: ");
        var patient = PatientRepository.GetById(patientId);

        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        Console.WriteLine("Adding pet to patient: " + patient.PatientName);

        string petName = InputValidator.ReadNonEmptyString("Enter Pet Name: ");
        string species = InputValidator.ReadNonEmptyString("Enter Species: ");
        int petAge = InputValidator.ReadNonNegativeInt("Enter Pet Age: ");
        string breed = InputValidator.ReadNonEmptyString("Enter Breed: ");
        string symptom = InputValidator.ReadNonEmptyString("Enter Symptom: ");

        var newPet = new Pet(petName, species, petAge, breed, symptom);
        patient.Pets.Add(newPet);

        Console.WriteLine("Pet added successfully.");
    }

    // Update patient's pet
    public static void UpdatePetOfPatient()
    {
        Guid patientId = InputValidator.ReadGuid("Enter Patient ID: ");
        var patient = PatientRepository.GetById(patientId);

        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        if (patient.Pets.Count == 0)
        {
            Console.WriteLine("This patient has no pets.");
            return;
        }

        Console.WriteLine("Pets:");
        foreach (var pet in patient.Pets)
        {
            Console.WriteLine($"- ID: {pet.PetId} | Name: {pet.PetName} | Species: {pet.Species}");
        }

        Guid petId = InputValidator.ReadGuid("Enter the ID of the pet to update: ");
        var petToUpdate = patient.Pets.FirstOrDefault(p => p.PetId == petId);

        if (petToUpdate == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        Console.WriteLine($"Updating pet: {petToUpdate.PetName}");

        string? newName = InputValidator.ReadOptionalValidatedString("New Pet Name: ",
            input => input.All(char.IsLetter), "Invalid name.");
        if (newName != null) petToUpdate.PetName = newName;

        string? newSpecies = InputValidator.ReadOptionalValidatedString("New Species: ",
            input => input.All(char.IsLetter), "Invalid species.");
        if (newSpecies != null) petToUpdate.Species = newSpecies;

        Console.Write("New Age (leave empty to keep current): ");
        string ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out int newAge))
        {
            petToUpdate.AgePet = newAge;
        }

        string? newBreed = InputValidator.ReadOptionalValidatedString("New Breed: ",
            input => !string.IsNullOrWhiteSpace(input), "Invalid breed.");
        if (newBreed != null) petToUpdate.Breed = newBreed;

        string? newSymptom = InputValidator.ReadOptionalValidatedString("New Symptom: ",
            input => !string.IsNullOrWhiteSpace(input), "Invalid symptom.");
        if (newSymptom != null) petToUpdate.Symptom = newSymptom;

        Console.WriteLine("Pet updated successfully.");
    }

    // Delete patient's pet
    public static void DeletePet()
    {
        Guid patientId = InputValidator.ReadGuid("Enter Patient ID: ");
        var patient = PatientRepository.GetById(patientId);

        if (patient == null)
        {
            Console.WriteLine("Patient not found.");
            return;
        }

        if (patient.Pets.Count == 0)
        {
            Console.WriteLine("This patient has no pets.");
            return;
        }

        Console.WriteLine("Pets:");
        foreach (var pet in patient.Pets)
        {
            Console.WriteLine($"- ID: {pet.PetId} | Name: {pet.PetName} | Species: {pet.Species}");
        }

        Guid petId = InputValidator.ReadGuid("Enter the ID of the pet to delete: ");
        var petToDelete = patient.Pets.FirstOrDefault(p => p.PetId == petId);

        if (petToDelete == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        if (InputValidator.ReadYesOrNo($"Are you sure you want to delete {petToDelete.PetName}? (Y/N): "))
        {
            patient.Pets.Remove(petToDelete);
            Console.WriteLine("Pet deleted successfully.");
        }
        else
        {
            Console.WriteLine("Deletion cancelled.");
        }
    }

    // Lista todas las mascotas junto con el nombre del paciente al que pertenecen
    public static void ListAllPets()
    {
        var patients = PatientRepository.GetPatientDictionary();

        if (patients.Count == 0)
        {
            Console.WriteLine("No patients registered.");
            return;
        }

        bool anyPets = false;

        foreach (var patient in patients.Values)
        {
            if (patient.Pets.Count == 0) continue;

            anyPets = true;
            Console.WriteLine($"Patient: {patient.PatientName} {patient.LastnamePatient}");

            foreach (var pet in patient.Pets)
            {
                Console.WriteLine($"  Pet ID: {pet.PetId}");
                Console.WriteLine($"  Name: {pet.PetName}");
                Console.WriteLine($"  Species: {pet.Species}");
                Console.WriteLine($"  Age: {pet.AgePet}");
                Console.WriteLine($"  Breed: {pet.Breed}");
                Console.WriteLine($"  Symptom: {pet.Symptom}");
                Console.WriteLine();
            }
        }

        if (!anyPets)
        {
            Console.WriteLine("No pets registered.");
        }
    }
}
