using ClinicaSalud.Models;
using ClinicaSalud.Services;
namespace ClinicaSalud.Utils;

public static class Menu
{
    //Display options on screen (e.g., 1. Register patient, 2. List patients, 3. Search patient, 4. Exit).
    public static void ShowMenu()
    {
        
            Console.WriteLine("====================================");
            Console.WriteLine("        Clínica de Salud");
            Console.WriteLine("====================================\n");

            Console.WriteLine("Principal Menu:\n");
            Console.WriteLine("1. Patient Registration");
            Console.WriteLine("2. Patient List");
            Console.WriteLine("3. Patient Search");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Add Pet to Patient");
            Console.WriteLine("6. Exit \n");

            Console.Write("Select an option (1-6): ");
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...\n");
        Console.ReadKey();
    }
}
