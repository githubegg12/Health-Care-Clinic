using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories;

public class VeterinarianRepository : IRegistrable<Veterinarian>
{
    
    private IRegistrable<Patient> _registrableImplementation;
    
    public static Dictionary<Guid, Veterinarian> GetVeterinarianDictionary()
    {
        return Database.VeterinarianDictionary;
        }

        public static void RemoveVeterinarian(Veterinarian vet)
        {
            Database.Veterinarians.Remove(vet);
            Database.VeterinarianDictionary.Remove(vet.VeterinarianId);
        }

        public static Veterinarian? GetById(Guid id)
        {
            return Database.VeterinarianDictionary.TryGetValue(id, out var veterinarian) ? veterinarian : null;
        }

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

        // public Patient Register(Patient patient)
        // {
        //     return _registrableImplementation.Register(patient);
        // }
}
