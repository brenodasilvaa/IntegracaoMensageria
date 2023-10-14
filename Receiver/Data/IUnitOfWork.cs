namespace Receiver.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
