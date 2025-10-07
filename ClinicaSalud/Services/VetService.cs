namespace ClinicaSalud.Services;

public abstract class VetService
{
    public string ServiceName { get; set; }

    public VetService(string serviceName)
    {
        ServiceName = serviceName;
    }

    // Método abstracto que obliga a las subclases a implementarlo
    public abstract void Atender();
}
