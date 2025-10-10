using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;
using ClinicaSalud.Repositories;

namespace ClinicaSalud.Services;

public static class VeterinarianService
{
    private static readonly IRegistrable<Veterinarian> Registrable = new VeterinarianRepository();

    public static void RegisterVeterinarian()
    {
        try
        {
            string firstName = InputValidator.ReadNonEmptyString("Enter First Name: ");
            string lastName = InputValidator.ReadNonEmptyString("Enter Last Name: ");
            int age = InputValidator.ReadNonNegativeInt("Enter Age: ");
            string address = InputValidator.ReadAlphanumericString("Enter Address : ");
            string licensenumber = InputValidator.ReadAlphanumericString("Enter License Number : ");
            string email = InputValidator.ReadEmail("Enter Email: ");
            string specialty = InputValidator.ReadNonEmptyString("Enter Specialty: ");

            var vet = new Veterinarian(firstName, lastName, age, address, licensenumber, specialty, email);
            Registrable.Register(vet);
            
            AssignDefaultSlotsToVeterinarian(vet);

            Console.WriteLine("\nVeterinarian registered successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nRegistration canceled by user.");
        }
    }

    public static void ListVeterinarians()
    {
        var vets = VeterinarianRepository.GetVeterinarianDictionary();

        if (vets.Count == 0)
        {
            Console.WriteLine("\nNo veterinarians registered.");
            return;
        }

        Console.WriteLine("\n--- Registered Veterinarians ---\n");
        Console.WriteLine($"{"ID",-36} | {"Name",-15} | {"Lastname",-15} | {"Age",-5} | {"Adress",-20} | {"Specialty",-20} | {"Email",-25}");
        Console.WriteLine(new string('-', 125));
        foreach (var vet in vets.Values)
        {
            Console.WriteLine($"{vet.VeterinarianId,-36} | {vet.FirstName,-15} | {vet.LastName,-15} | {vet.Age,-5} | {vet.Address,-20} | {vet.Specialty,-20} | {vet.Email,-25}");
        }
    }

    public static void SearchVeterinarian()
    {
        try
        {
            string name = InputValidator.ReadNonEmptyString("Enter Veterinarian Name to Search: ");
            var found = VeterinarianRepository.SearchByName(name).ToList();

            if (found.Count == 0)
            {
                Console.WriteLine("No veterinarian found with that name.");
                return;
            }

            Console.WriteLine($"\n--- Results for '{name}' ---\n");
            foreach (var vet in found)
            {
                Console.WriteLine($"ID: {vet.VeterinarianId}");
                Console.WriteLine($"Name: {vet.FirstName} {vet.LastName}");
                Console.WriteLine($"Specialty: {vet.Specialty}");
                Console.WriteLine($"Email: {vet.Email}");
                Console.WriteLine();
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nSearch canceled by user.");
        }
    }

    public static void UpdateVeterinarian()
    {
        try
        {
            Guid id = InputValidator.ReadGuid("Enter Veterinarian ID to Update: ");
            var vet = VeterinarianRepository.GetById(id);

            if (vet == null)
            {
                Console.WriteLine("Veterinarian not found.");
                return;
            }

            Console.WriteLine("\nLeave blank to keep current value.\n");

            string? newFirstName = InputValidator.ReadOptionalValidatedString($"Current: {vet.FirstName} | New First Name: ",
                input => input.All(char.IsLetter), "Invalid name.");
            if (newFirstName != null) vet.FirstName = newFirstName;

            string? newLastName = InputValidator.ReadOptionalValidatedString($"Current: {vet.LastName} | New Last Name: ",
                input => input.All(char.IsLetter), "Invalid last name.");
            if (newLastName != null) vet.LastName = newLastName;

            Console.Write($"Current Age: {vet.Age} | New Age: ");
            string? ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int newAge)) vet.Age = newAge;

            Console.Write($"Current Address: {vet.Address} | New Address: ");
            string? newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress)) vet.Address = newAddress;

            Console.Write($"Current Email: {vet.Email} | New Email: ");
            string? newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail)) vet.Email = newEmail;

            Console.Write($"Current Specialty: {vet.Specialty} | New Specialty: ");
            string? newSpecialty = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newSpecialty)) vet.Specialty = newSpecialty;

            Console.WriteLine("\nVeterinarian updated successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nUpdate canceled by user.");
        }
    }

    public static void DeleteVeterinarian()
    {
        try
        {
            Guid id = InputValidator.ReadGuid("Enter Veterinarian ID to Delete: ");
            var vet = VeterinarianRepository.GetById(id);

            if (vet == null)
            {
                Console.WriteLine("Veterinarian not found.");
                return;
            }

            if (InputValidator.ReadYesOrNo($"Are you sure you want to delete Dr. {vet.FirstName} {vet.LastName}? (Y/N): "))
            {
                VeterinarianRepository.RemoveVeterinarian(vet);
                Console.WriteLine("Veterinarian deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nDeletion canceled by user.");
        }
    }
    
    public static void AssignDefaultSlotsToVeterinarian(Veterinarian vet)
    {
        for (int day = 0; day < 5; day++)
        {
            for (int hour = 8; hour < 17; hour++)
            {
                var slot = DateTime.Today.AddDays(day).AddHours(hour);
                if (slot > DateTime.Now)
                {
                    vet.AddAvailableSlot(slot);
                }
            }
        }
    }

}
