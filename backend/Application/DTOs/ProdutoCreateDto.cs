namespace ProductManager.Application.DTOs;

public class ProdutoCreateDto
{
    public string Nome { get; set; } = null!;
    public string SKU { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}