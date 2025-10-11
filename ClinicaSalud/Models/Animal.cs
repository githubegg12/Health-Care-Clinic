namespace ClinicaSalud.Models;


// Abstract base class representing a generic animal (pet)
public abstract class Animal
{
    private string _petName;
    private string _species;
    private int _agePet;

    // Constructor to initialize the animal with name, species, and age
    public Animal(string petName, string species, int agePet)
    {
        PetName = petName;
        Species = species;
        AgePet = agePet;
    }
    
    // Public property for Pet Name with validation
    public string PetName
    {
        get => _petName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _petName = value;
        }
    }

    // Public property for Species with validation
    public string Species
    {
        get => _species;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _species = value;
        }
    }

    // Public property for Age with positive value check
    public int AgePet
    {
        get => _agePet;
        set
        {
            if (value > 0)
                _agePet = value;
        }
    }
    // Virtual method that can be overridden by subclasses to produce a specific sound
    public virtual void MakeNoice()
    {
        Console.WriteLine($"{PetName} hace un sonido genérico.");
    }
}