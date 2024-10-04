using Microsoft.AspNetCore.Mvc;
using Test.Application.Models;
using Test.Application.Services.Entregador.Interface;

namespace Test.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EntregadoresController : ControllerBase
{
    private readonly IEntregadorAppService _entregadorAppService;
    public EntregadoresController(IEntregadorAppService entregadorAppService)
    {
        _entregadorAppService = entregadorAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(EntregadorViewModel entregador)
    {
        var result = await _entregadorAppService.RegistrarEntregador(entregador);

        if (result.IsValid)
        {
            return Ok("Entregador cadastrado com sucesso!");
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpPost("cnh")]
    public async Task<IActionResult> Cnh(AtualizarFotoEntregadorViewModel entregadorViewModel)
    {
        var result = await _entregadorAppService.AtualizarFotoEntregador(entregadorViewModel);

        if (result.IsValid)
        {
            return Ok("Entregador cadastrado com sucesso!");
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }
}
