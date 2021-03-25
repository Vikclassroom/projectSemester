using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Link, LinkDto>();
        }
    }
}
