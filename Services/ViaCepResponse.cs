namespace Desafio_Fullstack_Accenture.Services
{
    public class ViaCepResponse
    {
        public required string cep {  get; set; }
        public required string logradouro { get; set; }
        public required string complemento { get; set; }
        public required string bairro { get; set; }
        public required string localidade { get; set; }
        public required string uf { get; set; }
    }
}
