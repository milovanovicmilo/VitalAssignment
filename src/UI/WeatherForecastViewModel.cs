using System.ComponentModel;
using System.Windows.Input;
using Assignment.Application.WeatherForecast.Queries;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;
internal class WeatherForecastViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IWindowManager _windowManager;

    private IList<CountryDto> _countries;
    public IList<CountryDto> Countries
    {
        get
        {
            return _countries;
        }
        set
        {
            _countries = value;
            NotifyOfPropertyChange(() => Countries);
        }
    }

    private CountryDto _selectedCountry;
    public CountryDto SelectedCountry
    {
        get
        {
            return _selectedCountry;
        }
        set
        {
            _selectedCountry = value;
            NotifyOfPropertyChange(() => SelectedCountry);
            RefreshCities();
        }
    }

    private IList<CityDto> _cities;

    public IList<CityDto> Cities
    {
        get
        {
            return _cities;
        }
        set
        {
            _cities = value;
            NotifyOfPropertyChange(() => Cities);
        }
    }

    private CityDto _selectedCity;
    public CityDto SelectedCity
    {
        get
        {
            return _selectedCity;
        }
        set
        {
            _selectedCity = value;
            NotifyOfPropertyChange(() => SelectedCity);
        }
    }

    private int? _temperature;
    public int? Temperature
    {
        get { return _temperature; }
        set
        {
            _temperature = value;
            NotifyOfPropertyChange(() => Temperature);
        }
    }

    public WeatherForecastViewModel(ISender sender, IWindowManager windowManager)
    {
        PropertyChanged += SelectedCityChanged;
        _sender = sender;
        _windowManager = windowManager;
        Initialize();
    }

    private async void Initialize()
    {
        Countries = await _sender.Send(new GetCountriesQuery());
    }

    public async void SelectedCityChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedCity))
        {
            GetCityTemperatureQuery request = new GetCityTemperatureQuery
            {
                CityName = SelectedCity?.Name,
                Time = DateTime.UtcNow,
            };
            Temperature = await _sender.Send(request);
        }
    }

    private void RefreshCities()
    {
        if (_selectedCountry != null)
        {
            Cities = SelectedCountry.Cities;
            Temperature = null;
        }
    }
}
