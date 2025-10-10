
using ClinicaSalud.Interfaces;
using ClinicaSalud.Models;

namespace ClinicaSalud.Repositories;


public class AppointmentRepository : IAppointment
{
    private readonly List<Appointment> _appointments = new();

    public bool ScheduleAppointment(Appointment appointment)
    {
        // Verificar que no hay solapamiento con otras citas del mismo veterinario
        bool hasConflict = _appointments.Any(a =>
            a.Veterinarian.VeterinarianId == appointment.Veterinarian.VeterinarianId &&
            a.StartTime < appointment.EndTime &&
            appointment.StartTime < a.EndTime);

        if (hasConflict)
        {
            return false; // No se puede agendar, hay conflicto de horario
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


