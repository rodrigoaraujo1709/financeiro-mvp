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

    public async Task<IEnumerable<Transacao>> ListarAsync()
    {
        return await _context.Transacoes.ToListAsync();
    }

    public async Task<Transacao?> BuscarPorIdAsync(int id)
    {
        return await _context.Transacoes.FindAsync(id);
    }

    public async Task<Transacao> CriarAsync(CriarTransacaoDto dto)
    {
        var transacao = new Transacao
        {
            Descricao = dto.Descricao,
            Valor = dto.Valor,
            Data = dto.Data,
            Tipo = dto.Tipo
        };

        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();

        return transacao;
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