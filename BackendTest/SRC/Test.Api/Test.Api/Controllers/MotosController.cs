using Microsoft.AspNetCore.Mvc;
using Test.Application.Models;
using Test.Application.Services.Motos.Interface;
using Test.Cross.Utils;

namespace Test.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MotosController : Controller
{
    private readonly IMotoAppService _motoAppService;

    public MotosController(IMotoAppService motoAppService)
    {
        _motoAppService = motoAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MotoViewModel motoViewModel)
    {
        var result = await _motoAppService.RegistrarMoto(motoViewModel);

        if (result.IsValid)
        {
            return Ok();
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(string placa)
    {

        var result = await _motoAppService.ObterMotoPorPlaca(placa);
        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest($"Moto com Placa: {placa} não encontrada!");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid Id, string placa)
    {
        var result = await _motoAppService.AtualizarPlacaMoto(Id, placa);

        if (result.IsValid)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetId(Guid Id)
    {

        var result = await _motoAppService.ObterMotoPorId(Id);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest($"Moto com Id: {Id} não encontrada!");
        }
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _motoAppService.RemoverMotoPorId(Id);

        if (result.IsValid)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }
}
