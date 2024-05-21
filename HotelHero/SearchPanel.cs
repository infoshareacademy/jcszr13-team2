using HotelHero.ReservationsDatabase;
using HotelHero.ResrevationsDatabase;
using HotelHero.UserPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace HotelHero
{
    class SearchPanel
    {
        ReservationsRepository reservationsRepository;

        private List<Reservation> _searchedReservations;
        public SearchPanel()
        {
            reservationsRepository = new ReservationsRepository();
            _searchedReservations = new List<Reservation>();
        }

        public void OfferSearch()
        {
            Console.WriteLine("Search - choose option");

            var filters = new Dictionary<string, string>
            {
                { "Destination: ", "" },
                { "Check-in date dd.MM.yyyy: ", "" },
                { "Check-out date dd.MM.yyyy: ", "" },
                { "Amount of people: ", "" },
                { "Cost per night: ", "" }
            };
            foreach (var filter in filters.Keys.ToList())
            {
                Console.WriteLine($"Enter a filter value '{filter}': ");
                filters[filter] = Console.ReadLine();
            }

            var reservation = reservationsRepository.GetReservations();

            var searchCity = filters["Destination: "];

            DateTime searchCheckInDate;
            DateTime.TryParse(filters["Check-in date dd.MM.yyyy: "], out searchCheckInDate);

            DateTime searchCheckOutDate;
            DateTime.TryParse(filters["Check-out date dd.MM.yyyy: "], out searchCheckOutDate);

            int searchAmountOfPeople;
            int.TryParse(filters["Amount of people: "], out searchAmountOfPeople);

            _searchedReservations = reservation.Where(r =>
            (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
            (searchCheckInDate == DateTime.MinValue || r.CheckInDate <= searchCheckInDate) &&
            (searchCheckOutDate == DateTime.MinValue || r.CheckOutDate >= searchCheckOutDate) &&
            (searchAmountOfPeople == 0 || r.AmountOfPeople >= searchAmountOfPeople)
            ).ToList();

            if (_searchedReservations.Any())
            {
                int index = 1;
                Console.WriteLine("\nReservations found:");
                foreach (var result in _searchedReservations)
                {
                    Console.Write($"{index}.");
                    Console.WriteLine($"{result.Hotel.ToString()}");
                    Console.WriteLine($"Check-in date: {result.CheckInDate.ToShortDateString()}," +
                        $" Check-out date: {result.CheckOutDate.ToShortDateString()}," +
                        $" Amount of people: {result.AmountOfPeople}");
                    index++;
                }
                CreateReservation();
            }

            else
            {
                Console.WriteLine("\nNo reservations");
                UserMenu.Menu();
            }

        }

        private void CreateReservation()
        {
            if(Program.loggedUser == null)
            {
                Console.WriteLine("W celu złożenia rezerwcji musisz sięzalogować");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Jeżeli chcesz dokonaćrezerwacji wybierz numer rezerwacji. Aby zrezygnować wciśnij 0:");
                bool isActionOK = Int32.TryParse(Console.ReadLine(), out int result);

                if(result > 0 && result <= _searchedReservations.Count)
                {
                    Program.loggedUser.MakeReservation(_searchedReservations.ElementAt(result - 1));
                    Console.WriteLine("Dokonano rezerwacji");
                    Console.WriteLine();
                }

            }
        }

    }
}


