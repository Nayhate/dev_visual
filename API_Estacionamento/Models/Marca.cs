using System.ComponentModel.DataAnnotations;
namespace API_Estacionamento.Models;

public class Marca
{
    [Key]
    public int? Id {get; set;}
    public string? Nome {get; set;}
}
