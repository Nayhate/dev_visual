using System.ComponentModel.DataAnnotations;
namespace API_Estacionamento.Models;

public class Carro
{
    [Key]
    public string? Placa {get; set;}
    public int? ModeloId {get; set;}
    public Modelo? Modelo {get; set;}
    public string? Descricao {get; set;}
    public List<Cliente>? Cliente {get; set;}
}
