using ClinicaSalud.Models;

namespace ClinicaSalud.Data;

public static class Database
{
    public static Dictionary<Guid, Patient> patientDictionary = new Dictionary<Guid, Patient>();
    public static List<Patient> patients = new List<Patient>();

    public static void initializator()
    {
        // Add all patients to both containers
        var newPatient = new Patient("Juan", "Pérez", 30, "Calle Helm", "juan@email.com");
        var newPatient1 = new Patient("Juancho", "Pérez", 30, "Calle Helm", "juancho@email.com");
        var newPatient2 = new Patient("Juancha", "Pérez", 30, "Calle Helm", "juancha@email.com");

        patients.Add(newPatient);
        patients.Add(newPatient1);
        patients.Add(newPatient2);

        patientDictionary[newPatient.PatientId] = newPatient;
        patientDictionary[newPatient1.PatientId] = newPatient1;
        patientDictionary[newPatient2.PatientId] = newPatient2;
    }
}
    