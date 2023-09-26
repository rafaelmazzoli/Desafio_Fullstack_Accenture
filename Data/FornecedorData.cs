using Desafio_Fullstack_Accenture.Infrastructure;
using Desafio_Fullstack_Accenture.Models;

namespace Desafio_Fullstack_Accenture.Data
{
    public class FornecedorData : IFornecedorData
    {
        private readonly IDatabaseAccess _database;

        public FornecedorData(IDatabaseAccess database)
        {
            _database = database;
        }

        public Task<IEnumerable<IFornecedor>> GetAll() =>
            _database.ExecuteProcedure<IFornecedor, dynamic>("dbo.Fornecedor_GetAll", new { });

        public async Task<IFornecedor?> GetById(int id)
        {
            var results = await _database.ExecuteProcedure<IFornecedor, dynamic>("dbo.Fornecedor_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor_Cpf?> InsertCpf(Fornecedor_Cpf fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor_Cpf, dynamic>("dbo.Fornecedor_Insert_Cpf", new { fornecedor.Nome, fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email, fornecedor.Rg, fornecedor.Data_Nascimento });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor_Cnpj?> InsertCnpj(Fornecedor_Cnpj fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor_Cnpj, dynamic>("dbo.Fornecedor_Insert_Cpf", new { fornecedor.Nome, fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email });

            return results.FirstOrDefault();
        }

        public async Task<IFornecedor?> Update(IFornecedor fornecedor)
        {
            var results = await _database.ExecuteProcedure<IFornecedor, dynamic>("dbo.Fornecedor_Update", fornecedor);

            return results.FirstOrDefault();
        }

        public async Task<IFornecedor?> Delete(int id)
        {
            var results = await _database.ExecuteProcedure<IFornecedor, dynamic>("dbo.Fornecedor_Delete", new { Id = id });

            return results.FirstOrDefault();
        }
    }
}
