namespace Desafio_Fullstack_Accenture.Data
{
    public interface IFornecedorData
    {
        Task<Fornecedor?> Delete(int id);
        Task<IEnumerable<Fornecedor>> GetAll();
        Task<Fornecedor?> GetById(int id);
        Task<Fornecedor?> InsertCnpj(Fornecedor fornecedor);
        Task<Fornecedor?> InsertCpf(Fornecedor fornecedor);
        Task<Fornecedor?> UpdateCpf(Fornecedor fornecedor);
        Task<Fornecedor?> UpdateCnpj(Fornecedor fornecedor);
    }
}