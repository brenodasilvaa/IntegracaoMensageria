using FluentValidation.Results;
using Receiver.Data;
using Receiver.Data.Entities;
using Receiver.Data.Repositories;

namespace Receiver.Services
{
    public class MessageService : IMessageService
    {
        public IMensagemRepository _messageRepository { get; set; }

        public MessageService(IMensagemRepository mensagemRepository)
        {
            _messageRepository = mensagemRepository;
        }

        public async Task<ValidationResult> CreateMessage(Mensagem message)
        {
            var validationResult = new ValidationResult();

            await _messageRepository.Create(message);

            var resultado = await _messageRepository.UnitOfWork.Commit();

            if (!resultado)
                validationResult.Errors.Add(new ValidationFailure { ErrorMessage = "Não foi possível salvar as alterações" });

            return validationResult;
        }
    }
}
