namespace ClinicaSalud.Models;

public class Pet : Animal
{
    // Private fields for pet data
    private string _breed;
    private string _symptom;

    // Constructor to initialize a new pet
    public Pet(string petName, string species, int agePet, string breed, string symptom) : base(petName, species, agePet)
    {
        _breed = breed;
        _symptom = symptom;
    }
    
    // Public property for Breed with validation
    public string Breed
    {
        get => _breed;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _breed = value;
        }
    }

    // Public property for Symptom with validation
    public string Symptom
    {
        get => _symptom;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _symptom = value;
        }
    }

    
    // 
    public override void MakeNoice()
    {
        switch (Species.ToLower())
        {
            case "perro":
                Console.WriteLine($"{PetName} say: Guau!");
                break;
            case "gato":
                Console.WriteLine($"{PetName} say: Miau!");
                break;
            case "pajaro":
                Console.WriteLine($"{PetName} say: Pío!");
                break;
            default:
                Console.WriteLine($"We could not identified {PetName}'s specie .");
                break;
        }
    }
}