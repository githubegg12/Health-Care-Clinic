namespace ClinicaSalud.Models;

public class Pet(string namePet, string species, int agePet, string breed )
{
    public string NamePet { get; set; } = namePet;
    public string Species { get; set; } = species;
    public int AgePet { get; set; } = agePet;
    public string Breed { get; set; } = breed;
}    