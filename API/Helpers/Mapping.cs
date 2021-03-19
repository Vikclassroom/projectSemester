using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Link, LinkDto>()
                .ForMember(d => d.AccountId, o => o.MapFrom(s => s.Account.AccountId))
                .ForMember(d => d.MusicId, o => o.MapFrom(s => s.Music.MusicId));
        }
    }
}
