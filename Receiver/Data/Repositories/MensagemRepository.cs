using Receiver.Data.Entities;

namespace Receiver.Data.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly ReceiverContext _receiverContext;

        public MensagemRepository(ReceiverContext context)
        {
            _receiverContext = context;
        }

        public IUnitOfWork UnitOfWork => _receiverContext;

        public async Task Create(Mensagem mensagem)
        {
            await _receiverContext.Mensagens.AddAsync(mensagem);
        }
    }
}
