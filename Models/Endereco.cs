namespace FrogPayAPI.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public int IdPessoa { get; set; }
        public string? Uf_estado { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }

        public Pessoa? Pessoa { get; set; }
        public ICollection<Loja>? Lojas { get; set; }
    }
}