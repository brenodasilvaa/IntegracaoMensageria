namespace Receiver.Data.Entities
{
    public class Mensagem
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
