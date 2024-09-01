using Newtonsoft.Json;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models.Enums;

namespace HotelHero.WebMVC.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private string _filePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Data/CustomerData.json";
        private List<CustomerData>? _allCustomerData;


        public List<CustomerData> GetAllCustomerData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var customerDataJson = File.ReadAllText(_filePath);
                    _allCustomerData = JsonConvert.DeserializeObject<List<CustomerData>>(customerDataJson);
                }
            }
            catch
            {
                _allCustomerData = new List<CustomerData>()
                {
                    new CustomerData(1, "admin", "ad", "min", new(), "adres", "number", new(), new(), false, false, 0m)
                };
            }

            return _allCustomerData;
        }
        public void SaveAllCustomerData(List<CustomerData> data)
        {
            var listJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, listJson);
        }
        public CustomerData GetCustomerData(int customerId)
        {
            var allData = GetAllCustomerData();
            var customerData = allData.Find(x => x.CustomerId == customerId);
            if (customerData == null)
            {
                customerData = new() { CustomerId = customerId, Email = UserContext.loggedUser.Email, Reservations = new List<Reservation>(), Favourites = new List<int>() };
                CreateCustomerData(customerData);
            }
            return customerData;
        }
        public void CreateCustomerData(CustomerData customerData)
        {
            var data = GetAllCustomerData();
            data.Add(customerData);
            SaveAllCustomerData(data);
        }
        public void EditCustomerData(CustomerData customerData)
        {
            var data = GetAllCustomerData();
            var index = data.FindIndex(x => x.CustomerId == UserContext.loggedUser.UserId);
            data[index] = customerData;
            SaveAllCustomerData(data);
        }


        public void MakeReservation(int customerId, Reservation newReservation)
        {
            var customerData = GetCustomerData(UserContext.loggedUser.UserId);
            if (customerData.Reservations == null)
            {
                customerData.Reservations = new List<Reservation>();
            }
            newReservation.Status = ReservationStatus.Reserved;
            customerData.Reservations.Add(newReservation);
            EditCustomerData(customerData);
        }
        public void PayReservation(Reservation reservation)
        {
            var customerData = GetCustomerData(UserContext.loggedUser.UserId);
            EditCustomerData(customerData);
        }
        public void CancelReservation(int reservationId)
        {
            var customerData = GetCustomerData(UserContext.loggedUser.UserId);
            var cancelReservation = customerData.Reservations.Find(x => x.Id == reservationId);
            customerData.Reservations.Remove(cancelReservation);
            EditCustomerData(customerData);
        }
    }
}