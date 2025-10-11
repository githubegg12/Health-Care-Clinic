namespace ClinicaSalud.Models;
// Represents a patient, inheriting from Person
public class Patient : Person
{
    private Guid _patientId;

    // Constructor initializes patient details and creates a new unique ID
    // Also initializes the list of pets for this patient
    public Patient(string firstName, string lastName, int age, string address, string email)
        : base(firstName, lastName, age, address, email)
    {
        _patientId = Guid.NewGuid();
        Pets = new List<Pet>();
    }

    public Guid PatientId => _patientId;

    public List<Pet> Pets { get; private set; }
    
}
