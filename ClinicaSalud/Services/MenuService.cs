using ClinicaSalud.Repositories;
using ClinicaSalud.Utils;

namespace ClinicaSalud.Services;

public class MenuService
{
    public static void Run()
    {
        var appointmentRepository = new AppointmentRepository();
        var appointmentService = new AppointmentService(appointmentRepository);
        
        bool exit = false;

        while (!exit)
        {
            MenuServiceView.ShowClinicMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Menu for patient/pet registration
                    MenuRegistrationView.ShowMenu();
                    Menu.Run();
                    break;
                
                case "2":
                    MenuVeterinarianView.ShowVetMenu();
                    MenuVeterinarian.Run();
                    break;
                
                 case "3":
                    Console.WriteLine("\n-- Show All Appointments --");
                    appointmentService.ShowAllAppointments();
                    MenuServiceView.Pause();
                    break;

                case "4":
                    Console.WriteLine("\n-- Update Appointment --");
                    appointmentService.UpdateAppointment();
                    MenuServiceView.Pause();
                    break;

                case "5":
                    Console.WriteLine("\n-- Cancel Appointment --");
                    appointmentService.CancelAppointment();
                    MenuServiceView.Pause();
                    break;

                case "6":
                    Console.WriteLine("\n-- General Consultation --");
                    var generalConsult = new GeneralConsultation(appointmentService);
                    generalConsult.Atender();
                    MenuServiceView.Pause();
                    break;

                case "7":
                    Console.WriteLine("\n-- Vaccination Service --");
                    var vaccination = new GeneralConsultation(appointmentService);
                    vaccination.Atender();
                    MenuServiceView.Pause();
                    break;

                case "8":
                    Console.WriteLine("\nExiting system...");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    MenuServiceView.Pause();
                    break;
            }
        }
    }
}