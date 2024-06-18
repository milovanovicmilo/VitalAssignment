using Assignment.Domain.Entities;

namespace Assignment.Application.WeatherForecast.Queries;
public class CountryDto
{
    public CountryDto() 
    {
        Cities = Array.Empty<CityDto>();
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public IList<CityDto> Cities { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
        }
    }
}
