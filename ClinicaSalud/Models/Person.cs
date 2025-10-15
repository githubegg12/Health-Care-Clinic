namespace ClinicaSalud.Models;
// Abstract base class representing a person
public abstract class Person
{
    // Private fields to store person data
    private string _firstName;
    private string _lastName;
    private int _age;
    private string _address;
    private string _email;

    // Constructor
    public Person(string firstName, string lastName, int age, string address, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Address = address;
        Email = email;
    }
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _lastName = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value > 0)
                _age = value;
        }
    }

    public string Address
    {
        get => _address;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _address = value;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Contains("@"))
                _email = value;
        }
    }
}


