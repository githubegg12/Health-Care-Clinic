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
        Console.WriteLine("1. Patient Registration");
        Console.WriteLine("2. General Consultation");
        Console.WriteLine("3. Vaccination");
        Console.WriteLine("4. Exit\n");

        Console.Write("Select an option (1-4): ");
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...\n");
        Console.ReadKey();
    }
}