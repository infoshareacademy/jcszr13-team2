using HotelHero.Database.Context;
using HotelHero.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelHero.Database.Repositiories.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelHeroDbContext _context;
        public ReservationRepository(HotelHeroDbContext context)
        {
            _context = context;
        }

        public void AddReservation(ReservationDTO reservationDTO)
        {
            _context.Reservations.Add(reservationDTO);
            _context.SaveChanges();
        }

        public List<ReservationDTO> GetAllReservations()
        {
            return _context.Reservations
                .Include(x => x.Hotel)
                .ToList();
        }

        public ReservationDTO GetReservation(int id)
        {
            return _context.Reservations
                .Include(x => x.Hotel)
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ReservationDTO> SearchForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople)
        {
            return _context.Reservations
                .Include(x => x.Hotel)
                .Where(r =>
                (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
                (!searchCheckInDate.HasValue || r.CheckInDate.Date >= searchCheckInDate.Value.Date) &&
                (!searchCheckOutDate.HasValue || r.CheckOutDate.Date <= searchCheckOutDate.Value.Date) &&
                (!searchAmountOfPeople.HasValue || r.AmountOfPeople >= searchAmountOfPeople.Value) &&
                r.Status == 0
                ).ToList();
        }

        public List<ReservationDTO> SearchWithFiltersForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople, decimal? costPerNight, int? stars, float? rating, bool isFreeWiFi, bool isPrivateParking, bool isRestaurant, bool isBar)
        {
            return _context.Reservations
                .Include(x => x.Hotel)
                .Where(r =>
                (string.IsNullOrEmpty(searchCity) || r.Hotel.City == searchCity) &&
                (!searchCheckInDate.HasValue || r.CheckInDate.Date >= searchCheckInDate.Value.Date) &&
                (!searchCheckOutDate.HasValue || r.CheckOutDate.Date <= searchCheckOutDate.Value.Date) &&
                (!searchAmountOfPeople.HasValue || r.AmountOfPeople >= searchAmountOfPeople.Value) &&
                (!costPerNight.HasValue || r.CostPerNight <= costPerNight.Value) &&
                (!stars.HasValue || r.Hotel.Stars >= stars.Value) &&
                (!rating.HasValue || r.Hotel.Rating >= rating.Value) &&
                (!isFreeWiFi || r.Hotel.IsFreeWiFi == isFreeWiFi) &&
                (!isPrivateParking || r.Hotel.IsPrivateParking == isPrivateParking) &&
                (!isRestaurant || r.Hotel.IsRestaurant == isRestaurant) &&
                (!isBar || r.Hotel.IsBar == isBar) &&
                r.Status == 0
                ).ToList();
        }


        public void RemoveHotel(int id)
        {
            ReservationDTO reservationDTO = GetReservation(id);
            _context.Remove(reservationDTO);
            _context.SaveChanges();
        }

        public void UpdateHotel(ReservationDTO reservationDTO)
        {
            _context.Update(reservationDTO);
            _context.SaveChanges();
        }
    }
}
