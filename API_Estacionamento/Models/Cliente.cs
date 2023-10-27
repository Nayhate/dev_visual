using System.ComponentModel.DataAnnotations;
namespace API_Estacionamento.Models;

public class Cliente
{
    [Key]
    public string? Cpf {get; set;}
    public string? Nome {get; set;}
    public List<Carro>? Carros {get; set;}
}
