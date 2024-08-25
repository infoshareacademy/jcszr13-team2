using AutoMapper;
using HotelHero.Database.Entities;
using HotelHero.Database.Repositiories.Hotels;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Interface;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;


namespace HotelHero.WebMVC.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public List<Hotel> GetHotels()
        {
            List<HotelDTO> hotelDTO =  _hotelRepository.GetAllHotels();
            List<Hotel> hotels = _mapper.Map<List<Hotel>>(hotelDTO);
            return hotels;
        }

        public Hotel GetHotel(int id)
        {
            HotelDTO hotelDTO = _hotelRepository.GetHotel(id);
            Hotel hotel = _mapper.Map<Hotel>(hotelDTO);
            return hotel;
        }

        public void Create(Hotel hotel)
        {
            HotelDTO hotelDTOs = _mapper.Map<HotelDTO>(hotel);
            _hotelRepository.AddHotel(hotelDTOs);
        }

        public void Update(Hotel model)
        {
            HotelDTO hotelDTO = _mapper.Map<HotelDTO>(model);
            _hotelRepository.UpdateHotel(hotelDTO);
        }

        public void Delete(int id)
        {
            _hotelRepository.RemoveHotel(id);
        }
    }
}
