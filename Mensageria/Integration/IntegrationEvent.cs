using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensageria.Integration
{
    public abstract class IntegrationEvent
    {
    }

    public class MensagemEnviadaEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }

        public MensagemEnviadaEvent(string mensagem)
        {
            Id = Guid.NewGuid();    
            Mensagem = mensagem;
        }
    }
}
