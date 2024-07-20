using AutoMapper;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<WeatherViewModel, Wather>();
        }
    }
}
