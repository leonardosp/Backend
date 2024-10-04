using AutoMapper;
using Test.Application.Models;
using Test.Domain.Motos.Commands;
using Test.Domain.Motos.Queries;

namespace Test.Application.Mapping.Moto;

public class MotoMapping : Profile
{
    public MotoMapping()
    {
        CreateMap<MotoViewModel, RegistrarMotoCommand>().ReverseMap();
        CreateMap<Domain.Motos.Moto, ObterMotoPorIdCommand>().ReverseMap();
        CreateMap<Domain.Motos.Moto, ObterMotoPorPlacaCommand>().ReverseMap();
        CreateMap<Domain.Motos.Moto, MotoViewModel>().ReverseMap();
    }
}
