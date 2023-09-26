using Desafio_Fullstack_Accenture.Infrastructure;
using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public class EmpresaData : IEmpresaData
    {
        private readonly IDatabaseAccess _database;

        public EmpresaData(IDatabaseAccess database)
        {
            _database = database;
        }

        public Task<IEnumerable<Empresa>> GetAll() =>
            _database.ExecuteProcedure<Empresa, dynamic>("dbo.Empresa_GetAll", new { });

        public async Task<Empresa?> GetById(int id)
        {
            var results = await _database.ExecuteProcedure<Empresa, dynamic>("dbo.Empresa_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task<Empresa?> Insert(Empresa empresa)
        {
            var results = await _database.ExecuteProcedure<Empresa, dynamic>("dbo.Empresa_Insert", new { empresa.Nome_Fantasia, empresa.Cnpj, empresa.Cep });

            return results.FirstOrDefault();
        }

        public async Task<Empresa?> Update(Empresa empresa)
        {
            var results = await _database.ExecuteProcedure<Empresa, dynamic>("dbo.Empresa_Update", empresa);

            return results.FirstOrDefault();
        }

        public async Task<Empresa?> Delete(int id)
        {
            var results = await _database.ExecuteProcedure<Empresa, dynamic> ("dbo.Empresa_Delete", new { Id = id });

            return results.FirstOrDefault();
        }
    }
}
