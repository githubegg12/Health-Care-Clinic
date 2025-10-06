
using ClinicaSalud.Models;

namespace ClinicaSalud.Services;
public static class PatientLinqServices
{
    // Filter patients by minimum age
    public static IEnumerable<Patient> FilterByAge(Dictionary<int, Patient> dict, int minAge)
    {
        return dict.Values.Where(p => p.AgePatient >= minAge);
    }

    // Filter patients that have pets of a specific species
    public static IEnumerable<Patient> FilterByPetSpecies(Dictionary<int, Patient> dict, string species)
    {
        return dict.Values.Where(p => p.Pets.Any(pet => pet.Species.Equals(species, StringComparison.OrdinalIgnoreCase)));
    }

    // Project only patient names
    public static IEnumerable<string> GetPatientNames(Dictionary<int, Patient> dict)
    {
        return dict.Values.Select(p => p.PatientName);
    }

    // Order patients by name ascending
    public static IEnumerable<Patient> OrderByName(Dictionary<int, Patient> dict)
    {
        return dict.Values.OrderBy(p => p.PatientName);
    }

    // Order patients by age descending
    public static IEnumerable<Patient> OrderByAgeDescending(Dictionary<int, Patient> dict)
    {
        return dict.Values.OrderByDescending(p => p.AgePatient);
    }

    // Group patients by pet species
    public static IEnumerable<IGrouping<string, Patient>> GroupByPetSpecies(Dictionary<int, Patient> dict)
    {
        // Project patient-pet pairs and group by species
        var query = dict.Values
            .SelectMany(p => p.Pets.Select(pet => new { Patient = p, Species = pet.Species }))
            .GroupBy(x => x.Species, x => x.Patient);

        return query;
    }

    // Get the youngest patient
    public static Patient GetYoungestPatient(Dictionary<int, Patient> dict)
    {
        return dict.Values.OrderBy(p => p.AgePatient).FirstOrDefault();
    }

    // Get the oldest patient
    public static Patient GetOldestPatient(Dictionary<int, Patient> dict)
    {
        return dict.Values.OrderByDescending(p => p.AgePatient).FirstOrDefault();
    }

    // Count how many pets exist per species
    public static IEnumerable<(string Species, int Count)> CountPetsBySpecies(Dictionary<int, Patient> dict)
    {
        return dict.Values
            .SelectMany(p => p.Pets)
            .GroupBy(pet => pet.Species)
            .Select(g => (Species: g.Key, Count: g.Count()));
    }

    // Check if any patient has a pet without a breed defined
    public static bool AnyPetWithoutBreed(Dictionary<int, Patient> dict)
    {
        return dict.Values.Any(p => p.Pets.Any(pet => string.IsNullOrEmpty(pet.Breed)));
    }

    // List all patient names in uppercase, ordered alphabetically
    public static IEnumerable<string> GetPatientNamesUpperOrdered(Dictionary<int, Patient> dict)
    {
        return dict.Values
            .Select(p => p.PatientName.ToUpper())
            .OrderBy(name => name);
    }
}

