using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroMVP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;

    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categorias = await _service.ListarAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _service.BuscarPorIdAsync(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CriarCategoriaDto dto)
    {
        var categoria = await _service.CriarAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AtualizarCategoriaDto dto)
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