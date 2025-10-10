using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;

namespace ClinicaSalud.Services;
 public class GeneralConsultation : IVetService
{
    private readonly AppointmentService _appointmentService;

    public GeneralConsultation(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    
    public void Atender()
    {
        Console.Clear();
        Console.WriteLine("=== General Consultation ===");

        var vets = Database.Veterinarians;
        Console.WriteLine("\nAvailable Veterinarians:");
        for (int i = 0; i < vets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {vets[i].FirstName} {vets[i].LastName} - Specialty: {vets[i].Specialty}");
        }

        Console.Write("\nSelect a veterinarian (number): ");
        if (!int.TryParse(Console.ReadLine(), out int vetIndex) || vetIndex < 1 || vetIndex > vets.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedVet = vets[vetIndex - 1];

        var patients = Database.Patients;
        Console.WriteLine("\nRegistered Patients:");
        for (int i = 0; i < patients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {patients[i].FirstName} {patients[i].LastName}");
        }

        Console.Write("\nSelect a patient (number): ");
        if (!int.TryParse(Console.ReadLine(), out int patientIndex) || patientIndex < 1 || patientIndex > patients.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedPatient = patients[patientIndex - 1];

        if (!selectedPatient.Pets.Any())
        {
            Console.WriteLine("This patient has no pets registered.");
            return;
        }

        Console.WriteLine("\nPatient's Pets:");
        for (int i = 0; i < selectedPatient.Pets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {selectedPatient.Pets[i].PetName} ({selectedPatient.Pets[i].Species})");
        }

        Console.Write("\nSelect a pet (number): ");
        if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > selectedPatient.Pets.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedPet = selectedPatient.Pets[petIndex - 1];

        // Get available time slots for the selected veterinarian
        var availableSlots = _appointmentService.GetAvailableSlots(selectedVet.VeterinarianId);
        if (!availableSlots.Any())
        {
            Console.WriteLine("No available slots for this veterinarian.");
            return;
        }

        Console.WriteLine("\nAvailable Time Slots:");
        for (int i = 0; i < availableSlots.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableSlots[i]:f}");
        }

        Console.Write("\nSelect a time slot (number): ");
        if (!int.TryParse(Console.ReadLine(), out int slotIndex) || slotIndex < 1 || slotIndex > availableSlots.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedSlot = availableSlots[slotIndex - 1];

        bool success = _appointmentService.ScheduleNewAppointment(selectedVet.VeterinarianId, selectedPet.PetId, selectedSlot);

        if (success)
            Console.WriteLine("\nAppointment successfully scheduled.");
        else
            Console.WriteLine("\nCould not schedule appointment. Please try another time slot.");
    }
}