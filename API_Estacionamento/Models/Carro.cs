namespace API_Estacionamento.Models;

using System.ComponentModel.DataAnnotations;

public class Carro
{
    [Key]
    public string? Placa {get; set;}
    public string? Descricao {get; set;}

}
