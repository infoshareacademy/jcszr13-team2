﻿using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Interface;
using Newtonsoft.Json;

namespace HotelHero.WebMVC.Services
{
    public class ReservationService : IReservationService
    {
        private List<Reservation> _reservations;

        private static int _idCounter;

        private static string _fileName = "reservations.json";
        private static string _reservationsFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../ReservationsDatabase/{_fileName}";
        HotelsRepository hotelsRepository;

        public ReservationService()
        {
            hotelsRepository = new HotelsRepository();
            Save();
            _loadReservationsRepository();
        }

        public List<Reservation> GetReservations()
        {
            return _reservations;
        }

        public Reservation GetReservation(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople)
        {
            return _reservations.Where(r =>
                (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
                (searchCheckInDate == DateTime.MinValue || r.CheckInDate.Date >= searchCheckInDate.Value.Date) &&   //r.CheckInDate => r.CheckInDate.Date
                (searchCheckOutDate == DateTime.MinValue || r.CheckOutDate.Date <= searchCheckOutDate.Value.Date) &&
                (searchAmountOfPeople == 0 || r.AmountOfPeople >= searchAmountOfPeople)
                ).FirstOrDefault();
        }

        private void Save()
        {
            _reservations = new List<Reservation>()
            {
                new Reservation(hotelsRepository.GetHotel(3), new DateTime(2024, 6, 15), new DateTime(2024, 6, 20), 3,300),
                new Reservation(hotelsRepository.GetHotel(2), new DateTime(2024, 6, 30), new DateTime(2024, 7, 5), 2,500),
                new Reservation(hotelsRepository.GetHotel(3), new DateTime(2024, 7, 10), new DateTime(2024, 7, 15), 1,400),
                new Reservation(hotelsRepository.GetHotel(4), new DateTime(2025, 2, 6), new DateTime(2025, 2, 10), 3,800),
                new Reservation(hotelsRepository.GetHotel(1), new DateTime(2025, 3, 5), new DateTime(2025, 3, 10), 2,600),
            };

            var reservationsAsJson = JsonConvert.SerializeObject(_reservations, Formatting.Indented);

            File.WriteAllText(pathMVC(_reservationsFilePath), reservationsAsJson);
        }

        private void _loadReservationsRepository()
        {
            try
            {
                _reservationsFilePath = pathMVC(_reservationsFilePath);
                if (!File.Exists(_reservationsFilePath))
                {
                    _reservations = new List<Reservation>();
                }
                var resrvationJson = File.ReadAllText(_reservationsFilePath);

                _reservations = JsonConvert.DeserializeObject<List<Reservation>>(resrvationJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd wczytywania pliku: {ex.Message}");
                _reservations = new List<Reservation>();
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
