namespace Desafio_Fullstack_Accenture.Infrastructure
{
    public interface IDatabaseAccess
    {
        Task<IEnumerable<T>> ExecuteProcedure<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

    }
}