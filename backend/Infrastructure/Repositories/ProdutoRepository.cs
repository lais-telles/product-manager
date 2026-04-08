using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;
using ProductManager.Infrastructure.Data;

namespace ProductManager.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> GetPaged(int page, int pageSize)
    {
        return await _context.Produtos
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Produto?> GetById(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }

    public async Task<bool> ExisteSKU(string sku)
    {
        return await _context.Produtos.AnyAsync(p => p.SKU == sku);
    }

    public async Task Add(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}