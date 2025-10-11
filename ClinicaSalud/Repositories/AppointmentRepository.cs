using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;
using ClinicaSalud.Data;


namespace ClinicaSalud.Repositories;

public class AppointmentRepository : IAppointment
{
    // Use the centralized appointments list from Database
    // // This property provides access to the list of appointments stored in the Database.
    private List<Appointment> _appointments => Database.Appointments;

    // Method to schedule a new appointment.
    public bool ScheduleAppointment(Appointment appointment)
    {
        // Check for scheduling conflicts with other appointments for the same veterinarian
        bool hasConflict = _appointments.Any(a =>
            a.Veterinarian.VeterinarianId == appointment.Veterinarian.VeterinarianId &&
            a.StartTime < appointment.EndTime &&
            appointment.StartTime < a.EndTime);

        if (hasConflict)
        {
            return false; // Scheduling conflict exists
        }

        _appointments.Add(appointment);
        return true;
    }
    
    // Method to cancel an appointment using its unique appointment ID.
    public bool CancelAppointment(Guid appointmentId)
    {
        var appointment = _appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
        if (appointment == null) return false;

        _appointments.Remove(appointment);
        return true;
    }
    
    // Method to retrieve an appointment by its unique appointment ID.
    public Appointment? GetAppointmentById(Guid appointmentId)
    {
        return _appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
    }
    
    // Method to retrieve all appointments for a specific veterinarian within a given date range.
    public IEnumerable<Appointment> GetAppointmentsForVeterinarian(Guid veterinarianId, DateTime start, DateTime end)
    {
        return _appointments.Where(a =>
                a.Veterinarian.VeterinarianId == veterinarianId &&
                a.StartTime >= start &&
                a.EndTime <= end)
            .OrderBy(a => a.StartTime);
    }
}
