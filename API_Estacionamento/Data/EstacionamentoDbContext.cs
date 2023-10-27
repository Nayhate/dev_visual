using API_Estacionamento.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Estacionamento.Data;
public class EstacionamentoDbContext : DbContext
{
    public DbSet<Marca>? Marca { get; set; }
    public DbSet<Modelo>? Modelo { get; set; }
    public DbSet<Cliente>? Cliente { get; set; }
    public DbSet<Carro>? Carro { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=estacionamento.db;Cache=Shared");
       // optionsBuilder.UseMySQL("Host=127.0.0.1;Port=3306;Database=estacionamento;User=root;Password=positivo");
    }
}