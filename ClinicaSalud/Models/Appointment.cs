namespace ClinicaSalud.Models;

public class Appointment
{
    public Guid AppointmentId { get; private set; }
    public Veterinarian Veterinarian { get; private set; }
    public Pet Pet { get; private set; }
    public DateTime StartTime { get; internal set; }
    public DateTime EndTime { get; internal set; }

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
