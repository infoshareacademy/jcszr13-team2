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

        public void SurpriseMe()
        {
            Console.WriteLine("Do you prefer to relax or be active during your vacation?");
            Console.WriteLine("1. Relax");
            Console.WriteLine("2. Be active");
            Console.WriteLine("3. A little bit of both");
            string activityPreference = Console.ReadLine().ToLower();

            Console.WriteLine("How about proximity to water?");
            Console.WriteLine("1. Near water");
            Console.WriteLine("2. No water at all");
            Console.WriteLine("3. I don't mind a bit of water");
            Console.WriteLine("4. No preference");
            string waterPreference = Console.ReadLine().ToLower();

            Console.WriteLine("Flat or mountainous terrain?");
            Console.WriteLine("1. Flat");
            Console.WriteLine("2. Mountainous");
            Console.WriteLine("3. Either");
            string terrainPreference = Console.ReadLine().ToLower();

            var hotelRecommendations = new Dictionary<string, List<int>>
    {
        { "1_1_1", new List<int> { 1, 2 } },
        { "1_1_2", new List<int> { 3 } },
        { "1_1_3", new List<int> { 2, 3 } },
        { "1_2_1", new List<int> { 2, 4 } },
        { "1_2_2", new List<int> { 3, 4 } },
        { "1_2_3", new List<int> { 4 } },
        { "1_3_1", new List<int> { 1, 2, 4 } },
        { "1_3_2", new List<int> { 3, 4 } },
        { "1_3_3", new List<int> { 2, 3, 4 } },
        { "1_4_1", new List<int> { 1, 2 } },
        { "1_4_2", new List<int> { 3, 4 } },
        { "1_4_3", new List<int> { 2, 3, 4 } },
        { "2_1_1", new List<int> { 1, 5 } },
        { "2_1_2", new List<int> { 3, 5 } },
        { "2_1_3", new List<int> { 1, 3, 5 } },
        { "2_2_1", new List<int> { 4, 5 } },
        { "2_2_2", new List<int> { 3, 5 } },
        { "2_2_3", new List<int> { 3, 4, 5 } },
        { "2_3_1", new List<int> { 1, 4, 5 } },
        { "2_3_2", new List<int> { 3, 5 } },
        { "2_3_3", new List<int> { 3, 4, 5 } },
        { "2_4_1", new List<int> { 1, 4, 5 } },
        { "2_4_2", new List<int> { 3, 5 } },
        { "2_4_3", new List<int> { 3, 4, 5 } },
        { "3_1_1", new List<int> { 1, 2, 5 } },
        { "3_1_2", new List<int> { 3, 5 } },
        { "3_1_3", new List<int> { 1, 3, 5 } },
        { "3_2_1", new List<int> { 2, 4, 5 } },
        { "3_2_2", new List<int> { 3, 5 } },
        { "3_2_3", new List<int> { 2, 3, 5 } },
        { "3_3_1", new List<int> { 1, 2, 4, 5 } },
        { "3_3_2", new List<int> { 3, 5 } },
        { "3_3_3", new List<int> { 2, 3, 4, 5 } },
        { "3_4_1", new List<int> { 1, 2, 4, 5 } },
        { "3_4_2", new List<int> { 3, 5 } },
        { "3_4_3", new List<int> { 2, 3, 4, 5 } },
    };

            string key = $"{activityPreference}_{waterPreference}_{terrainPreference}";

            if (hotelRecommendations.ContainsKey(key))
            {
                var potentialHotels = hotelRecommendations[key];
                var random = new Random();
                var chosenHotelId = potentialHotels[random.Next(potentialHotels.Count)];
                var chosenHotel = hotelsRepository.GetHotel(chosenHotelId);

                Console.WriteLine($"\nHow about a trip to the {chosenHotel.City}? We hope you'll love it!");
            }
            else
            {
                Console.WriteLine("\nSorry, we couldn't find a destination matching your preferences.");
            }

            UserMenu.Menu();
        }

        public SearchPanel()
        private User _loggedUser;

        private List<Reservation> _searchedReservations;
        public SearchPanel(User loggedUser)
        {
            reservationsRepository = new ReservationsRepository();
            _searchedReservations = new List<Reservation>();
            _loggedUser = loggedUser;
        }

        public void OfferSearch()
        {
            Console.WriteLine("Search - choose option");
            Console.WriteLine("1. Search by filters");
            Console.WriteLine("2. Surprise me!");

            var choice = Console.ReadLine();

            if (choice == "2")
            {
                SurpriseMe();
                return;
            }

            var filters = new Dictionary<string, string>
            {
                { "Destination: ", "" },
                { "Check-in date (dd.mm.yyyy): ", "" },
                { "Check-out date (dd.mm.yyyy): ", "" },
                { "Check-in date dd.MM.yyyy: ", "" },
                { "Check-out date dd.MM.yyyy: ", "" },
                { "Amount of people: ", "" },
                { "Maximum cost per night: ", "" }
            };
            foreach (var filter in filters.Keys.ToList())
            {
                Console.WriteLine($"Enter a filter value '{filter}': ");
                filters[filter] = Console.ReadLine();
            }

            var reservation = reservationsRepository.GetReservations();

            var searchCity = filters["Destination: "];

            DateTime searchCheckInDate;
            DateTime.TryParse(filters["Check-in date (dd.mm.yyyy): "], out searchCheckInDate);
            DateTime.TryParse(filters["Check-in date dd.MM.yyyy: "], out searchCheckInDate);

            DateTime searchCheckOutDate;
            DateTime.TryParse(filters["Check-out date (dd.mm.yyyy): "], out searchCheckOutDate);

            int searchAmountOfPeople;
            int.TryParse(filters["Amount of people: "], out searchAmountOfPeople);

            decimal maxCostPerNight;
            decimal.TryParse(filters["Maximum cost per night: "], out maxCostPerNight);

            var results = reservation.Where(r =>
                (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
                (searchCheckInDate == DateTime.MinValue || r.ChecInDate >= searchCheckInDate) &&
                (searchCheckOutDate == DateTime.MinValue || r.CheckOutDate <= searchCheckOutDate) &&
                (searchAmountOfPeople == 0 || r.AmountOfPeople >= searchAmountOfPeople) &&
                (maxCostPerNight == 0 || r.CostPerNight <= maxCostPerNight)

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
                    Console.WriteLine($"{result.Hotel}");
                    Console.WriteLine($"Check-in date: {result.ChecInDate.ToShortDateString()}, Check-out date: {result.CheckOutDate.ToShortDateString()}, Amount of people: {result.AmountOfPeople}, Cost per night: {result.CostPerNight} ");
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
            }

            UserMenu.Menu();

        }

        private void CreateReservation()
        {
            if(_loggedUser == null)
            {
                Console.WriteLine("To make a reservation you must log in");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("If you want to make a reservation, select the reservation number. To cancel, press 0: ");
                bool isActionOK = Int32.TryParse(Console.ReadLine(), out int result);

                if(result > 0 && result <= _searchedReservations.Count)
                {
                    _loggedUser.MakeReservation(_searchedReservations.ElementAt(result - 1));
                    Console.WriteLine("Reservation complete");
                    Console.WriteLine();
                }

            }
        }

    }
}


