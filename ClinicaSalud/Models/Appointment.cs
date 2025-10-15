namespace ClinicaSalud.Models;

// Represents an appointment between a veterinarian and a pet
public class Appointment
{
    public Guid AppointmentId { get; private set; }
    public Veterinarian Veterinarian { get; private set; }
    public Pet Pet { get; private set; }
    public DateTime StartTime { get; internal set; }
    public DateTime EndTime { get; internal set; }

    // Constructor to create an appointment with veterinarian, pet, start time, and end time
    // Throws an exception if the end time is not after the start time
    public Appointment(Veterinarian veterinarian, Pet pet, DateTime startTime, DateTime endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time");

        AppointmentId = Guid.NewGuid();
        Veterinarian = veterinarian;
        Pet = pet;
        StartTime = startTime;
        EndTime = endTime;
    }

}
