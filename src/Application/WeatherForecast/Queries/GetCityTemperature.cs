using Assignment.Application.Common.Interfaces;

namespace Assignment.Application.WeatherForecast.Queries;

public record GetCityTemperatureQuery : IRequest<int?> 
{
    public string? CityName { get; set; }
    public DateTime Time { get; set; }
}

public class GetCityTemperatureQueryHandler : IRequestHandler<GetCityTemperatureQuery, int?>
{
    private readonly IWeatherForecastApi _weatherForecastApi;

    public GetCityTemperatureQueryHandler(IWeatherForecastApi weatherForecastApi)
    {
        _weatherForecastApi = weatherForecastApi;
    }

    public async Task<int?> Handle(GetCityTemperatureQuery request, CancellationToken cancellationToken)
    {
        return await _weatherForecastApi.GetTemperature(request.CityName!, request.Time);
    }
}
