namespace HotelHero.WebMVC.Interface
{
    public interface ICustomerDataService
    {
        Models.CustomerData GetCustomerData();
        void Save(Models.CustomerData data);
    }
}
