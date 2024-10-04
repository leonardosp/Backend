using System.ComponentModel.DataAnnotations;

namespace Test.Application.Models;

public class AluguelViewModel
{
    [Required]
    public DateTime DataInicio { get;  set; }
    [Required]
    public DateTime DataTermino { get;  set; }
    [Required]
    public DateTime DataPrevisaoFim { get;  set; }
    public DateTime DataDevolucao { get;  set; }
    public decimal? ValorTotal { get;  set; }
    public decimal? ValorPrevisto { get;  set; }

    public Guid EntregadorId { get;  set; }
    public Guid MotoId { get;  set; }
}
