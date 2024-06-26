namespace FrogPayAPI.Models
{
    public class Loja
    {
        public int IdLoja { get; set;}
        public string? Nome { get; set;}
        public string? CNPJ { get; set;}
        public int IdEndereco { get; set;}

        public Endereco Endereco { get; set;}

    }
}