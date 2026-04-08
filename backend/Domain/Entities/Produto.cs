namespace ProductManager.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string SKU { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}