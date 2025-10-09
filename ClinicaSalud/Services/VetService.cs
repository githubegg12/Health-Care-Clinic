namespace ClinicaSalud.Services;

public abstract class VetService
{
    public string ServiceName { get; private set; }

    public VetService(string serviceName)
    {
        ServiceName = serviceName;
    }

    // Abstract method to force subclasses to use it
    public abstract void Atender();
}
