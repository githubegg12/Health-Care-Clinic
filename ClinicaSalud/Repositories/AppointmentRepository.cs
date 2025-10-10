using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;
using ClinicaSalud.Data;


namespace ClinicaSalud.Repositories;

public class AppointmentRepository : IAppointment
{
    // Use the centralized appointments list from Database
    private List<Appointment> _appointments => Database.Appointments;

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

    public bool CancelAppointment(Guid appointmentId)
    {
        var appointment = _appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
        if (appointment == null) return false;

        _appointments.Remove(appointment);
        return true;
    }

    public Appointment? GetAppointmentById(Guid appointmentId)
    {
        return _appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
    }

    public IEnumerable<Appointment> GetAppointmentsForVeterinarian(Guid veterinarianId, DateTime start, DateTime end)
    {
        return _appointments.Where(a =>
                a.Veterinarian.VeterinarianId == veterinarianId &&
                a.StartTime >= start &&
                a.EndTime <= end)
            .OrderBy(a => a.StartTime);
    }
}
