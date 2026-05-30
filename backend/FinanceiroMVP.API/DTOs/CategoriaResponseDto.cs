namespace FinanceiroMVP.API.DTOs;

public class CategoriaResponseDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Cor { get; set; }

    public string? Icone { get; set; }
}