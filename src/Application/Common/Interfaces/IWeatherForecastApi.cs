namespace Assignment.Application.Common.Interfaces;
public interface IWeatherForecastApi
{
    Task<int?> GetTemperature(string cityName, DateTime time);
}
