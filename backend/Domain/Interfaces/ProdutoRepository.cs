using ProductManager.Domain.Entities;

namespace ProductManager.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> GetPaged(int page, int pageSize);
    Task<Produto?> GetById(int id);
    Task Add(Produto produto);
    Task Update(Produto produto);
    Task Delete(Produto produto);
    Task<bool> ExisteSKU(string sku);
}