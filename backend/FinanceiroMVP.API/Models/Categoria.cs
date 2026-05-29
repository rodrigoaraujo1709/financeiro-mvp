namespace FinanceiroMVP.API.Models;

public class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Cor { get; set; }

    public string? Icone { get; set; }

    public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
}