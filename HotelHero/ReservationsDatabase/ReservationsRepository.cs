using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelHero.ResrevationsDatabase
{
    internal class ReservationsRepository
    {
        private List<Reservation> _reservations;

        private static int _idCounter;

        private static string _fileName = "reservations.json";
        private static string _reservationsFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../ReservationsDatabase/{_fileName}";
        HotelsRepository hotelsRepository;

        public ReservationsRepository()
        {
            hotelsRepository = new HotelsRepository();
            _reservations = new List<Reservation>();
            _loadReservationsRepository();
            _idCounter = _reservations.Count();
        }

        public List<Reservation> GetReservations()
        {
            return _reservations;
        }

        private void Save()
        {
            _reservations = new List<Reservation>()
            {
                new Reservation(1,hotelsRepository.GetHotel(3), new DateTime(2024, 6, 15), new DateTime(2024, 6, 20), 3,300),
                new Reservation(2,hotelsRepository.GetHotel(2), new DateTime(2024, 6, 30), new DateTime(2024, 7, 5), 2,500),
                new Reservation(3,hotelsRepository.GetHotel(3), new DateTime(2024, 7, 10), new DateTime(2024, 7, 15), 1,400),
                new Reservation(4, hotelsRepository.GetHotel(4), new DateTime(2025, 2, 6), new DateTime(2025, 2, 10), 3,800),
                new Reservation(5, hotelsRepository.GetHotel(1), new DateTime(2025, 3, 5), new DateTime(2025, 3, 10), 2,600),
            };

            var reservationsAsJson = JsonConvert.SerializeObject(_reservations, Formatting.Indented);

            File.WriteAllText(_reservationsFilePath, reservationsAsJson);
        }

        private void _loadReservationsRepository()
        {
            try
            {
                if (!File.Exists(_reservationsFilePath))
                {
                    _reservations =  new List<Reservation>();
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

        public Reservation GetReservationById(int id)
        {
            return _reservations.SingleOrDefault(r => r.Id == id);
        }
        private int GetNextId()
        {
            _idCounter++;
            return _idCounter;
        }
    }
}
