namespace FrogPayAPI.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<DadosBancarios> DadosBancarios { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}