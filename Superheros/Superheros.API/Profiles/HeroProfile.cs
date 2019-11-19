using AutoMapper;
using Superheros.API.DTO;
using Superheros.API.Models;
using System;

namespace Superheros.API.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Guid, GetHeroRequest>()
                .ForMember(destination => destination.Id, option => option.MapFrom(origin => origin));

            CreateMap<Guid, DeleteHeroRequest>()
                .ForMember(destination => destination.Id, option => option.MapFrom(origin => origin));

            CreateMap<CreateHeroRequest, Hero>()
                .ForMember(destination => destination.Id, option => option.MapFrom(origin => Guid.NewGuid()));

            CreateMap<UpdateHeroRequest, Hero>();

            CreateMap<Hero, HeroResponse>();
        }
    }
}
