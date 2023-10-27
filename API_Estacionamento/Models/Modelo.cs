using System.ComponentModel.DataAnnotations;
namespace API_Estacionamento.Models;

public class Modelo
{
    [Key]
    public int? Id {get; set;}
    public int? MarcaId {get;set;}
    public Marca? Marca {get;set;}
    public string? Nome {get; set;}
}
