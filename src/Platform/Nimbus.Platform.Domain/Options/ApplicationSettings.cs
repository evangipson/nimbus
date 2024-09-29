namespace Nimbus.Platform.Domain.Options
{
    /// <summary>
    /// A collection of application settings with <typeparamref name="TValue"/> values.
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of the value stored in the application settings.
    /// </typeparam>
    public abstract class ApplicationSettings<TValue>() : Dictionary<string, TValue>(StringComparer.OrdinalIgnoreCase)
    {
    }
}
