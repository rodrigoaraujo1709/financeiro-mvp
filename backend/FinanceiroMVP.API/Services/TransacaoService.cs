using FinanceiroMVP.API.Data;
using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Interfaces;
using FinanceiroMVP.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroMVP.API.Services;

public class TransacaoService : ITransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

public async Task<IEnumerable<TransacaoResponseDto>> ListarAsync()
{
    var transacoes = await _context.Transacoes
        .Include(t => t.Categoria)
        .ToListAsync();

    return transacoes.Select(t => new TransacaoResponseDto
    {
        Id = t.Id,
        Descricao = t.Descricao,
        Valor = t.Valor,
        Data = t.Data,
        Tipo = t.Tipo,
        Categoria = t.Categoria == null
            ? null
            : new CategoriaResponseDto
            {
                Id = t.Categoria.Id,
                Nome = t.Categoria.Nome,
                Cor = t.Categoria.Cor,
                Icone = t.Categoria.Icone
            }
    });
}

public async Task<TransacaoResponseDto?> BuscarPorIdAsync(int id)
{
    var transacao = await _context.Transacoes
        .Include(t => t.Categoria)
        .FirstOrDefaultAsync(t => t.Id == id);

    if (transacao == null)
        return null;

    return new TransacaoResponseDto
    {
        Id = transacao.Id,
        Descricao = transacao.Descricao,
        Valor = transacao.Valor,
        Data = transacao.Data,
        Tipo = transacao.Tipo,
        Categoria = transacao.Categoria == null
            ? null
            : new CategoriaResponseDto
            {
                Id = transacao.Categoria.Id,
                Nome = transacao.Categoria.Nome,
                Cor = transacao.Categoria.Cor,
                Icone = transacao.Categoria.Icone
            }
    };
}

public async Task<TransacaoResponseDto> CriarAsync(CriarTransacaoDto dto)
{
    var transacao = new Transacao
    {
        Descricao = dto.Descricao,
        Valor = dto.Valor,
        Data = dto.Data,
        Tipo = dto.Tipo,
        CategoriaId = dto.CategoriaId
    };

    _context.Transacoes.Add(transacao);
    await _context.SaveChangesAsync();

    var transacaoCriada = await _context.Transacoes
        .Include(t => t.Categoria)
        .FirstAsync(t => t.Id == transacao.Id);

    return new TransacaoResponseDto
    {
        Id = transacaoCriada.Id,
        Descricao = transacaoCriada.Descricao,
        Valor = transacaoCriada.Valor,
        Data = transacaoCriada.Data,
        Tipo = transacaoCriada.Tipo,
        Categoria = transacaoCriada.Categoria == null
            ? null
            : new CategoriaResponseDto
            {
                Id = transacaoCriada.Categoria.Id,
                Nome = transacaoCriada.Categoria.Nome,
                Cor = transacaoCriada.Categoria.Cor,
                Icone = transacaoCriada.Categoria.Icone
            }
    };
}

    public async Task<bool> AtualizarAsync(int id, AtualizarTransacaoDto dto)
    {
        var transacao = await _context.Transacoes.FindAsync(id);

        if (transacao == null)
            return false;

        transacao.Descricao = dto.Descricao;
        transacao.Valor = dto.Valor;
        transacao.Data = dto.Data;
        transacao.Tipo = dto.Tipo;
        transacao.CategoriaId = dto.CategoriaId;
        

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var transacao = await _context.Transacoes.FindAsync(id);

        if (transacao == null)
            return false;

        _context.Transacoes.Remove(transacao);
        await _context.SaveChangesAsync();

        return true;
    }
}