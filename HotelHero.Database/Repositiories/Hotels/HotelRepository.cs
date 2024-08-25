using HotelHero.Database.Context;
using HotelHero.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Repositiories.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelHeroDbContext _context;

        public HotelRepository(HotelHeroDbContext context)
        {
            _context = context;
        }

        public void AddHotel(HotelDTO hotelDTO)
        {
            _context.Hotels.Add(hotelDTO);
            _context.SaveChanges();
        }

        public List<HotelDTO> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }

        public HotelDTO GetHotel(int id)
        {
            return _context.Hotels.Where(x => x.Id == id).FirstOrDefault();
        }

        public void RemoveHotel(int id)
        {
            HotelDTO hotelDTO = GetHotel(id);
            _context.Remove(hotelDTO);
            _context.SaveChanges();
        }

        public void UpdateHotel(HotelDTO hotelDTO)
        {
            var hotel = GetHotel(hotelDTO.Id);

            hotel.Name = hotelDTO.Name;
            hotel.Address = hotelDTO.Address;
            hotel.City = hotelDTO.City;
            hotel.Description = hotelDTO.Description;
            hotel.Image = hotelDTO.Image;
            hotel.Stars = hotelDTO.Stars;
            hotel.Rating = hotelDTO.Rating;
            hotel.IsFreeWiFi = hotelDTO.IsFreeWiFi;
            hotel.IsPrivateParking = hotelDTO.IsPrivateParking;
            hotel.IsRestaurant = hotelDTO.IsRestaurant;
            hotel.IsBar = hotelDTO.IsBar;

            _context.SaveChanges();
        }

    }
}
