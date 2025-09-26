
namespace ClinicaSalud.Models;

public static class Menu
{
    public static void MostrarMenu()
    {
        Console.WriteLine("=== Menú Principal ===");
        Console.WriteLine("1. Registrar Paciente");
        Console.WriteLine("2. Listar Pacientes");
        Console.WriteLine("3. Buscar Paciente");
        Console.WriteLine("4. Eliminar Paciente");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                
                break;
            case "2":
                
                break;
            case "3":
                
                break;
            case "4":
                
                break;
            case "5":
                Console.WriteLine("Saliendo del programa...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
        }
    }
}
