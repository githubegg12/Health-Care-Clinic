using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories;

public class VeterinarianRepository : IRegistrable<Veterinarian>
{
    // Private field that holds an instance of IRegistrable<Patient>. This is used for patient registration.
    private IRegistrable<Patient> _registrableImplementation;
    
    public static Dictionary<Guid, Veterinarian> GetVeterinarianDictionary()
    {
        return Database.VeterinarianDictionary;
        }
    // Static method to remove a veterinarian from the system (both the list and the dictionary).
        public static void RemoveVeterinarian(Veterinarian vet)
        {
            Database.Veterinarians.Remove(vet);
            Database.VeterinarianDictionary.Remove(vet.VeterinarianId);
        }
        // Static method to retrieve a veterinarian by their ID.
        // If the veterinarian exists in the dictionary, it returns them; otherwise, it returns null.
        public static Veterinarian? GetById(Guid id)
        {
            return Database.VeterinarianDictionary.TryGetValue(id, out var veterinarian) ? veterinarian : null;
        }
        // Static method to search veterinarians by their first name. 
        // Returns a list of veterinarians whose first name contains the given search term, case-insensitive.
        public static IEnumerable<Veterinarian> SearchByName(string name)
        {
            return Database.VeterinarianDictionary.Values
                .Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        // Interface implementation 
        public Veterinarian Register(Veterinarian vet)
        {
            Database.Veterinarians.Add(vet);
            Database.VeterinarianDictionary[vet.VeterinarianId] = vet;
            return vet;
        }
}
