using ClinicaSalud.Data;
using ClinicaSalud.Interfaces;

namespace ClinicaSalud.Services;

// GeneralConsultation class implements IVetService interface
// It handles the process of scheduling a general consultation for pets.
 public class GeneralConsultation : IVetService
{
    private readonly AppointmentService _appointmentService;
    // Constructor that initializes the appointment service
    public GeneralConsultation(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    // Method to handle the consultation process
    public void Atender()
    {
        // Clear the console screen for a fresh start
        Console.Clear();
        Console.WriteLine("=== General Consultation ===");
        // Retrieve the list of available veterinarians from the database
        var vets = Database.Veterinarians;
        Console.WriteLine("\nAvailable Veterinarians:");
        
        // Display the list of veterinarians with their name and specialty
        for (int i = 0; i < vets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {vets[i].FirstName} {vets[i].LastName} - Specialty: {vets[i].Specialty}");
        }

        // Prompt the user to select a veterinarian by entering a number
        Console.Write("\nSelect a veterinarian (number): ");
        if (!int.TryParse(Console.ReadLine(), out int vetIndex) || vetIndex < 1 || vetIndex > vets.Count)
        {
            // Check if the selection is valid (between 1 and the number of vets)
            Console.WriteLine("Invalid selection.");
            return;
        }
        // Store the selected veterinarian
        var selectedVet = vets[vetIndex - 1];         
        // Retrieve the list of registered patients from the database
        var patients = Database.Patients;
        Console.WriteLine("\nRegistered Patients:");
        
        // Display the list of registered patients with their names
        for (int i = 0; i < patients.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {patients[i].FirstName} {patients[i].LastName}");
        }

        // Prompt the user to select a patient by entering a number
        Console.Write("\nSelect a patient (number): ");
        if (!int.TryParse(Console.ReadLine(), out int patientIndex) || patientIndex < 1 || patientIndex > patients.Count)
        {
            // Check if the selection is valid (between 1 and the number of patients)
            Console.WriteLine("Invalid selection.");
            return;
        }
        // Store the selected patient
        var selectedPatient = patients[patientIndex - 1];

        // Check if the selected patient has any pets registered
        if (!selectedPatient.Pets.Any())
        {
            Console.WriteLine("This patient has no pets registered.");
            return;
        }
        // Display the list of pets registered to the selected patient
        Console.WriteLine("\nPatient's Pets:");
        for (int i = 0; i < selectedPatient.Pets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {selectedPatient.Pets[i].PetName} ({selectedPatient.Pets[i].Species})");
        }
        // Prompt the user to select a pet by entering a number
        Console.Write("\nSelect a pet (number): ");
        if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 1 || petIndex > selectedPatient.Pets.Count)
        {
            // Check if the selection is valid (between 1 and the number of pets)
            Console.WriteLine("Invalid selection.");
            return;
        }
        // Store the selected pet
        var selectedPet = selectedPatient.Pets[petIndex - 1];

        // Retrieve available time slots for the selected veterinarian
        var availableSlots = _appointmentService.GetAvailableSlots(selectedVet.VeterinarianId);
        if (!availableSlots.Any())
        {
            // Check if there are any available slots for the selected vet
            Console.WriteLine("No available slots for this veterinarian.");
            return;
        }
        // Display the available time slots for the selected veterinarian
        Console.WriteLine("\nAvailable Time Slots:");
        for (int i = 0; i < availableSlots.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableSlots[i]:f}");
        }
        // Prompt the user to select a time slot by entering a number
        Console.Write("\nSelect a time slot (number): ");
        if (!int.TryParse(Console.ReadLine(), out int slotIndex) || slotIndex < 1 || slotIndex > availableSlots.Count)
        {
            // Check if the selection is valid (between 1 and the number of available time slots)
            Console.WriteLine("Invalid selection.");
            return;
        }
        // Store the selected time slot
        var selectedSlot = availableSlots[slotIndex - 1];

        // Try to schedule the appointment using the selected veterinarian, pet, and time slot
        bool success = _appointmentService.ScheduleNewAppointment(selectedVet.VeterinarianId, selectedPet.PetId, selectedSlot);

        // Output the result of the appointment scheduling process
        if (success)
            Console.WriteLine("\nAppointment successfully scheduled.");
        else
            Console.WriteLine("\nCould not schedule appointment. Please try another time slot.");
    }
}