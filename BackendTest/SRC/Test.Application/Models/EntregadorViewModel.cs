using TTest.Application.Models.enums;

namespace Test.Application.Models;

public class EntregadorViewModel
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataNascimento { get; set; }
    public int NumeroCnh { get; set; }

    public CnhTipoViewModel TipoCnh { get; set; }
}
