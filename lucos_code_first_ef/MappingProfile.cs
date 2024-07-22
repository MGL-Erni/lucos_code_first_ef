using lucos_code_first_ef.Dto;
using lucos_code_first_ef.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
   
        CreateMap<Player, PlayerDTO>().ReverseMap();
        CreateMap<Game, GameDTO>().ReverseMap();
        CreateMap<Opening, OpeningDTO>().ReverseMap();
    }
}