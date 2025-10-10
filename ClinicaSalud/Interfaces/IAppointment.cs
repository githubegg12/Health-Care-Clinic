using ClinicaSalud.Models;

namespace ClinicaSalud.Interfaces;

public interface IAppointment
{
    // Create an appointment
    bool ScheduleAppointment(Appointment appointment);

    // Cancel an appointment
    bool CancelAppointment(Guid appointmentId);

    // Get an appointment using Guid
    Appointment? GetAppointmentById(Guid appointmentId);

    // List all appointment
    IEnumerable<Appointment> GetAppointmentsForVeterinarian(Guid veterinarianId, DateTime start, DateTime end);
}

