using System.Collections.Generic;
using HotelHero.HotelsDatabase;

namespace HotelHero.Interfaces
{
    public interface IHotelsRepository
    {
        void Create(Hotel hotel);
        void Delete(int id);
        Hotel GetHotel(int id);
        List<Hotel> GetHotels();
        void Update(Hotel model);
    }
}