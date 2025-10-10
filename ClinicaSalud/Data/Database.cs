using ClinicaSalud.Models;

namespace ClinicaSalud.Data;

public static class Database
{
    // Dictionary and list to store patients
    public static Dictionary<Guid, Patient> PatientDictionary = new Dictionary<Guid, Patient>();
    public static List<Patient> Patients = new List<Patient>();  

    // Dictionary and list to store veterinarians
    public static Dictionary<Guid, Veterinarian> VeterinarianDictionary = new();
    public static List<Veterinarian> Veterinarians = new();

    // Central list to store all appointments
    public static List<Appointment> Appointments = new List<Appointment>();

    public static void Initializator()
    {
        // Adding some sample patients
        var newPatient = new Patient("Juan", "Pérez", 30, "Calle Helm", "juan@email.com");
        var newPatient1 = new Patient("Juancho", "Pérez", 30, "Calle Helm", "juancho@email.com");
        var newPatient2 = new Patient("Juancha", "Pérez", 30, "Calle Helm", "juancha@email.com");
        
        var pet1 = new Pet("Firulais", "Perro", 5, "Labrador", "Dolor de estómago");
        var pet2 = new Pet("Misu", "Gato", 3, "Siames", "Estornudos");
        var pet3 = new Pet("Bobby", "Perro", 2, "Bulldog", "Cojea de la pata");

        newPatient.Pets.Add(pet1);
        newPatient1.Pets.Add(pet2);
        newPatient1.Pets.Add(pet3);

        // Agregar pacientes a la lista y diccionario
        Patients.Add(newPatient);
        Patients.Add(newPatient1);
        Patients.Add(newPatient2);
        
        PatientDictionary[newPatient.PatientId] = newPatient;
        PatientDictionary[newPatient1.PatientId] = newPatient1;
        PatientDictionary[newPatient2.PatientId] = newPatient2;

        // Adding sample veterinarians
        var vet1 = new Veterinarian("Laura", "Martínez", 40, "Av. Central", "123456789fg", "Surgery", "laura@vet.com");
        var vet2 = new Veterinarian("Carlos", "Gómez", 35, "Calle Sur", "9874654321fgg", "Vaccination", "carlos@vet.com");

        Veterinarians.AddRange(new[] { vet1, vet2 });

        VeterinarianDictionary[vet1.VeterinarianId] = vet1;
        VeterinarianDictionary[vet2.VeterinarianId] = vet2;

        // Adding available time slots for each veterinarian (next 5 days, 8 AM to 4 PM)
        foreach (var vet in Veterinarians)
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
        
        
        // Initialize the appointments list as empty
        Appointments = new List<Appointment>();
    }
}

