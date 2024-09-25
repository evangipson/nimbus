namespace Nimbus.Platform.Logic.Managers
{
    public interface IWeatherManager
    {
        Task<string> GetCurrentWeatherAsync();
    }
}
