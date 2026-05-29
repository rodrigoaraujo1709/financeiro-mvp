using FinanceiroMVP.API.Data;
using FinanceiroMVP.API.DTOs;
using FinanceiroMVP.API.Interfaces;
using FinanceiroMVP.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroMVP.API.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> ListarAsync()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria?> BuscarPorIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> CriarAsync(CriarCategoriaDto dto)
    {
        var categoria = new Categoria
        {
            Nome = dto.Nome,
            Cor = dto.Cor,
            Icone = dto.Icone
        };

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<bool> AtualizarAsync(int id, AtualizarCategoriaDto dto)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return false;

        categoria.Nome = dto.Nome;
        categoria.Cor = dto.Cor;
        categoria.Icone = dto.Icone;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
            return false;

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return true;
    }
}