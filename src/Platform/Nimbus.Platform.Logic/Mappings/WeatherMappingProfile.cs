using AutoMapper;

using Nimbus.Platform.Domain.DTOs;
using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Mappings
{
    public class WeatherMappingProfile : Profile
    {
        public WeatherMappingProfile()
        {
            _ = CreateMap<WeatherProviderResponse, WeatherForecast>()
               .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.CurrentWeather!.Date))
               .ForMember(dest => dest.DateUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.DateUnit))
               .ForMember(dest => dest.IsDay, opts => opts.MapFrom(src => src.CurrentWeather!.IsDay == 1))
               .ForMember(dest => dest.Temperature, opts => opts.MapFrom(src => src.CurrentWeather!.Temperature))
               .ForMember(dest => dest.TemperatureUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.TemperatureUnit))
               .ForMember(dest => dest.Humidity, opts => opts.MapFrom(src => src.CurrentWeather!.Humidity))
               .ForMember(dest => dest.HumidityUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.HumidityUnit))
               .ForMember(dest => dest.PrecipitationChance, opts => opts.MapFrom(src => src.CurrentWeather!.PrecipitationChance))
               .ForMember(dest => dest.PrecipitationUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.PrecipitationUnit))
               .ForMember(dest => dest.CloudCover, opts => opts.MapFrom(src => src.CurrentWeather!.CloudCover))
               .ForMember(dest => dest.CloudCoverUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.CloudCoverUnit))
               .ForMember(dest => dest.WindSpeed, opts => opts.MapFrom(src => src.CurrentWeather!.WindSpeed))
               .ForMember(dest => dest.WindSpeedUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.WindSpeedUnit))
               .ForMember(dest => dest.WindDirection, opts => opts.MapFrom(src => src.CurrentWeather!.WindDirection))
               .ForMember(dest => dest.WindDirectionUnit, opts => opts.MapFrom(src => src.CurrentWeatherUnits!.WindDirectionUnit));
        }
    }
}
