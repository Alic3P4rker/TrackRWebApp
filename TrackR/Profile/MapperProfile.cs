using AutoMapper;
using TrackR.API.Entities;
using TrackR.Commands;
using TrackR.Models;

namespace TrackR.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
        CreateMap<UserEntity, UserDetailsDto>();

        CreateMap<CreateApplicationCommand, ApplicationEntity>();
        CreateMap<ApplicationEntity, Application>().ReverseMap();
    }
}