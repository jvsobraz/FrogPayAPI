namespace FrogPayAPI.Models
{
    public class Loja
    {
        public int IdLoja { get; set;}
        public int IdPessoa { get; set;}
        public string? Nome_fantasia { get; set;}
         public string? Razao_social { get; set;}
        public string? CNPJ { get; set;}
        public DateTime Data_abertura { get; set;}

        public Endereco? Endereco { get; set;}

    }
}