namespace ClinicaSalud.Models;

public class Pet
{
    // Private fields for pet data
    private string _petName;
    private string _species;
    private int _agePet;
    private string _breed;
    private string _symptom;

    // Constructor to initialize a new pet
    public Pet(string petName, string species, int agePet, string breed, string symptom)
    {
        _petName = petName;
        _species = species;
        _agePet = agePet;
        _breed = breed;
        _symptom = symptom;
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
}