using API_Estacionamento.Data;
using API_Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_Estacionamento.Controllers;
[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public ClienteController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Cliente cliente)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("",cliente);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Cliente is null) return BadRequest();
        return await _dbContext.Cliente.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{cpf}")]
    public async Task<ActionResult<Cliente>> Buscar(string cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.Cliente.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        return clienteTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.Cliente.FindAsync(cliente.Cpf);
        if(clienteTemp is null) return BadRequest();
        clienteTemp.Nome = cliente.Nome;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{cpf}")]
    public async Task<ActionResult> Excluir(string cpf)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Cliente is null) return BadRequest();
        var clienteTemp = await _dbContext.Cliente.FindAsync(cpf);
        if(clienteTemp is null) return BadRequest();
        _dbContext.Remove(clienteTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
