namespace ClinicaSalud.Models;

//Include basic properties: Id (int), Name (string), Age (int), Symptom (string).
public class Patient (string name, string lastname, int patientAge, string symptom)
{
    //Use auto-implemented properties:
    public Guid PatientId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string Lastname { get; set; } = lastname;
    public int PatientAge { get; set; } = patientAge;
    public string Symptom { get; set; } = symptom;
    public List<Pet> Pets { get; set; } = new();
}

