namespace ClinicaSalud.Services;

public class GeneralConsultation : VetService
{
    public GeneralConsultation() : base("General Consultation"){}
    public override void Atender()
    {
        Console.WriteLine("Realizando consulta general al paciente...");
    }
}