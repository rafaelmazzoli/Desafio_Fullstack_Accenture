using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public interface IFornecedorData
    {
        Task<IFornecedor?> Delete(int id);
        Task<IEnumerable<IFornecedor>> GetAll();
        Task<IFornecedor?> GetById(int id);
        Task<Fornecedor_Cnpj?> InsertCnpj(Fornecedor_Cnpj fornecedor);
        Task<Fornecedor_Cpf?> InsertCpf(Fornecedor_Cpf fornecedor);
        Task<IFornecedor?> Update(IFornecedor fornecedor);
    }
}