using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensageria.Integration
{
    public class MensagemEnviadaIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
