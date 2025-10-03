namespace ClinicaSalud.Models;

//Include basic properties: Id (int), Name (string), Age (int), Symptom (string).
public class Patient 
{
    
    //Use auto-implemented properties:
    private static int _nextId = 0;
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string? Lastname { get; set; } 
    public int Age { get; set; } 
    public string Symptom { get; set; } 
    public List<Pet> Pets { get; set; } = new();

    public Patient(string name, string lastname, int age, string symptom)
    {
        _nextId++;
        Id= _nextId;
        Name= name;
        Lastname= lastname;
        Age= age;
        Symptom= symptom;
    }
}

