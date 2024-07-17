using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface ICustomerDataService
    {
        Models.CustomerData GetCustomerData();
        void Save(Models.CustomerData data);

        public List<Reservation> GetReservation();
        public void MakeReservation(Reservation newReservation);
        public void CancelReservation(Reservation newReservation);
    }
}
