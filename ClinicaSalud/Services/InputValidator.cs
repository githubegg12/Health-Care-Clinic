using System.Text.RegularExpressions;

namespace ClinicaSalud.Services;

public class InputValidator
{
    private const string CancelKeyword = "cancel";

    private static void CheckCancel(string? input)
    {
        if (input?.Trim().Equals(CancelKeyword, StringComparison.OrdinalIgnoreCase) == true)
            throw new OperationCanceledException("Input was cancelled by the user.");
    }

    public static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

            if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                return input;

            Console.WriteLine("Input cannot be empty or a number. Please try again.");
        }
    }

    public static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

            if (int.TryParse(input, out int value) && value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }

    public static Guid ReadGuid(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

            if (Guid.TryParse(input, out Guid result))
                return result;

            Console.WriteLine("Invalid GUID format. Please enter a valid GUID.");
        }
    }

    public static string ReadAlphanumericString(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

            if (!string.IsNullOrWhiteSpace(input) && input.Any(char.IsLetterOrDigit))
                return input;

            Console.WriteLine("Input must not be empty and should contain letters or numbers.");
        }
    }

    public static string ReadEmail(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

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
            Console.Write($"{prompt} (Y/N, type '{CancelKeyword}' to cancel): ");
            string? input = Console.ReadLine();
            CheckCancel(input);

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
        Console.Write($"{prompt} (press Enter to skip, or type '{CancelKeyword}' to cancel): ");
        string? input = Console.ReadLine();
        CheckCancel(input);

        if (string.IsNullOrWhiteSpace(input))
            return null;

        if (validateFunc(input))
            return input;

        Console.WriteLine(errorMessage);
        return null;
    }
}
