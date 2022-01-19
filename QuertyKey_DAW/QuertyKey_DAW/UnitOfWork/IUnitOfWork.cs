namespace QuertyKey_DAW
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
