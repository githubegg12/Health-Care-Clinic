
namespace ClinicaSalud.Models;

public static class Menu
{
    public static void MostrarMenu(List<Patient> patients)
    {
        bool exit = false;

        while (!exit)
        {
            
            Console.WriteLine("====================================");
            Console.WriteLine("        Clínica de Salud");
            Console.WriteLine("====================================\n");

            Console.WriteLine("Principal Menu:");
            Console.WriteLine("1. Patient Registration");
            Console.WriteLine("2. Patient List");
            Console.WriteLine("3. Patient Search");
            Console.WriteLine("4. Delete Patient");
            Console.WriteLine("5. Exit \n");

            Console.Write("Select an option (1-5): ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("\n-- Patient Registration --");
                    Pausa();
                    break;

                case "2":
                    Console.WriteLine("\n-- Patient List --");
                    Pausa();
                    break;

                case "3":
                    Console.WriteLine("\n-- Patient Search--");
                    Pausa();
                    break;

                case "4":
                    Console.WriteLine("\n-- Delete Patient --");
                    Pausa();
                    break;

                case "5":
                    Console.WriteLine("\n-- Exit --");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Pausa();
                    break;
            }
        }
    }

    private static void Pausa()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
