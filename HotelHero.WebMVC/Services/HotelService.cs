using AutoMapper;
using HotelHero.Database.Entities;
using HotelHero.Database.Repositiories.Hotels;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Interface;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;


namespace HotelHero.WebMVC.Services
{
    public class HotelService : IHotelService
    {
        private List<Hotel> _hotels;

        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        private static int _idCounter;

        private static string _fileName = "hotels.json";
        private static string _hotelsFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../HotelsDatabase/{_fileName}";

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            //_loadHotelsRepository();
            //_idCounter = _hotels.Count();

            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public List<Hotel> GetHotels()
        {
            List<HotelDTO> hotelDTO =  _hotelRepository.GetAllHotel();
            List<Hotel> hotels = _mapper.Map<List<Hotel>>(hotelDTO);
            return hotels;
        }

        public Hotel GetHotel(int id)
        {
            HotelDTO hotelDTO = _hotelRepository.GetHotel(id);
            Hotel hotel = _mapper.Map<Hotel>(hotelDTO);
            return hotel;
        }

        public void Create(Hotel hotel)
        {
            HotelDTO hotelDTOs = _mapper.Map<HotelDTO>(hotel);
            _hotelRepository.AddHotel(hotelDTOs);
            //_hotels.Add(hotel);
        }

        public void Update(Hotel model)
        {
            var hotel = GetHotel(model.Id);

            hotel.Name = model.Name;
            hotel.Address = model.Address;
            hotel.City = model.City;
            hotel.Description = model.Description;
            hotel.Image = model.Image;
            hotel.Stars = model.Stars;
            hotel.Rating = model.Rating;
            hotel.IsFreeWiFi = model.IsFreeWiFi;
            hotel.IsPrivateParking = model.IsPrivateParking;
            hotel.IsRestaurant = model.IsRestaurant;
            hotel.IsBar = model.IsBar;

            HotelDTO hotelDTO = _mapper.Map<HotelDTO>(hotel);
            _hotelRepository.UpdateHotel(hotelDTO);
        }

        public void Delete(int id)
        {
            //_hotels.Remove(GetHotel(id));
            _hotelRepository.RemoveHotel(id);
        }

        private void Save()
        {
            _hotels = new List<Hotel>()
            {
                new Hotel(){ Id = 1, Name = "Hotel 1",Address = "Słowackiego 1", City = "Warszawa", Description = "Hotel in Warsaw", Stars = 4, Rating = 4.5f, IsFreeWiFi = true, IsPrivateParking = true, IsRestaurant = false, IsBar = false },
                new Hotel(){ Id = 2, Name = "Hotel 2",Address = "Sienkiewicza 3", City = "Warszawa", Description = "The best hotel in Warsaw", Stars = 5, Rating = 5.0f, IsFreeWiFi = true, IsPrivateParking = false, IsRestaurant = false, IsBar = true },
                new Hotel(){ Id = 3, Name = "Hotel 3",Address = "Mickiewicza 45", City = "Kraków", Description = "Hotel in Cracow", Stars = 3, Rating = 3.7f, IsFreeWiFi = false, IsPrivateParking = false, IsRestaurant = true, IsBar = true },
                new Hotel(){ Id = 4, Name = "Hotel 4",Address = "Fredry 36", City = "Poznań", Description = "Hotel in Poznań", Stars = 5, Rating = 4.7f, IsFreeWiFi = false, IsPrivateParking = false, IsRestaurant = false, IsBar = false },
            };

            var hotelsAsJson = JsonConvert.SerializeObject(_hotels, Formatting.Indented);

            File.WriteAllText(_hotelsFilePath, hotelsAsJson);
        }

        private void _loadHotelsRepository()
        {
            try
            {
                _hotelsFilePath = pathMVC(_hotelsFilePath);
                if (!File.Exists(_hotelsFilePath))
                {
                    _hotels = new List<Hotel>();
                }
                var usersJson = File.ReadAllText(_hotelsFilePath);

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
        private int GetNextId()
        {
            _idCounter++;
            return _idCounter;
        }
    }
}
