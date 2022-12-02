using AutoMapper;
using CursosAPI.Data.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles;


public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<CreateVideoDto, Video>();
        CreateMap<Video, ReadVideoDto>();
        CreateMap<UpdateVideoDto, Video>();
    }
}
