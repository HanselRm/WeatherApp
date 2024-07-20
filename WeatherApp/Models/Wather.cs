namespace WeatherApp.Models
{
    public class Wather
    {
        public int Id { get; set; }
        //clima
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        public string IconUrl
        {
            get
            {
                return $"https://openweathermap.org/img/wn/{icon}@2x.png";
            }
        }
    }
}
