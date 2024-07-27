using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface ICustomerDataService
    {
        public List<CustomerData> GetAllCustomerData();
        public void SaveAllCustomerData(List<CustomerData> data);
        public CustomerData GetCustomerData(int customerId);
        public void CreateCustomerData(CustomerData customerData);
        public void EditCustomerData(CustomerData customerData);
        public void MakeReservation(int customerId, Reservation newReservation);
        public void PayReservation(Reservation reservation);
        public void CancelReservation(int reservationId);
    }
}
