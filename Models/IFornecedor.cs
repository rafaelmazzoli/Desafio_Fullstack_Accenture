namespace Desafio_Fullstack_Accenture.Models
{
    public interface IFornecedor
    {
        string Cep { get; set; }
        string Cnpj_Cpf { get; set; }
        string Email { get; set; }
        IList<Empresa>? Empresas { get; }
        int Id { get; }
        string Nome { get; set; }

        void SetId(int id);
    }
}