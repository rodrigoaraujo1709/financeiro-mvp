namespace FinanceiroMVP.API.DTOs;

public class CriarCategoriaDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Cor { get; set; }
    public string? Icone { get; set; }
}