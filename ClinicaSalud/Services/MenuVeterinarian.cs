using ClinicaSalud.Utils;

namespace ClinicaSalud.Services;

public class MenuVeterinarian
{
    public static void Run()
    {
        bool back = false;
        while (!back)
        {
            MenuVeterinarianView.ShowVetMenu();
            string vetOption = Console.ReadLine();

            switch (vetOption)
            {
                case "1":
                    Console.WriteLine("\n-- Register Veterinarian --");
                    VeterinarianService.RegisterVeterinarian();
                    MenuVeterinarianView.Pause();
                    break;
                case "2":
                    Console.WriteLine("\n-- Veterinarian List --");
                    VeterinarianService.ListVeterinarians();
                    MenuVeterinarianView.Pause();
                    break;
                case "3":
                    Console.WriteLine("\n-- Search Veterinarian --");
                    VeterinarianService.SearchVeterinarian();
                    MenuVeterinarianView.Pause();
                    break;
                case "4":
                    Console.WriteLine("\n-- Update Veterinarian --");
                    VeterinarianService.UpdateVeterinarian();
                    MenuVeterinarianView.Pause();
                    break;
                case "5":
                    Console.WriteLine("\n-- Delete Veterinarian --");
                    VeterinarianService.DeleteVeterinarian();
                    MenuVeterinarianView.Pause();
                    break;
                case "6":
                    back = true;
                    MenuServiceView.ShowClinicMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    MenuVeterinarianView.Pause();
                    break;
            }
        }
    }
}