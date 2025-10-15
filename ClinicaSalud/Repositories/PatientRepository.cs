using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories;

public class PatientRepository : IRegistrable<Patient>
{
    // Returns the dictionary of patients from the database
    public static Dictionary<Guid, Patient> GetPatientDictionary()
    {
        return Database.PatientDictionary;
    }

    // Removes a patient from both the list and dictionary
    public static void RemovePatient(Patient patient)
    {
        Database.Patients.Remove(patient);
        Database.PatientDictionary.Remove(patient.PatientId);
    }

    // Get patient by ID, returns null if not found
    public static Patient? GetById(Guid id)
    {
        return Database.PatientDictionary.TryGetValue(id, out var patient) ? patient : null;
    }

    // Search patients by first name (case insensitive)
    public static IEnumerable<Patient> SearchByName(string name)
    {
        return Database.PatientDictionary.Values
            .Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    // Implementation of the interface method to register a patient
    public Patient Register(Patient patient)
    {
        Database.Patients.Add(patient);
        Database.PatientDictionary[patient.PatientId] = patient;
        return patient;
    }
}
