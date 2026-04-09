using ProductManager.Application.DTOs;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _repository;
    private readonly ILogger<ProdutoService> _logger;

    public ProdutoService(IProdutoRepository repository, ILogger<ProdutoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ProdutoResponseDto> CriarProduto(ProdutoCreateDto dto)
    {
        if (dto.QuantidadeEstoque < 0)
        {
            _logger.LogWarning("Estoque negativo");
            throw new Exception("Estoque não pode ser negativo");
        }

        if (dto.Categoria == "Eletrônicos" && dto.Preco < 50)
        {
            _logger.LogWarning("Preço inválido para eletrônicos");
            throw new Exception("Produtos eletrônicos devem custar no mínimo R$ 50");
        }

        if (await _repository.ExisteSKU(dto.SKU))
        {
            _logger.LogWarning("SKU duplicado: {SKU}", dto.SKU);
            throw new Exception("SKU já cadastrado");
        }

        var produto = new Produto
        {
            Nome = dto.Nome,
            SKU = dto.SKU,
            Categoria = dto.Categoria,
            Preco = dto.Preco,
            QuantidadeEstoque = dto.QuantidadeEstoque
        };

        await _repository.Add(produto);

        _logger.LogInformation("Produto criado: {Nome}", produto.Nome);

        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            SKU = produto.SKU,
            Preco = produto.Preco,
            QuantidadeEstoque = produto.QuantidadeEstoque
        };
    }

    public async Task<List<ProdutoResponseDto>> Listar(int page, int pageSize)
    {
        var produtos = await _repository.GetPaged(page, pageSize);

        return produtos.Select(p => new ProdutoResponseDto
        {
            Id = p.Id,
            Nome = p.Nome,
            SKU = p.SKU,
            Preco = p.Preco,
            QuantidadeEstoque = p.QuantidadeEstoque,
            Categoria = p.Categoria
        }).ToList();
    }

    public async Task<Produto?> ObterPorId(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task Atualizar(int id, ProdutoCreateDto dto)
    {
        var produto = await _repository.GetById(id);

        if (dto.Categoria == "Eletrônicos" && dto.Preco < 50)
        {
            _logger.LogWarning("Preço inválido para eletrônicos");
            throw new Exception("Produtos eletrônicos devem custar no mínimo R$ 50");
        }

        if (produto == null)
            throw new Exception("Produto não encontrado");

        produto.Nome = dto.Nome;
        produto.Preco = dto.Preco;
        produto.Categoria = dto.Categoria;
        produto.QuantidadeEstoque = dto.QuantidadeEstoque;

        await _repository.Update(produto);

        _logger.LogInformation("Produto atualizado: {Id}", id);
    }

    public async Task Remover(int id)
    {
        var produto = await _repository.GetById(id);

        if (produto == null)
            throw new Exception("Produto não encontrado");

        await _repository.Delete(produto);

        _logger.LogInformation("Produto removido: {Id}", id);
    }
}