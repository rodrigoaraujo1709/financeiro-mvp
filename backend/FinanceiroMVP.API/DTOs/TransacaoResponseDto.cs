namespace FinanceiroMVP.API.DTOs;

public class TransacaoResponseDto
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public string Tipo { get; set; } = string.Empty;

    public CategoriaResponseDto? Categoria { get; set; }
}