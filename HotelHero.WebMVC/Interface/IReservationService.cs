using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface IReservationService
    {
        List<Reservation> SearchForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople);
        List<Reservation> GetReservations();

        Reservation GetReservationById(int id);
        List<Reservation> SearchWithFiltersForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople, decimal? costPerNight);
    }
}