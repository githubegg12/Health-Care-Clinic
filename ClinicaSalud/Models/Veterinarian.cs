namespace ClinicaSalud.Models;

public class Veterinarian : Person
{
    private Guid _veterinarianId;
    private string _licenseNumber;
    private string _specialty;
    public List<DateTime> AvailableSlots { get; private set; } = new ();

    public Veterinarian(string firstName, string lastName, int age, string address, string licenseNumber, string specialty,
        string email) : base(firstName, lastName, age, address,email)
    {
        _veterinarianId = Guid.NewGuid();
        _licenseNumber = licenseNumber;
        _specialty = specialty;
    }

    public Guid VeterinarianId => _veterinarianId;

    public string LicenseNumber
    {
        get => _licenseNumber;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _licenseNumber = value;
        }
    }
    public string Specialty
    {
        get => _specialty;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _specialty = value;
        }
    }
    
    public void AddAvailableSlot(DateTime slot)
    {
        if (!AvailableSlots.Contains(slot))
        {
            AvailableSlots.Add(slot);
        }
    }
}
