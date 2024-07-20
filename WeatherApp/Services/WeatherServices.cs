using AutoMapper;
using Newtonsoft.Json;
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
        public async Task<WeatherViewModel> getWeather(string url, string city, string apiKey)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Wather weather = JsonConvert.DeserializeObject<Wather>(json);

                return _mapper.Map<WeatherViewModel>(weather);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
            
        }
    }
}
