using HotelHero.Database.Entities;

namespace HotelHero.Database.Repositiories.Reservations
{
    public interface IReservationRepository
    {
        void AddReservation(ReservationDTO reservationDTO);
        void CancelReservation(int reservationId);
        List<ReservationDTO> GetAllReservations();
        ReservationDTO GetReservation(int id);
        void MakeReservation(int reservationId, string userEmail);
        void PayReservation(int reservationId);
        void RemoveHotel(int id);
        List<ReservationDTO> SearchForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople);
        List<ReservationDTO> SearchWithFiltersForReservations(string searchCity, DateTime? searchCheckInDate, DateTime? searchCheckOutDate, int? searchAmountOfPeople, decimal? costPerNight, int? stars, float? rating, bool isFreeWiFi, bool isPrivateParking, bool isRestaurant, bool isBar);
        void UpdateHotel(ReservationDTO reservationDTO);
    }
}