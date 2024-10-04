using AutoMapper;
using Test.Application.Models;
using Test.Domain.Alugueis.Commands;

namespace Test.Application.Mapping.Aluguel;

public class AluguelMapping : Profile
{
    public AluguelMapping()
    {
        CreateMap<AluguelViewModel, RegistrarAluguelCommand>();
        CreateMap<Domain.Alugueis.Aluguel, AluguelViewModel>().ReverseMap();
    }
}
