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

        public List<HotelDTO> GetAllHotel()
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
            _context.Update(hotelDTO);
            _context.SaveChanges();
        }

    }
}
