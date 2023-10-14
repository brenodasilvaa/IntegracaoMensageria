using Receiver.Data;
using Receiver.Data.Repositories;
using Receiver.Services;

namespace Receiver.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHostedService<MensagemIntegrationHandler>();

            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<ReceiverContext>();
            services.AddScoped<IMessageService, MessageService>();

        }
    }
}
