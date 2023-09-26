using Desafio_Fullstack_Accenture.Infrastructure;
using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public class Empresa_FornecedorData : IEmpresa_FornecedorData
    {
        private readonly IDatabaseAccess _database;

        public Empresa_FornecedorData(IDatabaseAccess database)
        {
            _database = database;
        }

        public Task<IEnumerable<Empresa_Fornecedor>> GetAll() =>
            _database.ExecuteProcedure<Empresa_Fornecedor, dynamic>("dbo.Empresa_Fornecedor_GetAll", new { });

        public async Task<Empresa_Fornecedor?> GetById(int id)
        {
            var results = await _database.ExecuteProcedure<Empresa_Fornecedor, dynamic>("dbo.Empresa_Fornecedor_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task<Empresa_Fornecedor?> Insert(Empresa_Fornecedor empresa_Fonecedor)
        {
            var results = await _database.ExecuteProcedure<Empresa_Fornecedor, dynamic>("dbo.Empresa_Fornecedor_Insert", new { empresa_Fonecedor.Id_Empresa, empresa_Fonecedor.Id_Fornecedor });

            return results.FirstOrDefault();
        }

        public async Task<Empresa_Fornecedor?> Update(Empresa_Fornecedor empresa_Fonecedor)
        {
            var results = await _database.ExecuteProcedure<Empresa_Fornecedor, dynamic>("dbo.Empresa_Fornecedor_Update", empresa_Fonecedor);

            return results.FirstOrDefault();
        }

        public async Task<Empresa_Fornecedor?> Delete(int id)
        {
            var results = await _database.ExecuteProcedure<Empresa_Fornecedor, dynamic>("dbo.Empresa_Fornecedor_Delete", new { Id = id });

            return results.FirstOrDefault();
        }
    }
}
