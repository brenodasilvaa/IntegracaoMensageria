using EasyNetQ;
using FluentValidation.Results;
using Mensageria.Integration;
using Microsoft.OpenApi.Writers;

namespace Receiver.Services
{
    public class MensagemIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public MensagemIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.Rpc.RespondAsync<MensagemEnviadaIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegistrarMensagem(request)), cancellationToken: stoppingToken);

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarMensagem(MensagemEnviadaIntegrationEvent message)
        {
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var messageService = scope.ServiceProvider.GetService<IMessageService>();

                sucesso = await messageService.CreateMessage(new Data.Entities.Mensagem { Id = message.Id, Texto = message.Text });
            }

            return sucesso;
        }
    }
}
