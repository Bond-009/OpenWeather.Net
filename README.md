# OpenWeather.Net

![.NET][github-actions-badge] [![NuGet][nuget-badge]][nuget-page]

An unofficial .NET wrapper for the OpenWeatherMap API

## Usage

To use this library in your project, either run `dotnet add package OpenWeather.Net` or manually add a package reference for `OpenWeather.Net`

```cs
OpenWeatherClient client = new OpenWeatherClient("API_KEY", Unit.Metric);
WeatherData weather = await _client.GetWeatherAsync("Brussels");
Console.WriteLine("It's currently {0}°C", weather.Main.Temperature);
```

[github-actions-badge]: https://github.com/Bond-009/OpenWeather.Net/workflows/.NET/badge.svg
[nuget-badge]: https://img.shields.io/nuget/v/OpenWeather.Net
[nuget-page]: https://www.nuget.org/packages/OpenWeather.Net/
