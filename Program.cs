if (Validate(args))
    Execute(Environment.CurrentDirectory, args[0]);

bool Validate(string[] args)
{
    if (args.Length == 1)
        return true;

    Console.WriteLine("\nUpdates the Last Modified date and time on all files in a folder, including its subfolders.\n");
    Console.WriteLine("          Usage :: TouchFiles pattern\n");
    Console.WriteLine("        pattern :: File name search pattern (e.g., *.xyz)\n");
    return false;
}

void Execute(string directory, string pattern)
{
    try
    {
        Console.WriteLine("Directory = " + directory);
        Console.WriteLine("  Pattern = " + pattern);

        var scanner = new FileScanner();
        int count = scanner.Touch(directory, pattern);

        if (count == 0)
            Console.WriteLine("No files found.");
        else if (count > 0)
            Console.WriteLine("{0} object(s) touched successfully.", count);
        else
            Console.WriteLine("Errors found - operation aborted!");
    }
    catch (Exception e)
    {
        Console.WriteLine("\nFatal error occured: {0}", e.ToString());
    }
}