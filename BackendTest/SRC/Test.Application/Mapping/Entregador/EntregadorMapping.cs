using AutoMapper;
using Test.Application.Models;
using Test.Domain.Entregadores.Commands;

namespace Test.Application.Mapping.Entregador;

public class EntregadorMapping : Profile
{
    public EntregadorMapping()
    {
        CreateMap<EntregadorViewModel, RegistrarEntregadorCommand>();
        CreateMap<Domain.Entregadores.Entregador, EntregadorViewModel>().ReverseMap();
        CreateMap<Domain.Entregadores.Entregador, AtualizarFotoEntregadorViewModel>().ReverseMap();
    }
}
