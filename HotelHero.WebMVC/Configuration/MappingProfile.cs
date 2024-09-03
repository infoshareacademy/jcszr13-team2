using AutoMapper;
using HotelHero.Database.Context;
using HotelHero.Database.Entities;
using HotelHero.WebMVC.Models;
using NuGet.Protocol;

namespace HotelHero.WebMVC.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //CreateMap<Database.Entities.AdditionalServiceDTO, Models.AdditionalService>()
            //    .ForMember(x => x.Id, y => y.Ignore());
            //CreateMap<Database.Entities.HotelUserDTO, Models.User>()
            //        .ForMember(x =>x.Password, y=>y.MapFrom(x=>x.PasswordHash))
            //        .
            //    .ForMember(x => x.Email, y => y.MapFrom(x => x.Email));
            //CreateMap<Database.Entities.CustomerDataDTO, Models.CustomerData>().ReverseMap();
            //CreateMap<Database.Entities.PaymentDTO, Models.Payment>()
            //    .ForMember(x => x.UserId, y => y.Ignore());

            CreateMap<HotelDTO, Hotel>();
            CreateMap<Hotel, HotelDTO>();  

            CreateMap<ReservationDTO, Reservation>()
                .ForMember(x => x.Hotel, y => y.MapFrom(z => z.Hotel))
                .ForMember(x => x.ReservationUser, y => y.Ignore());
            CreateMap<Reservation, ReservationDTO>()
                .ForMember(x => x.CustomerDataId, y => y.Ignore())
                .ForMember(x => x.CustomerData, y => y.Ignore())
                .ForMember(x => x.PaymentId, y => y.Ignore())
                .ForMember(x => x.Payment, y => y.Ignore());


            CreateMap<ReservationDTO, ReservationData>();
        }
    }
}
