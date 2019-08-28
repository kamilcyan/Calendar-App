using System.Net.Http;
using System.Windows.Controls;
using System.Xml;

namespace Calendar
{

    public partial class WeatherWindow : UserControl
    {
        public string homeCountry;
        public string homeTown;
        
        public WeatherWindow()
        {
            GetContentToFile();
            InitializeComponent();
            
            SelectInfo();
        }

        private void SelectInfo()
        {
            string[] times = new string[40];
            string[] symbols = new string[40];
            string[] windDir = new string[40];
            string[] temperatures = new string[40];
            string[] timeOfDay = new string[40];
            string[] windSpeedMps = new string[40];

            int licznikTemp = 0;
            int licznikWindDir = 0;
            int licznikSymb = 0;
            int licznikSpeed = 0;

            Weather weather = new Weather();
            this.WeatherWindowGrid.DataContext = weather;

            using (XmlReader reader = XmlReader.Create(@"D:\git\Calendar-App\Calendar\Calendar\xmlFiles\file.xml"))
            {

                while (reader.Read())
                {

                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString() == "symbol")
                        {
                            string attribute;
                            attribute = reader["name"];
                            symbols[licznikSymb] = reader["name"];
                            licznikSymb++;
                        }

                        if (reader.Name.ToString() == "windDirection")
                        {
                            string attribute;
                            attribute = reader["name"];
                            windDir[licznikWindDir] = reader["name"];
                            licznikWindDir++;
                        }

                        if (reader.Name.ToString() == "windSpeed")
                        {
                            string attribute;
                            attribute = reader["name"];
                            windSpeedMps[licznikSpeed] = reader["name"];
                            licznikSpeed++;
                        }

                        if (reader.Name.ToString() == "temperature")
                        {
                            string attribute;
                            attribute = reader["value"];
                            temperatures[licznikTemp] = reader["value"];
                            licznikTemp++;
                        }

                        if (reader.Name.ToString() == "country")
                            homeCountry = reader.ReadString();
                        if (reader.Name.ToString() == "name")
                            homeTown = reader.ReadString();

                        weather.homeCity = homeTown + ", " + homeCountry;
                        weather.temperature = temperatures[0] + "°C";
                        weather.windDirection = "wind:  " + windSpeedMps[0] + ", " + windDir[0];
                        weather.clouds = symbols[0];
                    }
                }
                
            }
        }

        private void GetContentToFile()
        {

            string url = "http://www.yr.no/place/Poland/Lublin/Pu%C5%82awy/forecast.xml";

            using (var httpClient = new HttpClient())
            {
                var html = httpClient.GetStringAsync(url);
                System.IO.File.WriteAllText(@"D:\git\Calendar-App\Calendar\Calendar\xmlFiles\file.xml", html.Result);
            }
        }
            
    }
    public class Weather
    {
        public string homeCity { get; set; }
        public string temperature { get; set; }
        public string clouds { get; set; }
        public string windDirection { get; set; }

    }
}
