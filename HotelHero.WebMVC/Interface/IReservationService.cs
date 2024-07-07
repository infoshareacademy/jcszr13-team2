using HotelHero.ReservationsDatabase;

namespace HotelHero.WebMVC.Interface
{
    public interface IReservationService
    {
        Reservation GetReservation(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople);
        List<Reservation> GetReservations();
    }
}