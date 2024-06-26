using Microsoft.EntityFrameworkCore;
using FrogPayAPI.Models;
using FrogpayAPI.Models;

namespace FrogPayAPI.Data
{
public class FrogPayContext : DbContext
{
    public FrogPayContext(DbContextOptions<FrogPayContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<DadosBancarios> DadosBancarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Loja> Lojas { get; set; }

}
}