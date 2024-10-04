using System.ComponentModel.DataAnnotations;

namespace Test.Application.Models;

public class MotoViewModel
{
    [Required]
    public int Ano { get;  set; }
    [Required]
    public string Modelo { get;  set; }
    [Required]
    public string Placa { get;  set; }
}
