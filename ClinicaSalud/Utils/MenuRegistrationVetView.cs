namespace ClinicaSalud.Utils;

public static class MenuVeterinarianView
{
    public static void ShowVetMenu()
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("      Veterinarian Management");
        Console.WriteLine("====================================\n");

        Console.WriteLine("1. Register Veterinarian");
        Console.WriteLine("2. List All Veterinarians");
        Console.WriteLine("3. Search Veterinarian by Name");
        Console.WriteLine("4. Update Veterinarian Info");
        Console.WriteLine("5. Delete Veterinarian");
        Console.WriteLine("6. Back to Main Menu\n");

        Console.Write("Select an option (1-6): ");
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}