namespace Api.HealthMed.Domain
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdConsulta { get; set; }
        public bool MedicoAceitou { get; set; }
        public bool MedicoRecusou { get; set; }
        public bool PacienteCancelou { get; set; }
        public string? JustifcativaCancelamento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
