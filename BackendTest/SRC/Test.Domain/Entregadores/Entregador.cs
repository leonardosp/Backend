using Test.Cross.Utils;
using Test.Domain.Alugueis;

namespace Test.Domain.Entregadores;

public class Entregador : Entity
{
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }   
    public DateTime DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public int NumeroCnh { get; private set; }
    public CnhTipo TipoCnh { get; private set; }
    public string? ImagemCNH { get; private set; }

    public Entregador(string nome, string cnpj, DateTime dataNascimento, DateTime dataCadastro, int numeroCnh, CnhTipo tipoCnh)
    {
        Nome = nome;
        Cnpj = cnpj;
        DataNascimento = dataNascimento;
        DataCadastro = dataCadastro;
        NumeroCnh = numeroCnh;
        TipoCnh = tipoCnh;
    }

    public Entregador(Guid id, string imagem)
    {
        Id = id;
        ImagemCNH = imagem;
    }

    public void SetarImagem(string imagem)
    {
        ImagemCNH = imagem;
    }

    public IEnumerable<Aluguel> Alugueis { get; set; }
}
