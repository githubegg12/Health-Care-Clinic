namespace ClinicaSalud.Utils;

public class MenuServiceView
{
    public static void ShowClinicMenu()
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("         Clínica de Salud");
        Console.WriteLine("====================================\n");

        Console.WriteLine("Clinical Services Menu:\n");
        Console.WriteLine("1. Patient Management");
        Console.WriteLine("2. Veterinarian Management");
        Console.WriteLine("3. Show Appointments");
        Console.WriteLine("4. Update Appointments");
        Console.WriteLine("5. Cancel Appointments");
        Console.WriteLine("6. General Consultation");
        Console.WriteLine("7. Vaccination");
        Console.WriteLine("8. Exit\n");

        Console.Write("Select an option (1-4): ");
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...\n");
        Console.ReadKey();
    }
}