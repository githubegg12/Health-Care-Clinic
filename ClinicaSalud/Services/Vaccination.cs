using ClinicaSalud.Interfaces;

namespace ClinicaSalud.Services;
public class Vaccination : IVetService
{
    public void Atender()
    {
        Console.WriteLine("Vaccination to patient...");
    }
}