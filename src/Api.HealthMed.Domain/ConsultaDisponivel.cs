namespace Api.HealthMed.Domain
{
    public class ConsultaDisponivel
    {
        public int Id { get; set; }
        public int IdMedico { get; set; }
        public DateTime DataHora { get; set; }
        public bool Disponivel { get; set; }
        public decimal ValorConsulta { get; set; }
        public bool Ativo { get; set; }
    }
}
