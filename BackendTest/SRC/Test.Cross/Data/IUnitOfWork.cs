namespace Test.Cross.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
