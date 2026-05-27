using FinanceiroMVP.API.Data;
using FinanceiroMVP.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroMVP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransacoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transacao>>> Get()
    {
        return await _context.Transacoes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transacao>> GetById(int id)
    {
        var transacao = await _context.Transacoes.FindAsync(id);

        if (transacao == null)
            return NotFound();

        return transacao;
    }

    [HttpPost]
    public async Task<ActionResult<Transacao>> Post(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = transacao.Id }, transacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Transacao transacao)
    {
        if (id != transacao.Id)
            return BadRequest();

        _context.Entry(transacao).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var transacao = await _context.Transacoes.FindAsync(id);

        if (transacao == null)
            return NotFound();

        _context.Transacoes.Remove(transacao);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}