namespace ClinicaSalud.Models;

public class Patient
{
    // Private fields to store patient data securely
    private Guid _patientId;
    private string _patientName;
    private string _lastName;
    private int _age;
    private string _address;
    private string _email;

    // Constructor to initialize a new patient
    public Patient(string patientName, string lastName, int age, string address, string email)
    {
        _patientId = Guid.NewGuid(); // Unique identifier, generated automatically
        _patientName = patientName;
        _lastName = lastName;
        _age = age;
        _address = address;
        _email = email;
        Pets = new List<Pet>();
    }

    // Public read-only property for Patient ID
    public Guid PatientId => _patientId;

    // Public property for Patient Name with validation
    public string PatientName
    {
        get => _patientName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _patientName = value;
        }
    }

    // Public property for Last Name with validation
    public string LastnamePatient
    {
        get => _lastName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _lastName = value;
        }
    }

    // Public property for Age with positive value check
    public int AgePatient
    {
        get => _age;
        set
        {
            if (value > 0)
                _age = value;
        }
    }

    // Public property for Address with validation
    public string Address
    {
        get => _address;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _address = value;
        }
    }

    // Public property for Email with basic validation
    public string Email
    {
        get => _email;
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Contains("@"))
                _email = value;
        }
    }

    // List of pets belonging to the patient (read-only outside this class)
    public List<Pet> Pets { get; private set; }
}
