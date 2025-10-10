using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories
{
    public class PatientRepository : IRegistrable<Patient>
    {
        public static Dictionary<Guid, Patient> GetPatientDictionary()
        {
            return Database.PatientDictionary;
        }

        public static void RemovePatient(Patient patient)
        {
            Database.Patients.Remove(patient);
            Database.PatientDictionary.Remove(patient.PatientId);
        }

        public static Patient? GetById(Guid id)
        {
            return Database.PatientDictionary.TryGetValue(id, out var patient) ? patient : null;
        }

        public static IEnumerable<Patient> SearchByName(string name)
        {
            return Database.PatientDictionary.Values
                .Where(p => p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        // Interface implementation 
        public Patient Register(Patient patient)
        {
            Database.Patients.Add(patient);
            Database.PatientDictionary[patient.PatientId] = patient;
            return patient;
        }
    }
}