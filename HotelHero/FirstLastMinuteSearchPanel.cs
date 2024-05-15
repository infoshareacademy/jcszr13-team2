using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using HotelHero.ResrevationsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelHero
{
    class FirstLastMinuteSearchPanel
    {
        ReservationsRepository reservationsRepository;

        public FirstLastMinuteSearchPanel()
        {
            reservationsRepository = new ReservationsRepository();
        }

        public void OfferSearch()
        {
            Console.WriteLine("Search - choose option");

            var filters = new Dictionary<string, string>
            {
                { "Destination: ", "" },
                { "Check-on date dd.MM.yyyy: ", "" },
                { "Check-out date dd.MM.yyyy: ", "" },
                { "Amount of people: ", "" },
                { "Max price: ", "" },
            };
            foreach (var filter in filters.Keys.ToList())
            {
                Console.WriteLine($"Enter a filter value '{filter}': ");
                filters[filter] = Console.ReadLine();
            }

            var reservation = reservationsRepository.GetReservations();

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
                    Console.WriteLine($"Check-in date: {result.ChecInDate.ToShortDateString()}," +
                        $" Check-out date: {result.CheckOutDate.ToShortDateString()}," +
                        $" Amount of people: {result.AmountOfPeople}");
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


