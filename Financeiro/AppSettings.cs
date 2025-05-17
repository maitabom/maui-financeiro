namespace Financeiro;

public class AppSettings
{
    public static readonly string DatabaseName = "Financial.db";
    public static readonly string DatabaseDirectory = FileSystem.AppDataDirectory;
    public static readonly string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName);
}
