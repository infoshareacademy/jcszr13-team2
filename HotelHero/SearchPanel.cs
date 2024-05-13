using HotelHero.Filters;
using HotelHero.HotelsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelHero
{
    class SearchPanel
    {
        HotelsRepository hotelsRepository;

        public SearchPanel()
        {
            hotelsRepository = new HotelsRepository();
        }

        public void OfferSearch()
        {
            Console.WriteLine("Search - chose option");

            var filters = new Dictionary<string, string>
            {
                { "Destination: ", "" },
                { "Check-on date dd.MM.yyyy: ", "" },
                { "Check-out date dd.MM.yyyy: ", "" },
                { "Amount of people: ", "" },
            };
            foreach (var filter in filters.Keys.ToList())
            {
                Console.WriteLine($"Enter a filter value '{filter}': ");
                filters[filter] = Console.ReadLine();
            }

            var reservation = new List<Reservation>
            {
                new Reservation(hotelsRepository.GetHotel(3), new DateTime(2024, 6, 15), new DateTime(2024, 6, 20), 3),
                new Reservation(hotelsRepository.GetHotel(2), new DateTime(2024, 6, 30), new DateTime(2024, 7, 5), 2),
                new Reservation(hotelsRepository.GetHotel(3), new DateTime(2024, 7, 10), new DateTime(2024, 7, 15), 1),
                new Reservation(hotelsRepository.GetHotel(4), new DateTime(2025, 2, 6), new DateTime(2025, 2, 10), 3),
                new Reservation(hotelsRepository.GetHotel(1), new DateTime(2025, 3, 5), new DateTime(2025, 3, 10), 2),
            };

            var searchCity = filters["Destination: "];

            DateTime searchCheckInDate;
            DateTime.TryParse(filters["Check-on date dd.MM.yyyy: "], out searchCheckInDate);

            DateTime searchCheckOutDate;
            DateTime.TryParse(filters["Check-out date dd.MM.yyyy: "], out searchCheckOutDate);

            int searchAmountOfPeople;
            int.TryParse(filters["Amount of people: "], out searchAmountOfPeople);

            var results = reservation.Where(r =>
            (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
            (searchCheckInDate == DateTime.MinValue || r.ChecInDate <= searchCheckInDate) &&
            (searchCheckOutDate == DateTime.MinValue || r.CheckOutDate >= searchCheckOutDate) &&
            (searchAmountOfPeople == 0 || r.AmountOfPeople >= searchAmountOfPeople)
            ).ToList();

            if (results.Any())
            {
                Console.WriteLine("\nReservations found:");
                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Hotel}");
                    Console.WriteLine($"Check-in date: {result.ChecInDate.ToShortDateString()}, Check-out date: {result.CheckOutDate.ToShortDateString()}, Amount of people: {result.AmountOfPeople}");
                }
            }

            else
            {
                Console.WriteLine("\nNo reservations");
                UserMenu.Menu();
            }

        }
    }
}


