namespace ClinicaSalud.Models;

//Include basic properties: Id (int), Name (string), Age (int), Symptom (string).
public class Patient (int id, string name, string lastname, int age, string symptom)
{
    
    //Use auto-implemented properties:
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string? Lastname { get; set; } = lastname;
    public int Age { get; set; } = age;
    public string Symptom { get; set; } = symptom;
    
}

