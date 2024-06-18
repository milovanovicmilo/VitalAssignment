using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.Common.Services;
public class WeatherForecastApi : IWeatherForecastApi
{
    public async Task<int?> GetTemperature(string cityName, DateTime time)
    {
        if (string.IsNullOrEmpty(cityName))
        {
            return null;
        }

        Random random = new Random();
        int temperature = 0;

        await Task.Run(() => {
            temperature = random.Next(-50, 51);
        });

        return temperature;
    }
}
