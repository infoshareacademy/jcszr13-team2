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
            CreateMap<Database.Entities.AdditionalService, Models.AdditionalService>()
                .ForMember(x => x.Id, y => y.Ignore());
            CreateMap<Database.Entities.HotelUser, Models.User>()
                    .ForMember(x =>x.Password, y=>y.MapFrom(x=>x.PasswordHash))
                    .
                .ForMember(x => x.Email, y => y.MapFrom(x => x.Email));
            CreateMap<Database.Entities.CustomerData, Models.CustomerData>().ReverseMap();
            CreateMap<Database.Entities.Payment, Models.Payment>()
                .ForMember(x => x.UserId, y => y.Ignore());

        n
        }
    }
}
