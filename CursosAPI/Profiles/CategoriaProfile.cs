using AutoMapper;
using CursosAPI.Data.Dtos;
using CursosAPI.Models;

namespace CursosAPI.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<Categoria, ReadCategoriaDto>();
        CreateMap<UpdateCategoriaDto, Categoria>();
    }
}
