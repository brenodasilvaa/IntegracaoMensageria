using EasyNetQ;
using Mensageria.Integration;
using Microsoft.AspNetCore.Mvc;

namespace Sender.Controllers
{
    [ApiController]
    [Route("api/message/")]
    public class MessageController : ControllerBase
    {
        private IBus _bus;

        public MessageController()
        {
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(string message)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            var response = await _bus.Rpc.RequestAsync<MensagemEnviadaIntegrationEvent, ResponseMessage>
                (new MensagemEnviadaIntegrationEvent { Id = Guid.NewGuid(), Text = message });

            if (!response.ValidationResult.IsValid)
                return ValidationProblem();

            return Ok(response);
        }
    }
}