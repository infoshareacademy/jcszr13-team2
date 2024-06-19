using HotelHero.HotelsDatabase;

namespace HotelHero.WebMVC.Interface
{
    public interface IHotelService
    {
        void Create(Hotel hotel);
        void Delete(int id);
        Hotel GetHotel(int id);
        List<Hotel> GetHotels();
        void Update(Hotel model);
    }
}