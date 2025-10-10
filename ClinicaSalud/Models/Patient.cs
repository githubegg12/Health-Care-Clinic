namespace ClinicaSalud.Models;

public class Patient : Person
{
    private Guid _patientId;

    public Patient(string firstName, string lastName, int age, string address, string email)
        : base(firstName, lastName, age, address, email)
    {
        _patientId = Guid.NewGuid();
        Pets = new List<Pet>();
    }

    public Guid PatientId => _patientId;

    public List<Pet> Pets { get; private set; }
    
}
