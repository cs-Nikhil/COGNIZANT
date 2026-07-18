namespace RetailInventory.Shared.Helpers;

public static class LabRunner
{
    public static bool IsDryRun(string[] args, string labTitle)
    {
        if (!args.Contains("--dry-run", StringComparer.OrdinalIgnoreCase))
        {
            return false;
        }

        Console.WriteLine($"{labTitle} dry run completed. Database code is ready to execute without --dry-run.");
        return true;
    }
}
