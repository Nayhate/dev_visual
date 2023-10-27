using API_Estacionamento.Data;
using API_Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_Estacionamento.Controllers;
[ApiController]
[Route("[controller]")]
public class ModeloController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ModeloController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Modelo modelo)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(modelo);
        await _dbContext.SaveChangesAsync();
        return Created("",modelo);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Modelo>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Modelo is null) return BadRequest();
        return await _dbContext.Modelo.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Modelo>> Buscar(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.Modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        return modeloTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Modelo modelo)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.Modelo.FindAsync(modelo.Id);
        if(modeloTemp is null) return BadRequest();
        modeloTemp.MarcaId = modelo.MarcaId;
        modeloTemp.Marca = modelo.Marca;
        modeloTemp.Nome = modelo.Nome;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Modelo is null) return BadRequest();
        var modeloTemp = await _dbContext.Modelo.FindAsync(id);
        if(modeloTemp is null) return BadRequest();
        _dbContext.Remove(modeloTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
