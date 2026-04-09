namespace ProductManager.Application.DTOs;

public class ProdutoResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string SKU { get; set; } = null!;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque {get; set;}
    public string Categoria { get; set; } = null!;
}