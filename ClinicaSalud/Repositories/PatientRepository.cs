using ClinicaSalud.Data;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories
{
    public static class PatientRepository
    {
        public static Dictionary<Guid, Patient> GetPatientDictionary()
        {
            return Database.patientDictionary;
        }

        public static List<Patient> GetPatients()
        {
            return Database.patients;
        }

        public static void AddPatient(Patient patient)
        {
            Database.patients.Add(patient);
            Database.patientDictionary[patient.PatientId] = patient;
        }

        public static void RemovePatient(Patient patient)
        {
            Database.patients.Remove(patient);
            Database.patientDictionary.Remove(patient.PatientId);
        }

        public static Patient? GetById(Guid id)
        {
            return Database.patientDictionary.TryGetValue(id, out var patient) ? patient : null;
        }

        public static IEnumerable<Patient> SearchByName(string name) //
        {
            return Database.patientDictionary.Values
                .Where(p => p.PatientName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
