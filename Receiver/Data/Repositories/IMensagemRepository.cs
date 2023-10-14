using Receiver.Data.Entities;

namespace Receiver.Data.Repositories
{
    public interface IMensagemRepository
    {
        Task Create(Mensagem mensagem);
        IUnitOfWork UnitOfWork { get; }
    }
}
