using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using FrogpayAPI.Models;

namespace FrogPayAPI.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool? Ativo { get; set; }
        public TimestampAttribute? data_criacao { get; set; }

        public ICollection<DadosBancarios>? DadosBancarios { get; set; }
        public ICollection<Endereco>? Enderecos { get; set; }
    }
}