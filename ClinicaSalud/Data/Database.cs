using ClinicaSalud.Models;

namespace ClinicaSalud.Data;

public static class Database
{
    public static Dictionary<Guid, Patient> PatientDictionary = new Dictionary<Guid, Patient>();
    public static List<Patient> Patients = new List<Patient>();  
    
    public static Dictionary<Guid, Veterinarian> VeterinarianDictionary = new();
    public static List<Veterinarian> Veterinarians = new();

    //meter una  lista con las horas
    //agregar la logica para que las citas sean despues del dia actual
    // cuando se escoja la hora, lo resta para que no aparezca
    public static void Initializator()
    {
        // Add all patients to both containers
        var newPatient = new Patient("Juan", "Pérez", 30, "Calle Helm", "juan@email.com");
        var newPatient1 = new Patient("Juancho", "Pérez", 30, "Calle Helm", "juancho@email.com");
        var newPatient2 = new Patient("Juancha", "Pérez", 30, "Calle Helm", "juancha@email.com");

        Patients.Add(newPatient);
        Patients.Add(newPatient1);
        Patients.Add(newPatient2);

        PatientDictionary[newPatient.PatientId] = newPatient;
        PatientDictionary[newPatient1.PatientId] = newPatient1;
        PatientDictionary[newPatient2.PatientId] = newPatient2;
        
        
        var vet1 = new Veterinarian("Laura", "Martínez", 40, "Av. Central", "123456789fg","Cirugía","laura@vet.com");
        var vet2 = new Veterinarian("Carlos", "Gómez", 35, "Calle Sur", "9874654321fgg","Vacunación","carlos@vet.com");

        Veterinarians.AddRange(new[] { vet1, vet2 });

        VeterinarianDictionary[vet1.VeterinarianId] = vet1;
        VeterinarianDictionary[vet2.VeterinarianId] = vet2;
        
    }
    
}
    