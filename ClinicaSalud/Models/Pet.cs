namespace ClinicaSalud.Models;

public class Pet(string petName, string species, int petAge)
{
    public string Name { get; set; } = petName;
    public string Species { get; set; } = species;
    public int Age { get; set; } = petAge;
    
}    