using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Models;

namespace FinanceiroMVP.API.Interfaces;

public interface ITransacaoService
{
    Task<IEnumerable<Transacao>> ListarAsync();
    Task<Transacao?> BuscarPorIdAsync(int id);
    Task<Transacao> CriarAsync(CriarTransacaoDto dto);
    Task<bool> AtualizarAsync(int id, AtualizarTransacaoDto dto);
    Task<bool> ExcluirAsync(int id);
}