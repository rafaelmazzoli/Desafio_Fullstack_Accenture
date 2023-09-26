using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public interface IEmpresaData
    {
        Task<Empresa?> Delete(int id);
        Task<IEnumerable<Empresa>> GetAll();
        Task<Empresa?> GetById(int id);
        Task<Empresa?> Insert(Empresa empresa);
        Task<Empresa?> Update(Empresa empresa);
    }
}