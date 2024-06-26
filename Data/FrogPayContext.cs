using Microsoft.EntityFrameworkCore;
using FrogPayAPI.Models;
using FrogpayAPI.Models;

namespace FrogPayAPI.Data
{
public class FrogPayContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DadosBancarios> DadosBancarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Loja> Lojas { get; set; }

        public FrogPayContext(DbContextOptions<FrogPayContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>().HasKey(p => p.IdPessoa);
        modelBuilder.Entity<DadosBancarios>().HasKey(d => d.IdDadosBancarios);
        modelBuilder.Entity<Endereco>().HasKey(e => e.IdEndereco);
        modelBuilder.Entity<Loja>().HasKey(l => l.IdLoja);

       modelBuilder.Entity<DadosBancarios>()
                .HasOne<Pessoa>()
                .WithMany()
                .HasForeignKey(d => d.IdPessoa);

            modelBuilder.Entity<Endereco>()
                .HasOne<Pessoa>()
                .WithMany()
                .HasForeignKey(e => e.IdPessoa);

            modelBuilder.Entity<Loja>()
                .HasOne<Pessoa>()
                .WithMany()
                .HasForeignKey(e => e.IdLoja);
    }
    }
}