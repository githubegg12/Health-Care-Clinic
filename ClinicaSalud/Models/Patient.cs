namespace ClinicaSalud.Models;

//Include basic properties: Id (int), Nombre (string), Edad (int), Sintoma (string).
public class Patient
{
    //Use auto-implemented properties:
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
    public required string Symptom { get; set; }
}