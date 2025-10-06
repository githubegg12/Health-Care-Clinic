
using System.Text.RegularExpressions;

namespace ClinicaSalud.Services;

public class InputValidator
{
// Read a non-empty string that is not purely numeric.
    public static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                return input;

            Console.WriteLine("Input cannot be empty or a number. Please try again.");
        }
    }
    // Read a non-negative integer from the console.
    public static int ReadNonNegativeInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value) && value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }
    
    // Read a valid Guid from the console.
    public static Guid ReadGuid(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (Guid.TryParse(input, out Guid result))
                return result;

            Console.WriteLine("Invalid GUID format. Please enter a valid GUID.");
        }
    }
    public static string ReadAlphanumericString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && input.Any(char.IsLetterOrDigit))
                return input;

            Console.WriteLine("Input must not be empty and should contain letters or numbers.");
        }
    }
    public static string ReadEmail(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return input;

            Console.WriteLine("Invalid email format. Try again.");
        }
    }
    
    public static bool ReadYesOrNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                (input.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                 input.Equals("N", StringComparison.OrdinalIgnoreCase)))
            {
                return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
            }

            Console.WriteLine("Please enter 'Y' or 'N'.");
        }
    }
    public static string? ReadOptionalValidatedString(string prompt, Func<string, bool> validateFunc, string errorMessage)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (validateFunc(input))
            return input;

        Console.WriteLine(errorMessage);
        return null;
    }
    
}
