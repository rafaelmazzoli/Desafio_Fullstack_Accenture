using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public interface IEmpresa_FornecedorData
    {
        Task<Empresa_Fornecedor?> Delete(int id);
        Task<IEnumerable<Empresa_Fornecedor>> GetAll();
        Task<Empresa_Fornecedor?> GetById(int id);
        Task<Empresa_Fornecedor?> Insert(Empresa_Fornecedor empresa_Fonecedor);
        Task<Empresa_Fornecedor?> Update(Empresa_Fornecedor empresa_Fonecedor);
    }
}