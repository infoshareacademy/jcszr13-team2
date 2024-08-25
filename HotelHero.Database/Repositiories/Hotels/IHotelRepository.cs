using HotelHero.Database.Entities;

namespace HotelHero.Database.Repositiories.Hotels
{
    public interface IHotelRepository
    {
        void AddHotel(HotelDTO hotelDTO);
        List<HotelDTO> GetAllHotel();
        HotelDTO GetHotel(int id);
        void RemoveHotel(int id);
        void UpdateHotel(HotelDTO hotelDTO);
    }
}