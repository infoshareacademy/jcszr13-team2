using HotelHero.Database.Entities;

namespace HotelHero.Database.Repositiories.Reservations
{
    public interface IReservationRepository
    {
        void AddReservation(ReservationDTO reservationDTO);
        List<ReservationDTO> GetAllReservations();
        ReservationDTO GetReservation(int id);
        void RemoveHotel(int id);
        List<ReservationDTO> SearchForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople);
        void UpdateHotel(ReservationDTO reservationDTO);
    }
}