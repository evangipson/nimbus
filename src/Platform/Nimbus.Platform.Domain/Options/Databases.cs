namespace Nimbus.Platform.Domain.Options
{
    /// <summary>
    /// A model which represents a collection of database locations, which are
    /// defined in the application settings.
    /// </summary>
    public class Databases() : Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
    }
}
