using ClinicaSalud.Models;
using ClinicaSalud.Repositories;
using ClinicaSalud.Data;

namespace ClinicaSalud.Services;
// AppointmentService class is responsible for handling the appointment logic,
// including getting available slots, scheduling, updating, and canceling appointments.
public class AppointmentService
{
    // Private field to store the instance of the appointment repository for accessing appointment data.
    private readonly AppointmentRepository _appointmentRepository;
    // Constructor to initialize the AppointmentService with the appointment repository.
    public AppointmentService(AppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    // Method to get available slots for a given veterinarian.
    // It checks the vet's available slots and removes any that are already booked or in the past.
    public List<DateTime> GetAvailableSlots(Guid veterinarianId)
    {
        var vet = Database.VeterinarianDictionary[veterinarianId];
        var bookedSlots = _appointmentRepository
            .GetAppointmentsForVeterinarian(veterinarianId, DateTime.Now, DateTime.MaxValue)
            .Select(a => a.StartTime)
            .ToHashSet();

        // Vet's available slots that are not yet booked and are in the future
        return vet.AvailableSlots
            .Where(slot => slot > DateTime.Now && !bookedSlots.Contains(slot))
            .OrderBy(slot => slot)
            .ToList();
    }

    // Schedule a new appointment
    public bool ScheduleNewAppointment(Guid veterinarianId, Guid petId, DateTime startTime)
    {
        // Calculate appointment end time (e.g., 1 hour duration)
        var endTime = startTime.AddHours(1);

        // Get the vet and pet objects
        if (!Database.VeterinarianDictionary.TryGetValue(veterinarianId, out var vet))
            return false;

        // Find the pet in any patient
        Pet? pet = null;
        foreach (var patient in Database.Patients)
        {
            pet = patient.Pets.FirstOrDefault(p => p.PetId == petId);
            if (pet != null) break;
        }
        if (pet == null)
            return false;

        var appointment = new Appointment(vet, pet, startTime, endTime);

        return _appointmentRepository.ScheduleAppointment(appointment);
    }
    // Method to display all scheduled appointments in the system.
    public void ShowAllAppointments()
    {
        // Retrieve all appointments from the database.
        var appointments = Database.Appointments;
        // Check if there are no appointments scheduled.
        if (appointments.Count == 0)
        {
            Console.WriteLine("\nNo appointments scheduled.");
            return;
        }
        // Display a header for the appointments list.
        Console.WriteLine("\n--- All Scheduled Appointments ---\n");
        Console.WriteLine(
            $"{"Appointment ID",-36} | {"Vet Name",-25} | {"Pet Name",-15} | {"Start Time",-20} | {"End Time",-20}");
        Console.WriteLine(new string('-', 120));

        foreach (var appt in appointments)
        {
            // Get the veterinarian and pet names and appointment times.
            string vetName = $"{appt.Veterinarian.FirstName} {appt.Veterinarian.LastName}";
            string petName = appt.Pet.PetName;
            string start = appt.StartTime.ToString("g");
            string end = appt.EndTime.ToString("g");

            Console.WriteLine($"{appt.AppointmentId,-36} | {vetName,-25} | {petName,-15} | {start,-20} | {end,-20}");
        }
    }
    // Method to update an existing appointment.
    public void UpdateAppointment()
    {
        try
        {
            var appointmentId = InputValidator.ReadGuid("Enter Appointment ID to update");
            var newStartTime = InputValidator.ReadDateTime("Enter new start date and time (yyyy-MM-dd HH:mm)");

            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }
            // Calculate the new end time based on the new start time (1-hour duration).
            var newEndTime = newStartTime.AddHours(1);

            // Check if there are any scheduling conflicts for the new appointment time.
            bool hasConflict = Database.Appointments.Any(a =>
                a.AppointmentId != appointmentId &&
                a.Veterinarian.VeterinarianId == appointment.Veterinarian.VeterinarianId &&
                a.StartTime < newEndTime &&
                newStartTime < a.EndTime);

            if (hasConflict)
            {
                Console.WriteLine("Scheduling conflict detected at the new time.");
                return;
            }
            // Update the appointment's start and end times with the new values.
            appointment.StartTime = newStartTime;
            appointment.EndTime = newEndTime;

            Console.WriteLine("Appointment updated successfully.");
        }
        // Handle the case where the user cancels the operation.
        catch (OperationCanceledException)
        {
            Console.WriteLine("Appointment update canceled by user.");
        }
    }
    // Method to cancel an existing appointment.
    public void CancelAppointment()
    {
        try
        {
            var appointmentId = InputValidator.ReadGuid("Enter Appointment ID to cancel");
            
            // Attempt to cancel the appointment by ID in the repository.
            var result = _appointmentRepository.CancelAppointment(appointmentId);
            if (result)
                Console.WriteLine("Appointment canceled successfully.");
            else
                Console.WriteLine("Appointment not found.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Appointment cancellation canceled by user.");
        }
    }
}

