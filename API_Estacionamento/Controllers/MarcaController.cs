using API_Estacionamento.Data;
using API_Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_Estacionamento.Controllers;
[ApiController]
[Route("[controller]")]
public class MarcaController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public MarcaController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Marca marca)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(marca);
        await _dbContext.SaveChangesAsync();
        return Created("",marca);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Marca>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Marca is null) return BadRequest();
        return await _dbContext.Marca.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Marca>> Buscar(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Marca is null) return BadRequest();
        var marcaTemp = await _dbContext.Marca.FindAsync(id);
        if(marcaTemp is null) return BadRequest();
        return marcaTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Marca marca)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Marca is null) return BadRequest();
        var marcaTemp = await _dbContext.Marca.FindAsync(marca.Id);
        if(marcaTemp is null) return BadRequest();       
        marcaTemp.Nome = marca.Nome;
        _dbContext.Marca.Update(marca);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Marca is null) return BadRequest();
        var marcaTemp = await _dbContext.Marca.FindAsync(id);
        if(marcaTemp is null) return BadRequest();
        _dbContext.Remove(marcaTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
