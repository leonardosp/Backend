using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;

namespace Test.Application.Models;

public class AtualizarFotoEntregadorViewModel
{
    public Guid Id { get; set; }
    public IFormFile ImagemUpload { get; set; }
    [IgnoreDataMember]
    public string Imagem { get; set; }
}
