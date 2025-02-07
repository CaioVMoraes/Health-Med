namespace Api.HealthMed.Domain
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int IdAgendamento { get; set; }
        public required string Assunto { get; set; }
        public required string Mensagem { get; set; }
        public required string Para { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
