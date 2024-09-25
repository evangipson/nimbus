namespace Nimbus.Platform.Logic.Repositories
{
    public interface IWeatherRepository
    {
        Task<string> GetWeatherResultAsync(double longitude, double latitude);
    }
}
