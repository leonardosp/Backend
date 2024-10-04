using Microsoft.AspNetCore.Mvc;
using Test.Application.Models;
using Test.Application.Services.Aluguel.Interface;

namespace Test.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlugueisController : Controller
{
    private readonly IAluguelAppService _aluguelAppService;

    public AlugueisController(IAluguelAppService aluguelAppService)
    {
        _aluguelAppService = aluguelAppService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(AluguelViewModel aluguelViewModel)
    {
        var result = await _aluguelAppService.RegistrarAluguel(aluguelViewModel);

        if (result.IsValid)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _aluguelAppService.ObterAluguelPorId(id);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest($"Aluguel com Id: {id} não encontrado!");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id, DateTime dataDevolucao)
    {
        var result = await _aluguelAppService.ObterValorAluguel(id, dataDevolucao);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest($"Aluguel com Id: {id} não encontrado!");
        }
    }
}
