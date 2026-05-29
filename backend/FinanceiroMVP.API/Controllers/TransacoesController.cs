using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroMVP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ITransacaoService _service;

    public TransacoesController(ITransacaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var transacoes = await _service.ListarAsync();
        return Ok(transacoes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var transacao = await _service.BuscarPorIdAsync(id);

        if (transacao == null)
            return NotFound();

        return Ok(transacao);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CriarTransacaoDto dto)
    {
        var transacao = await _service.CriarAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = transacao.Id }, transacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AtualizarTransacaoDto dto)
    {
        var atualizado = await _service.AtualizarAsync(id, dto);

        if (!atualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var excluido = await _service.ExcluirAsync(id);

        if (!excluido)
            return NotFound();

        return NoContent();
    }
}