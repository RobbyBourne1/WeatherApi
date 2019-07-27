using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WeatherApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter Zip Code:");
            var zipCode = Console.ReadLine();
    
            var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid=c8edcaf7bcbca5cf2dbc12521cdcc658";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var currentWeather = JsonConvert.DeserializeObject<RootObject>(rawResponse);
            Console.WriteLine($"Longitude: {currentWeather.coord.lon}");
            Console.WriteLine($"Latitude: {currentWeather.coord.lat}");
            Console.WriteLine($"City: {currentWeather.name}");
            Console.WriteLine($"Clouds: {currentWeather.clouds.all}");
            Console.ReadLine();
        }
    }
}
