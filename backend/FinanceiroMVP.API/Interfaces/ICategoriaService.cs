using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Models;

namespace FinanceiroMVP.API.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> ListarAsync();
    Task<Categoria?> BuscarPorIdAsync(int id);
    Task<Categoria> CriarAsync(CriarCategoriaDto dto);
    Task<bool> AtualizarAsync(int id, AtualizarCategoriaDto dto);
    Task<bool> ExcluirAsync(int id);
}