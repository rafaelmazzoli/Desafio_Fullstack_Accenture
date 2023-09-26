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

        public Task<IEnumerable<Fornecedor>> GetAll() =>
            _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_GetAll", new { });

        public async Task<Fornecedor?> GetById(int id)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor?> InsertCpf(Fornecedor fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Insert_Cpf", new { fornecedor.Nome, Cpf = fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email, fornecedor.Rg, fornecedor.Data_Nascimento });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor?> InsertCnpj(Fornecedor fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Insert_Cnpj", new { fornecedor.Nome, Cnpj = fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor?> UpdateCpf(Fornecedor fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Update_Cpf", new { fornecedor.Id, fornecedor.Nome, Cpf = fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email, fornecedor.Rg, fornecedor.Data_Nascimento });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor?> UpdateCnpj(Fornecedor fornecedor)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Update_Cnpj", new { fornecedor.Id, fornecedor.Nome, Cnpj = fornecedor.Cnpj_Cpf, fornecedor.Cep, fornecedor.Email });

            return results.FirstOrDefault();
        }

        public async Task<Fornecedor?> Delete(int id)
        {
            var results = await _database.ExecuteProcedure<Fornecedor, dynamic>("dbo.Fornecedor_Delete", new { Id = id });

            return results.FirstOrDefault();
        }
    }
}
