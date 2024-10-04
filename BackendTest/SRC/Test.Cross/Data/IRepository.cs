using System.Data.Common;

namespace Test.Cross.Data;

public interface IRepository<T> : IDisposable where T : class
{
    IUnitOfWork UnitOfWork { get; }
    DbConnection ObterConexao();
}
