using FluentValidation.Results;
using Receiver.Data.Entities;

namespace Receiver.Services
{
    public interface IMessageService
    {
        Task<ValidationResult> CreateMessage(Mensagem message);
    }
}
