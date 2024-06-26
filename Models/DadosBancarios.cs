using FrogPayAPI.Models;

namespace FrogpayAPI.Models
{
    public class DadosBancarios
    {
        public int IdDadosBancarios { get; set;}
        public int IdPessoa { get; set;}
        public string? Banco { get; set;}
        public string? Agencia { get; set;}
        public string? Conta { get; set;}

        public Pessoa Pessoa { get; set; }
    }
}