using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.DTOs;
using ProductManager.Application.Services;

namespace ProductManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutosController(ProdutoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(ProdutoCreateDto dto)
    {
        try
        {
            var produto = await _service.CriarProduto(dto);
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar(int page = 1, int pageSize = 10)
    {
        return Ok(await _service.Listar(page, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id)
    {
        var produto = await _service.ObterPorId(id);

        if (produto == null)
            return NotFound("Produto não encontrado");

        return Ok(produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, ProdutoCreateDto dto)
    {
        try
        {
            await _service.Atualizar(id, dto);
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        try
        {
            await _service.Remover(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}