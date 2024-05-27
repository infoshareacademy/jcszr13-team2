using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelHero.HotelsDatabase
{
    public class HotelsRepository
    {
        private List<Hotel> _hotels;

        private static string _fileName = "hotels.json";
        private static string __hotelsFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../HotelsDatabase/{_fileName}";

        public HotelsRepository()
        {
            _loadHotelsRepository();
        }

        public List<Hotel> GetHotels()
        {
            return _hotels;
        }

        public Hotel GetHotel(int id)
        {
            return _hotels.SingleOrDefault(h => h.Id == id);
        }

        private void Save()
        {
            _hotels = new List<Hotel>()
            {
                new Hotel(){ Id = 1, Name = "Hotel 1",Address = "Słowackiego 1", City = "Warszawa", Description = "Hotel in Warsaw", Stars = 4, Rating = 4.5f },
                new Hotel(){ Id = 2, Name = "Hotel 2",Address = "Sienkiewicza 3", City = "Warszawa", Description = "The best hotel in Warsaw", Stars = 5, Rating = 5.0f },
                new Hotel(){ Id = 3, Name = "Hotel 3",Address = "Mickiewicza 45", City = "Kraków", Description = "Hotel in Cracow", Stars = 3, Rating = 3.7f },
                new Hotel(){ Id = 4, Name = "Hotel 4",Address = "Fredry 36", City = "Poznań", Description = "Hotel in Poznań", Stars = 5, Rating = 4.7f },
            };

            var hotelsAsJson = JsonConvert.SerializeObject(_hotels, Formatting.Indented);

            File.WriteAllText(__hotelsFilePath, hotelsAsJson);
        }

        private void _loadHotelsRepository()
        {
            try
            {
                __hotelsFilePath = pathMVC(__hotelsFilePath);
                if (!File.Exists(__hotelsFilePath))
                {
                    _hotels =  new List<Hotel>();
                }
                var usersJson = File.ReadAllText(__hotelsFilePath);

                _hotels = JsonConvert.DeserializeObject<List<Hotel>>(usersJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd wczytywania pliku: {ex.Message}");
                _hotels = new List<Hotel>();
            }

        }

        private string pathMVC(string path)
        {
            string newPath = path;
            if (path.Contains(".WebMVC"))
            {
                newPath = path.Replace(".WebMVC", "");
            }
            return newPath;
        }
    }
}
