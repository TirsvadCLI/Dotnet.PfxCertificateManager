namespace TirsvadCLI.PfxCertificateManager;

using System.Reflection;
using TirsvadCLI.MenuPaginator;

internal class Program
{
    const string TITLE = "Pfx Certificate manager";
    const Version VERSION;

    static Program()
    {
        VERSION = GetVersion();
    }

    static string GetVersion()
    {
        Version? version = Assembly.GetExecutingAssembly().GetName().Version;
        return version != null ? $"{version.Major}.{version.Minor}" : "Unknown version";
    }

    static void CreatePfx()
    {
        Console.WriteLine("Creating PFX...");
        throw new NotImplementedException("CreatePfx not implemented yet.");
    }

    static void ExportPfx()
    {
        Console.WriteLine("Exporting PFX...");
        throw new NotImplementedException("ExportPfx not implemented yet.");
    }

    static void ImportPfx()
    {
        Console.WriteLine("Importing PFX...");
        throw new NotImplementedException("ImportPfx not implemented yet.");
    }

    static void DeletePfx()
    {
        Console.WriteLine("Deleting PFX...");
        throw new NotImplementedException("DeletePfx not implemented yet.");
    }

    static void ListPfx()
    {
        Console.WriteLine("Listing PFX...");
        throw new NotImplementedException("ListPfx not implemented yet.");
    }

    static void SignNuget()
    {
        Console.WriteLine("Signing Nuget...");
        throw new NotImplementedException();
    }

    static void ArgsHelp()
    {
        Console.WriteLine("Usage: TirsvadCLI.PfxCertificateManager [options]");
        Console.WriteLine("Options:");
        Console.WriteLine("  --help       Show this help message and exit");
        Console.WriteLine("  --version    Show version information and exit");
    }

    static void Menu()
    {
        do
        {
            Console.Clear();
            MenuItem[] menuItems = new MenuItem[]
            {
            new MenuItem("Create PFX", CreatePfx),
            new MenuItem("Export PFX", ExportPfx),
            new MenuItem("Import PFX", ImportPfx),
            new MenuItem("Delete PFX", DeletePfx),
            new MenuItem("List PFX", ListPfx),
            new MenuItem("Sign nuget", SignNuget),
            };

            MenuPaginator menu = new MenuPaginator(menuItems.ToList(), 10, true);
            if (menu.menuItem != null && menu.menuItem.Action is Action action)
            {
                action();
            }
            else
            {
                return;
            }

        } while (true);
    }

    static void ArgsAction()
    {
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "create":
                    CreatePfx();
                    break;
                case "export":
                    ExportPfx();
                    break;
                case "import":
                    ImportPfx();
                    break;
                case "delete":
                    DeletePfx();
                    break;
                case "list":
                    ListPfx();
                    break;
                case "signnuget":
                    SignNuget();
                    break;
                case "--help":
                case "-h":
                case "-?":
                    ArgsHelp();
                    return;
                default:
                    Console.WriteLine("Invalid argument. Use --help for usage information.");
                    return;
            }
        }
    }

    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            ArgsAction();
        }
        else
            Menu();
    }
}
