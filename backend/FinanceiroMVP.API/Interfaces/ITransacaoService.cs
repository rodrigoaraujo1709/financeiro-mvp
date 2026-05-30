using FinanceiroMVP.API.DTOs;

namespace FinanceiroMVP.API.Interfaces;

public interface ITransacaoService
{
    Task<IEnumerable<TransacaoResponseDto>> ListarAsync();
    Task<TransacaoResponseDto?> BuscarPorIdAsync(int id);
    Task<TransacaoResponseDto> CriarAsync(CriarTransacaoDto dto);
    Task<bool> AtualizarAsync(int id, AtualizarTransacaoDto dto);
    Task<bool> ExcluirAsync(int id);
}