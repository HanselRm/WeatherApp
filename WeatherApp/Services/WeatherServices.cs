using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class WeatherServices
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public WeatherServices(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<WeatherViewModel> getWeather(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse);

                JsonElement root = jsonDocument.RootElement;

                return _mapper.Map<WeatherViewModel>(getElement(root));
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
            
        }

        public Wather getElement(JsonElement json)
        {
            JsonElement jsonEl = json.GetProperty("weather")[0];

            Wather weather = new Wather
            {
                Id = jsonEl.GetProperty("id").GetInt32(),
                main = jsonEl.GetProperty("main").GetString(),
                description = jsonEl.GetProperty("description").GetString(),
                icon = jsonEl.GetProperty("icon").GetString()

            };
            return weather;
        }
    }
}
