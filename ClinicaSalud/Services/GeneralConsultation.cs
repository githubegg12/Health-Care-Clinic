namespace ClinicaSalud.Services;

public class GeneralConsultation : VetService
{
    public GeneralConsultation() : base("General Consult"){}
    public override void Atender()
    {
        Console.WriteLine("Doing a general consult to patiente...");
    }
}