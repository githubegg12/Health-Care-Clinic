namespace ClinicaSalud.Services;
public class Vaccination : VetService
{
    public Vaccination() : base("Vaccine"){}
    public override void Atender()
    {
        Console.WriteLine("Vaccination to patient...");
    }

}